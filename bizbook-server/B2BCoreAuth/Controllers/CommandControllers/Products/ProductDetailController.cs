using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Products;
using ServiceLibrary.Products;
using ViewModel.Products;

namespace B2BCoreApi.Controllers.CommandControllers.Products
{
    [Route("api/ProductDetail")]
    public class ProductDetailController : BaseCommandController<ProductDetail, ProductDetailRequestModel, ProductDetailViewModel>
    {
        public ProductDetailController(BizBookInventoryContext db, ILogger<ProductDetailController> logger) : base(new ProductDetailService(new BaseRepository<ProductDetail>(db)), logger)
        {

        }
    }
}