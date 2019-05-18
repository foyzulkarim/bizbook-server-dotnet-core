using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using B2BCoreApi.Attributes;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Model;
//using ServiceLibrary.Sales;

namespace B2BCoreApi.Controllers.QueryControllers
{
    [BizBookAuthorization]
    [Route("api/DashboardQuery")]
    public class DashboardQueryController : Controller
    {
        public ApplicationUser AppUser;

        private BizBookInventoryContext db;

        public DashboardQueryController(BizBookInventoryContext db)
        {
            this.db = db;

        }

        [HttpGet]
        [Route("Data")]
        [ActionName("Data")]
        public async Task<IActionResult> Data()
        {
            //AppUser = Request.HttpContext.Items["AppUser"] as ApplicationUser;
            //string shopId = AppUser.ShopId;

            //SaleService saleService=new SaleService(new BaseRepository<Sale>(db));
            //dynamic sales = await saleService.GetSalesAmounts(shopId);

            //var data = new
            //{
            //    Sales = sales            
            //};

            return Ok();
        }
    }
}