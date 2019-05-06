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
using ServiceLibrary.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.CommandControllers.Products
{
    [Route("api/SupplierProduct")]
    public class SupplierProductController : BaseCommandController<SupplierProduct, SupplierProductRequestModel, SupplierProductViewModel>
    {
        public SupplierProductController(BizBookInventoryContext db, ILogger<SupplierProductController> logger) : base(new ServiceLibrary.BaseService<SupplierProduct, SupplierProductRequestModel, SupplierProductViewModel>(new  BaseRepository<SupplierProduct>(db)), logger)
        {

        }

        //[HttpPut]
        //[Route("UpdateDues")]
        //[ActionName("UpdateDues")]
        //[EntitySaveFilter]
        //public IHttpActionResult UpdateDues(SupplierProductDetailUpdateModel model)
        //{
        //    var service = new SupplierProductService(new BaseRepository<SupplierProduct>(BusinessDbContext.Create()));

        //    AddCommonValues(model, model.Transaction);

        //    foreach (var entity in model.SupplierProductTransactions)
        //    {
        //        AddCommonValues(model, entity);
        //        entity.TransactionId = model.Transaction.Id;
        //    }

        //    bool updated = service.UpdateDues(model);
        //    return Ok(updated);
        //}
    }

}
