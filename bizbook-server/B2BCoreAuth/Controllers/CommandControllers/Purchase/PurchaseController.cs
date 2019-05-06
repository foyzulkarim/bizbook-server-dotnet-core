using System.Web.Http;
using Model;
using RequestModel.Purchases;
using ServiceLibrary.Purchases;
using ViewModel.Purchases;
using M = Model.Model.Purchase;

namespace B2BCoreApi.Controllers.CommandControllers.Purchase
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/Purchase")]
    public class PurchaseController : BaseCommandController<M, PurchaseRequestModel, PurchaseViewModel>
    {
        public PurchaseController(BizBookInventoryContext db, ILogger<PurchaseController> logger) : base(new PurchaseService(new BaseRepository<M>(db)), logger)
        {
        }


        //[HttpPut]
        //[Route("Return")]
        //[ActionName("Return")]
        //[EntityEditFilter]
        //public IHttpActionResult Return(Purchase model)
        //{
        //    var data = model;
        //    if (!ModelState.IsValid)
        //    {
        //        Logger.Warning("User {@UserName} ConnectionId {@ConnectionId} sent Invalid model state {@Data}", this.AppUser.UserName, this.AppUser.ConnectionId, data);
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var service = Service as PurchaseService;
        //        bool returned = service.PurchaseReturn(model);
        //        Logger.Debug("User {@UserName} ConnectionId {@ConnectionId} sale returned with Id {@Id}", this.AppUser.UserName, this.AppUser.ConnectionId, data.Id);
                
        //        return Ok(returned);
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        Logger.Fatal(exception, "Exception occurred while updating sale return");
        //        return InternalServerError(exception);
        //    }
        //}
    }
}