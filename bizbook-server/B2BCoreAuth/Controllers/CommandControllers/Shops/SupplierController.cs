using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using RequestModel.Shops;
using ViewModel.Shops;
using M = Model.Model.Supplier;

namespace B2BCoreApi.Controllers.CommandControllers.Shops
{
    [Route("api/Supplier")]
    public class SupplierController : BaseCommandController<M, SupplierRequestModel, SupplierViewModel>
    {
        public SupplierController(BizBookInventoryContext db, ILogger<SupplierController> logger) : base(new ServiceLibrary.BaseService<M, SupplierRequestModel, SupplierViewModel>(new BaseRepository<M>(db)), logger)
        {

        }
    }
}