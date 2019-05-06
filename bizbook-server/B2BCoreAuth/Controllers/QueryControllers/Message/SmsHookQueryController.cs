using Model.Model;
using RequestModel.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel.Message;
using Model;

namespace B2BCoreApi.Controllers.QueryControllers.Message
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ServiceLibrary.Messages;

    [Route("api/SmsHookQuery")]
    public class SmsHookQueryController : BaseQueryController<SmsHook, SmsHookRequestModel, SmsHookViewModel>
    {
        public SmsHookQueryController(BizBookInventoryContext db, ILogger<SmsHookQueryController> logger) : base(new SmsHookService(new BaseRepository<SmsHook>(db)), logger)
        {
        }

        //[Route("SearchHooks")]
        //[ActionName("SearchHooks")]
        //[HttpPost]
        //public async Task<IHttpActionResult> SearchHooks(SmsHookRequestModel request)
        //{
        //    try
        //    {
        //        SmsHookService service = this.Service as SmsHookService;
        //        var v = await service.SearchHooks(request);
        //        Tuple<List<SmsHook>, int> content = new Tuple<List<SmsHook>, int>(v, v.Count);
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, content);
        //        return ResponseMessage(response);
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.Fatal(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
        //        return InternalServerError(exception);
        //    }
        //}
    }
}
