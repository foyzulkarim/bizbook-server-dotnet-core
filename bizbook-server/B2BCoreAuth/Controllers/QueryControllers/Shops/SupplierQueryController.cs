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
using ServiceLibrary.Shops;
using ViewModel.History;
using ViewModel.Shops;
using Rm = RequestModel.Shops.SupplierRequestModel;
using M = Model.Model.Purchases.Supplier;
using Vm = ViewModel.Shops.SupplierViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.QueryControllers.Shops
{
    [Route("api/SupplierQuery")]
  public class SupplierQueryController : BaseQueryController<M, Rm, Vm>
    {
        public SupplierQueryController(BizBookInventoryContext db, ILogger<SupplierQueryController> logger) : base(new SupplierService(new BaseRepository<M>(db)), logger)
        {
        }

        //[Route("History")]
        //[ActionName("History")]
        //[HttpPost]
        //public async Task<IHttpActionResult> History(Rm request)
        //{
        //    try
        //    {
        //        SupplierService service = Service as SupplierService;
        //        Tuple<List<HistoryViewModel>, int> content = await service.GetHistory(request);
        //        Vm model = service.GetDetail(request.ParentId);
        //        var purchaseTotal = content.Item1.Where(x => x.Type == "Purchase").Sum(x => x.Total);
        //        var paymentTotal = content.Item1.Where(x => x.Type == "Payment").Sum(x => x.Total);
        //        var responseContent = new
        //        {
        //            Supplier = model,
        //            Histories = content.Item1,
        //            PurchaseTotal=purchaseTotal,
        //            PaymentTotal=paymentTotal
        //        };
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseContent);
        //        response.Headers.Add("Count", content.Item2.ToString());
        //        return ResponseMessage(response);
        //    }
        //    catch (Exception exception)
        //    {
        //        //telemetryClient.TrackException(exception);
        //        Logger.Fatal(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
        //        return InternalServerError(exception);
        //    }
        //}

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
        //        string fileName = $"SuppliersReport-{ticks}.xls";
        //        string fullName = $"{tempPath}\\" + fileName;
        //        List<Vm> allAsync = await Service.GetAllAsync();
        //        string headerValue = "Suppliers Report \n Printed " + DateTime.Now.ToString("dd-MM-yyyy");
        //        List<SupplierReportModel> reportdata = allAsync.Where(x=>x.ShopId== id).Select(x => new SupplierReportModel { Name = x.Name, Address = x.Address, Phone = x.Phone }).ToList();

        //        GenericReportGenerator<SupplierReportModel>.WriteExcel(reportdata, headerValue, fullName);
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
        //            "Exception occurred while Downloading Suppliers data");
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, exception);
        //    }

        //}
    }
}
