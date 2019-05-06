using System.Web.Http;
using Model;
using Model.Model;
using RequestModel.Shops;
using ViewModel.Shops;

namespace B2BCoreApi.Controllers.CommandControllers.Shops
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    //using Model.Dealers;

    [Route("api/Dealer")]
    public class DealerController : BaseCommandController<Dealer,DealerRequestModel,DealerViewModel>
    {
        public DealerController(BizBookInventoryContext db, ILogger<DealerController> logger) : base(new ServiceLibrary.BaseService<Dealer, DealerRequestModel, DealerViewModel>(new BaseRepository<Dealer>(db)), logger)
        {
        }
    }
}
