

using Model;
using Model.Model;
using RequestModel.Warehouses;
using ViewModel.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceLibrary.Warehouses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.CommandControllers.Warehouses
{
    [Route("api/StockTransfer")]
    public class StockTransferController : BaseCommandController<StockTransfer, StockTransferRequestModel, StockTransferViewModel>
    {
        public StockTransferController(BizBookInventoryContext db, ILogger<StockTransferController> logger) : base(new StockTransferService(new BaseRepository<StockTransfer>(db)), logger)
        {

        }


        //[Route("UpdateState")]
        //[ActionName("UpdateState")]
        //[HttpPut]
        //public IHttpActionResult UpdateState(StockTransfer stockTransfer)
        //{
        //    if (stockTransfer==null || string.IsNullOrWhiteSpace(stockTransfer.Id))
        //    {
        //        return BadRequest("Data should not be null");
        //    }

        //    var service = Service as StockTransferService;
        //    bool updateState = service.UpdateState(stockTransfer.Id);
        //    return Ok(updateState);
        //}
    }
}
