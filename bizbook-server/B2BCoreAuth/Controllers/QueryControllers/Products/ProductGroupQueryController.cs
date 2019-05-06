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
using Rm = RequestModel.Products.ProductGroupRequestModel;
using M = Model.Model.ProductGroup;
using Vm = ViewModel.Products.ProductGroupViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLibrary;

namespace B2BCoreApi.Controllers.QueryControllers.Products
{
    [Route("api/ProductGroupQuery")]
    public class ProductGroupQueryController : BaseQueryController<M, Rm, Vm>
    {
        public ProductGroupQueryController(BizBookInventoryContext db, ILogger<ProductGroupQueryController> logger) : base(new BaseService<M, Rm, Vm>(new BaseRepository<M>(db)), logger)
        {
            
        }        
    }
}
