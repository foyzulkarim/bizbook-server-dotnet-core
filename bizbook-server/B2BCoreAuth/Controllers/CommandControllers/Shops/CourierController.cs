using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Shops;
using ViewModel.Shops;

namespace B2BCoreApi.Controllers.CommandControllers.Shops
{
    [Route("api/Courier")]
    public class CourierController : BaseCommandController<Courier,CourierRequestModel,CourierViewModel>
    {
        public CourierController(BizBookInventoryContext db, ILogger<CourierController> logger) : base(new ServiceLibrary.BaseService<Courier, CourierRequestModel, CourierViewModel>(new BaseRepository<Courier>(db)), logger)
        {
        }
    }
}
