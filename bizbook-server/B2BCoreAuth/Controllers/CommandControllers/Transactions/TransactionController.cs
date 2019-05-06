using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Transactions;
using ViewModel.Transactions;
using TransactionService = ServiceLibrary.Transactions.TransactionService;

namespace B2BCoreApi.Controllers.CommandControllers.Transactions
{
    [Route("api/Transaction")]
    public class TransactionController : BaseCommandController<Transaction, TransactionRequestModel, TransactionViewModel>
    {
        public TransactionController(BizBookInventoryContext db, ILogger<TransactionController> logger) : base(new TransactionService(new BaseRepository<Transaction>(db)), logger)
        {

        }


    }
}