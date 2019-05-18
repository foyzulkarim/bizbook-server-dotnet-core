using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Model;
using ViewModel.Transactions;
using Rm = RequestModel.Transactions.AccountHeadRequestModel;
using M = Model.Model.Transactions.AccountHead;
using Vm = ViewModel.Transactions.AccountHeadViewModel;

namespace B2BCoreApi.Controllers.QueryControllers.Transactions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RequestModel.Reports;

   // using ServiceLibrary.Reports;

    [Route("api/AccountHeadQuery")]
    public class AccountHeadQueryController: BaseQueryController<M, Rm, Vm>
    {
        public AccountHeadQueryController(BizBookInventoryContext db, ILogger<AccountHeadQueryController> logger) : base(new ServiceLibrary.BaseService<M, Rm, Vm>(new BaseRepository<M>(db)), logger)
        {
        }

        //[Route("Report")]
        //[ActionName("Report")]
        //[HttpPost]
        //public async Task<IHttpActionResult> Report(AccountReportRequestModel request)
        //{
        //    try
        //    {
        //        var reportService = new AccountReportService2();
        //        var reports = await reportService.SearchAsync(request);
        //        var response = this.Request.CreateResponse(HttpStatusCode.OK, reports.Item1);
        //        return ResponseMessage(response);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}