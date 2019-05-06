using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Shops;
using ViewModel.Shops;

namespace B2BCoreApi.Controllers.QueryControllers.Shops
{
    //using Model.Dealers;

    [Route("api/DealerQuery")]
    public class DealerQueryController : BaseQueryController<Dealer, DealerRequestModel, DealerViewModel>
    {
        public DealerQueryController(BizBookInventoryContext db, ILogger<DealerQueryController> logger) : base(new ServiceLibrary.BaseService<Dealer, DealerRequestModel, DealerViewModel>(new BaseRepository<Dealer>(db)), logger)
        {
        }
    }
}
