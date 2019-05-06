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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.QueryControllers.Products
{
    [Route("api/DealerProductQuery")]
    public class DealerProductQueryController : BaseQueryController<DealerProduct, DealerProductRequestModel, DealerProductViewModel>
    {
        public DealerProductQueryController(BizBookInventoryContext db, ILogger<DealerProductQueryController> logger) : base(new ServiceLibrary.BaseService<DealerProduct, DealerProductRequestModel, DealerProductViewModel>(new BaseRepository<DealerProduct>(db)), logger)
        {

        }
    }
}
