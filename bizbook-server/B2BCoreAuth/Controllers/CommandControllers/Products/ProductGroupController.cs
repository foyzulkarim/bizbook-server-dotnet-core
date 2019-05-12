using System.Web.Http;
using Model;
using Rm = RequestModel.Products.ProductGroupRequestModel;
using M = Model.Model.ProductGroup;
using Vm = ViewModel.Products.ProductGroupViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLibrary;

namespace B2BCoreApi.Controllers.CommandControllers.Products
{
    [Route("api/ProductGroup")]
    public class ProductGroupController : BaseCommandController<M, Rm, Vm>
    {
        public ProductGroupController(ILogger<ProductGroupController> logger, IBaseService<M, Rm, Vm> service) : base(service, logger)
        {

        }
    }
}