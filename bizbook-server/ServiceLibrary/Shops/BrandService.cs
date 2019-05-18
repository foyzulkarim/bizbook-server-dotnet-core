using System.Linq;
using Model.Model;
using Model.Model.Products;
using Model.Shops;

namespace ServiceLibrary.Shops
{
    using System;
    using Model;
    using RequestModel.Shops;

    using ViewModel.Shops;

    public class BrandService : BaseService<Brand, BrandRequestModel, BrandViewModel>
    {
        private BizBookInventoryContext db;

        public BrandService(BaseRepository<Brand> repository)
            : base(repository)
        {
            this.db = base.Repository.Db as BizBookInventoryContext;
        }

        public Brand GetDefaultBrand(string shopId, string createdBy)
        {
            Shop shop = this.db.Shops.Find(shopId);
            var brand = db.Brands.FirstOrDefault(x => x.ShopId == shopId && x.Name == shop.Name);
            if (brand == null)
            {
                brand = new Brand
                            {
                                Id = Guid.NewGuid().ToString(),
                                Created = DateTime.Now,
                                Modified = DateTime.Now,
                                CreatedBy = createdBy,
                                ModifiedBy = createdBy,
                                ShopId = shopId,
                                CreatedFrom = "Server",
                                Name = shop.Name
                            };
                db.Brands.Add(brand);
                db.SaveChanges();
            }

            return brand;
        }
    }
}