using System.Web.Http;
using Model;
using RequestModel.Transactions;
using ViewModel.Transactions;

namespace B2BCoreApi.Controllers.CommandControllers.Transactions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Model.Model;


    [Route("api/AccountHead")]
    public class AccountHeadController : BaseCommandController<AccountHead, AccountHeadRequestModel, AccountHeadViewModel>
    {
        public AccountHeadController(BizBookInventoryContext db, ILogger<AccountHeadController> logger) : base(new ServiceLibrary.BaseService<AccountHead, AccountHeadRequestModel, AccountHeadViewModel>(
            new BaseRepository<AccountHead>(db)), logger)
        {

        }
    }
}