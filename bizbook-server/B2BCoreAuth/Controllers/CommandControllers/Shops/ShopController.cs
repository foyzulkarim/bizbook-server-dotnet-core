using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using B2BCoreApi.Attributes;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using RequestModel.Shops;
using Serilog;
using ServiceLibrary;
using ViewModel.Shops;
using M = Model.Shops.Shop;

namespace B2BCoreApi.Controllers.CommandControllers.Shops
{
    [Authorize(Roles = "SuperAdmin")]
    [Route("api/Shop")]
    public class ShopController : Controller
    {
        public static ILogger Logger = Log.ForContext(typeof(ShopController));
        private string typeName;
        private UserManager<ApplicationUser> userManager;
        private BizBookInventoryContext db;

        public BaseService<M, ShopRequestModel, ShopSuperAdminViewModel> Service { get; set; }

        public ShopController(BizBookInventoryContext db, UserManager<ApplicationUser> userManager)
        {
            Service = new BaseService<M, ShopRequestModel, ShopSuperAdminViewModel>(new BaseRepository<M>(db));
            typeName = typeof(ShopController).Name;
            this.userManager = userManager;
            this.db = db;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ActionName("Add")]
        [Route("Add")]
        [EntitySaveFilter]
        public ActionResult Add(M model)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                model.RegistrationDate = DateTime.UtcNow;
                model.IsActive = true;
                model.IsDeleted = false;
                model.IsVerified = true;
                bool post = Service.Add(model);
                if (!string.IsNullOrWhiteSpace(post.ToString()))
                {
                    AddUser(model);
                    AddAccountHeads(model);
                    AddBrand(model);
                    AddSupplier(model);
                    AddProduct(model);
                }

                scope.Complete();
                return Ok();
            }
        }
        
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut]
        [Route("Edit")]
        [ActionName("Edit")]
        [EntityEditFilter]
        public ActionResult Put(M model)
        {
            M shop = Service.GetById(model.Id);
            shop.Modified = model.Modified;
            shop.ModifiedBy = model.ModifiedBy;
            if (model.ExpiryDate != DateTime.MinValue && model.ExpiryDate != DateTime.MaxValue)
            {
                shop.ExpiryDate = model.ExpiryDate;
            }
            shop.Name = model.Name;
            shop.WcUrl = model.WcUrl;
            shop.WcKey = model.WcKey;
            shop.WcSecret = model.WcSecret;
            shop.WcWebhookSource = model.WcWebhookSource;
            bool edit = Service.Edit(shop);
            return Ok(edit);
        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("Delete")]
        [ActionName("Delete")]
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                M shop = Service.GetById(id);
                shop.IsActive = false;
                shop.IsDeleted = true;
                shop.ExpiryDate = DateTime.Now;
                bool delete = Service.Edit(shop);

                Logger.Debug("Deleted entity {TypeName} with value {id}", typeName, id);
                return Ok(delete);
            }
            catch (Exception exception)
            {
                Logger.Fatal(exception, "Exception occurred while saving {TypeName}", typeName);
                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }
        
        private async Task AddUser(M model)
        {            
            var shopName = Regex.Replace(model.Name.ToLower(), "[^a-zA-Z0-9]", string.Empty);
            string userName = "admin@" + shopName + "." + "bizbook.co";
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
                IsActive = true,
                EmailConfirmed = true,
                PhoneNumber = model.Phone,
                ShopId = model.Id,
                FirstName = "Admin",
                LastName = model.Name
            };

            IdentityResult result = await userManager.CreateAsync(user, "Pass@" + model.Phone);
            if (result.Succeeded)
            {
                IdentityResult addedToRole = await userManager.AddToRoleAsync(user, ApplicationRoles.ShopAdmin.ToString());
                if (addedToRole.Succeeded)
                {
                    user.RoleName = ApplicationRoles.ShopAdmin.ToString();
                    var identityResult = await userManager.UpdateAsync(user);
                }
            }
        }

        private void AddAccountHeads(M model)
        {            
            var shopId = model.Id;
            BusinessSeedData.AddAccountHeads(db, shopId);
            BusinessSeedData.AddAccountInfo(db,shopId);
        }

        private void AddBrand(M model)
        {            
            var shopId = model.Id;
            BusinessSeedData.AddBrand(shopId, db, model.Name);
        }

        private void AddSupplier(M model)
        {
            var shopId = model.Id;
            BusinessSeedData.AddSupplier(shopId, db, model.Name);
        }

        private void AddProduct(M model)
        {
            var shopId = model.Id;
            BusinessSeedData.AddProducts(db, shopId);
        }
    }
}