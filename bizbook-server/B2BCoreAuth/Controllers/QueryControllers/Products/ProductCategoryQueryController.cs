using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using Model.Model.Products;
using RequestModel.Products;
using ServiceLibrary.Products;
using ViewModel.Products;

namespace B2BCoreApi.Controllers.QueryControllers.Products
{
    [Route("api/ProductCategoryQuery")]
    public class ProductCategoryQueryController : BaseQueryController<ProductCategory, ProductCategoryRequestModel, ProductCategoryViewModel>
    {
        public ProductCategoryQueryController(BizBookInventoryContext db, ILogger<ProductCategoryQueryController> logger) : base(
           new ProductCategoryService(new BaseRepository<ProductCategory>(db)), logger)
        {

        }        
    }
}
