using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using ServiceLibrary.Shops;
using Microsoft.AspNetCore.Mvc;
using Model;
using Rm = RequestModel.Shops.BrandRequestModel;
using M = Model.Model.Brand;
using Vm = ViewModel.Shops.BrandViewModel;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.QueryControllers.Shops
{

    [Route("api/BrandQuery")]
    public class BrandQueryController : BaseQueryController<M, Rm, Vm>
    {
        public BrandQueryController(BizBookInventoryContext db, ILogger<BrandQueryController> logger) : base(new BrandService(new BaseRepository<M>(db)), logger)
        {
        }        
    }
}