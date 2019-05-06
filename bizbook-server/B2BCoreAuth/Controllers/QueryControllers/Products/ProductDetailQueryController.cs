using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Model;
using Model.Model;

using ServiceLibrary.Products;

using Rm = RequestModel.Products.ProductDetailRequestModel;
using Vm = ViewModel.Products.ProductDetailViewModel;

namespace B2BCoreApi.Controllers.QueryControllers.Products
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    //using ReportModel;

    using RequestModel.Reports;

    //using ServiceLibrary.Reports;

    //using ViewModel.Reports;

    [Route("api/ProductDetailQuery")]
    public class ProductDetailQueryController : BaseQueryController<ProductDetail, Rm, Vm>
    {

        public ProductDetailQueryController(BizBookInventoryContext db, ILogger<ProductDetailQueryController> logger) : base(new ProductDetailService(new BaseRepository<ProductDetail>(db)), logger)
        {

        }

        [Route("Barcode")]
        [ActionName("Barcode")]
        [HttpGet]
        public async Task<ActionResult> GetBarcode()
        {
            var service = Service as ProductDetailService;
            string barcode = await service.GetBarcode(AppUser.ShopId);
            return Ok(barcode);
        }

        [Route("History")]
        [ActionName("History")]
        [HttpPost]
        public async Task<ActionResult> History(Rm request)
        {
            try
            {

                ProductDetailService service = Service as ProductDetailService;
                var content = await service.GetHistory(request);
                return Ok(content);
            }
            catch (Exception exception)
            {
                //telemetryClient.TrackException(exception);
                Logger.LogError(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
                return StatusCode(500, exception.Message);
            }
        }

        //[Route("Report")]
        //[ActionName("Report")]
        //[HttpPost]
        //public async Task<ActionResult> Report(ProductReportRequestModel request)
        //{
        //    try
        //    {
        //        var reportService = new ProductReportService2();
        //        if (request == null)
        //        {
        //            return BadRequest("Request should be not null");
        //        }

        //        var reports = await reportService.SearchAsync(request);
        //        var response = this.Request.CreateResponse(HttpStatusCode.OK, reports);
        //        return ResponseMessage(response);
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.LogError(exception, "Exception occurred while Reporting {TypeName} with Request {Request}", typeName, request);
        //        return StatusCode(500, exception.Message);
        //    }
        //}

        [Route("SearchByWarehouse")]
        [ActionName("SearchByWarehouse")]
        [HttpPost]
        public async Task<ActionResult> SearchByWarehouse(Rm request)
        {
            try
            {
                var service = this.Service as ProductDetailService;
                Tuple<List<Vm>, int> content = await service.SearchByWarehouseAsync(request);
                return Ok(content);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
                return StatusCode(500, exception.Message);
            }
        }
    }
}
