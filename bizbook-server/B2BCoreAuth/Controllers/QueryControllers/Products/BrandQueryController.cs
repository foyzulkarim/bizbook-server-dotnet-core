using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using ServiceLibrary.Shops;
using Rm = RequestModel.Shops.BrandRequestModel;
using M = Model.Model.Products.Brand;
using Vm = ViewModel.Shops.BrandViewModel;

namespace B2BCoreApi.Controllers.QueryControllers.Products
{

    [Route("api/BrandQuery")]
    public class BrandQueryController : BaseQueryController<M, Rm, Vm>
    {
        public BrandQueryController(BizBookInventoryContext db, ILogger<BrandQueryController> logger) : base(new BrandService(new BaseRepository<M>(db)), logger)
        {
        }
    }
}