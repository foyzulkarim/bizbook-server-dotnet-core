using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;

using RequestModel.Transactions;
using ServiceLibrary.Transactions;
using ViewModel.Transactions;

namespace B2BCoreApi.Controllers.QueryControllers.Transactions
{
    [Route("api/TransactionQuery")]
    public class TransactionQueryController : BaseQueryController<Transaction, TransactionRequestModel, TransactionViewModel>
    {
       
        public TransactionQueryController(BizBookInventoryContext db, ILogger<TransactionQueryController> logger) : base(
           new TransactionService(new BaseRepository<Transaction>(db)), logger)
        {

        }

        //[ActionName("Dropdowns")]
        //[HttpGet]
        //[Route("Dropdowns")]
        //public IHttpActionResult GetDropdowns()
        //{
        //    List<string> transactionFors = Enum.GetNames(typeof(TransactionFor)).ToList();
        //    List<string> transactionWiths = Enum.GetNames(typeof(TransactionWith)).ToList();
        //    List<string> transactionMediums = Enum.GetNames(typeof(TransactionMedium)).ToList();
        //    List<string> transactionFlowTypes = Enum.GetNames(typeof(TransactionFlowType)).ToList();
        //    List<string> paymentGatewayServices = Enum.GetNames(typeof(PaymentGatewayService)).ToList();
        //    List<string> accountTypes = Enum.GetNames(typeof (AccountHeadType)).ToList();
        //    List<string> accountInfoTypes = Enum.GetNames(typeof(AccountInfoType)).ToList();

        //    var dropdowns = new
        //    {
        //        transactionFors,
        //        transactionWiths,
        //        transactionMediums,
        //        transactionFlowTypes,
        //        paymentGatewayServices,
        //        accountTypes,
        //        accountInfoTypes
        //    };

        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, dropdowns);
        //    return ResponseMessage(response);
        //}

        //[Route("Report")]
        //[ActionName("Report")]
        //[HttpPost]
        //public async Task<IHttpActionResult> Report(TransactionReportRequestModel request)
        //{
        //    try
        //    {
        //        var reportService = new TransactionReportService(new BaseRepository<TransactionReport>(BusinessDbContext.Create()));
        //        if (request == null)
        //        {
        //            request = new TransactionReportRequestModel(string.Empty, "DateStart", "True");
        //            request.ReportTimeType = ReportTimeType.Daily;
        //            request.ShopId = "00000000-0000-0000-0000-000000000001";
        //            request.TransactionReportType = TransactionReportType.TransactionByAmount;
        //            request.Page = -1;
        //        }

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
