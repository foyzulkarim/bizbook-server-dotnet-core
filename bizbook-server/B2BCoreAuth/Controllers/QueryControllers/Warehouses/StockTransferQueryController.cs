
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

namespace B2BCoreApi.Controllers.QueryControllers.Warehouses
{
    [Route("api/StockTransferQuery")]
    public class StockTransferQueryController : BaseQueryController<StockTransfer, StockTransferRequestModel, StockTransferViewModel>
    {
        public StockTransferQueryController(BizBookInventoryContext db, ILogger<StockTransferQueryController> logger) : base(new StockTransferService(new BaseRepository<StockTransfer>(db)), logger)
        {

        }
    }
}
