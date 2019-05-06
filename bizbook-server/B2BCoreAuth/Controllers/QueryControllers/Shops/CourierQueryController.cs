using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Shops;
using ViewModel.Shops;

namespace B2BCoreApi.Controllers.QueryControllers.Shops
{
    [Route("api/CourierQuery")]
    public class CourierQueryController : BaseQueryController<Courier,CourierRequestModel,CourierViewModel>
    {
        public CourierQueryController(BizBookInventoryContext db, ILogger<CourierQueryController> logger) : base(new ServiceLibrary.BaseService<Courier, CourierRequestModel, CourierViewModel>(new BaseRepository<Courier>(db)), logger)
        {
        }
    }
}
