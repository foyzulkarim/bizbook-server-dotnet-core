using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace B2BCoreApi.Controllers.CommandControllers.Warehouses
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Model;
    using Model.Model;
    

    using RequestModel.Transactions;
    using RequestModel.Warehouses;

    using ViewModel.Transactions;
    using ViewModel.Warehouses;

    [Route("api/Warehouse")]
    public class WarehouseController : BaseCommandController<Warehouse, WarehouseRequestModel, WarehouseViewModel>
    {
        public WarehouseController(BizBookInventoryContext db, ILogger<WarehouseController> logger) : base(new ServiceLibrary.BaseService<Warehouse, WarehouseRequestModel, WarehouseViewModel>(
        new BaseRepository<Warehouse>(db)), logger)
        {
            
        }
    }
}
