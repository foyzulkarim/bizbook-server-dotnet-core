using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using Rm = RequestModel.Products.ProductCategoryRequestModel;
using M = Model.Model.ProductCategory;
using Vm = ViewModel.Products.ProductCategoryViewModel;
using ServiceLibrary.Products;

namespace B2BCoreApi.Controllers.CommandControllers.Products
{
    [Route("api/ProductCategory")]
    public class ProductCategoryController : BaseCommandController<M,Rm,Vm>
    {
        public ProductCategoryController(BizBookInventoryContext db, ILogger<ProductCategoryController> logger) : base(
           new ProductCategoryService(new BaseRepository<ProductCategory>(db)), logger)
        {

        }
    }
}