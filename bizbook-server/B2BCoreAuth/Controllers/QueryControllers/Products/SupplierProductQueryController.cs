using Model.Model;
using RequestModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel.Products;
using Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace B2BCoreApi.Controllers.QueryControllers.Products
{
    [Route("api/SupplierProductQuery")]
    public class SupplierProductQueryController : BaseQueryController<SupplierProduct, SupplierProductRequestModel, SupplierProductViewModel>
    {
        public SupplierProductQueryController(BizBookInventoryContext db, ILogger<SupplierProductQueryController> logger) : base(new ServiceLibrary.BaseService<SupplierProduct, SupplierProductRequestModel, SupplierProductViewModel>(new BaseRepository<SupplierProduct>(db)), logger)
        {

        }
    }
}
