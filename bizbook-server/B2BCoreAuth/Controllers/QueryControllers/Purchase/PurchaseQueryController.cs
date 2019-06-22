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
using ViewModel.Purchases;
using Service = ServiceLibrary.Purchases.PurchaseService;
using Rm = RequestModel.Purchases.PurchaseRequestModel;
using M = Model.Model.Purchase;
using Vm = ViewModel.Purchases.PurchaseViewModel;
using ServiceLibrary.Purchases;
using ViewModel.History;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.QueryControllers.Purchase
{
    [Route("api/PurchaseQuery")]
    public class PurchaseQueryController : BaseQueryController<M, Rm, Vm>
    {
        public PurchaseQueryController(BizBookInventoryContext db, ILogger<PurchaseQueryController> logger) : base(new Service(new BaseRepository<M>(db)), logger)
        {

        }

        //[AllowAnonymous]
        //[Route("Report/{id}")]
        //[ActionName("Report")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> Report(string id)
        //{

        //    try
        //    {
        //        var tempPath = Path.GetTempPath();
        //        long ticks = DateTime.Now.Ticks;
        //        string fileName = $"PurchasesReport-{ticks}.xls";
        //        string fullName = $"{tempPath}\\" + fileName;
        //        List<Vm> allAsync = await Service.GetAllAsync();
        //        string headerValue = "Purchases Report \n Printed " + DateTime.Now.ToString("dd-MM-yyyy");
        //        List<PurchaseReportModel> reportdata = allAsync.Where(x => x.ShopId == id).Select(x => new PurchaseReportModel { Memo = x.OrderNumber, Supplier = x.SupplierName, Date = x.Modified, Total = x.TotalAmount, ModifiedBy = x.ModifiedBy }).ToList();
        //        PurchaseReportModel item = new PurchaseReportModel
        //        {
        //            Memo = "Total",
        //            Date = DateTime.Now,
        //            Total = reportdata.Sum(x => x.Total)
        //        };

        //        reportdata.Add(item);
        //        GenericReportGenerator<PurchaseReportModel>.WriteExcel(reportdata, headerValue, fullName);
        //        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //        var stream = new FileStream(fullName, FileMode.Open);
        //        result.Content = new StreamContent(stream);
        //        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //        {
        //            FileName = fileName
        //        };
        //        return result;
        //    }
        //    catch (Exception exception)
        //    {
        //        //telemetryClient.TrackException(exception);
        //        Logger.Fatal(exception,
        //            "Exception occurred while Downloading Purchases data");
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, exception);
        //    }

        //}


        //[Route("ProductHistory")]
        //[ActionName("ProductHistory")]
        //[HttpPost]
        //public async Task<IHttpActionResult> ProductHistory(Rm request)
        //{
        //    try
        //    {
        //        var purchaseService = Service as PurchaseService;
        //        Tuple<List<HistoryViewModel>, int> content = await purchaseService.GetProductHistoryAsync(request);
        //        var responseContent = new { Histories = content.Item1 };

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseContent);
        //        response.Headers.Add("Count", content.Item2.ToString());
        //        return ResponseMessage(response);
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.Fatal(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
        //        return InternalServerError(exception);
        //    }
        //}
    }
}
