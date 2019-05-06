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
   // using CommonLibrary.Model;

   // using Server.Inventory.Filters;

    [Route("api/DealerProduct")]
    public class DealerProductController : BaseCommandController<DealerProduct, DealerProductRequestModel, DealerProductViewModel>
    {
        public DealerProductController(BizBookInventoryContext db, ILogger<DealerProductController> logger) : base(new ServiceLibrary.BaseService<DealerProduct, DealerProductRequestModel, DealerProductViewModel>(new BaseRepository<DealerProduct>(db)), logger)
        {
        }


        //[HttpPut]
        //[Route("UpdateDues")]
        //[ActionName("UpdateDues")]
        //[EntitySaveFilter]
        //public IHttpActionResult UpdateDues(DealerProductDetailUpdateModel model)
        //{
        //    DealerProductService service = new DealerProductService(new BaseRepository<DealerProduct>(BusinessDbContext.Create()));
           
        //    AddCommonValues(model, model.Transaction);

        //    foreach (var entity in model.DealerProductTransactions)
        //    {
        //        AddCommonValues(model, entity);
        //        entity.TransactionId = model.Transaction.Id;
        //    }
            
        //    bool updated = service.UpdateDues(model);
        //    return Ok(updated);
        //}
    }
}
