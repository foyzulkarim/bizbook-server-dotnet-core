using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Transactions;
using ViewModel.Transactions;

namespace B2BCoreApi.Controllers.CommandControllers.Transactions
{
    [Route("api/AccountInfo")]
    public class AccountInfoController : BaseCommandController<AccountInfo, AccountInfoRequestModel, AccountInfoViewModel>
    {
        public AccountInfoController(BizBookInventoryContext db, ILogger<AccountInfoController> logger) : base(new ServiceLibrary.BaseService<AccountInfo, AccountInfoRequestModel, AccountInfoViewModel>(new BaseRepository<AccountInfo>(db)), logger)
        {
        }
    }
}
