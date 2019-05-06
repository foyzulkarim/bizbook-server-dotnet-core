using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Transactions;
using ViewModel.Transactions;

namespace B2BCoreApi.Controllers.QueryControllers.Transactions
{
    [Route("api/AccountInfoQuery")]
    public class AccountInfoQueryController : BaseQueryController<AccountInfo,AccountInfoRequestModel,AccountInfoViewModel>
    {
      
        public AccountInfoQueryController(BizBookInventoryContext db, ILogger<AccountInfoQueryController> logger) : base(new ServiceLibrary.BaseService<AccountInfo, AccountInfoRequestModel, AccountInfoViewModel>(new BaseRepository<AccountInfo>(db)), logger)
        {
        }
    }
}
