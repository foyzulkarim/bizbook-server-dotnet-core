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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.CommandControllers.Message
{
    [Route("api/SmsHook")]
    public class SmsHookController : BaseCommandController<SmsHook, SmsHookRequestModel, SmsHookViewModel>
    {
        public SmsHookController(BizBookInventoryContext db, ILogger<SmsHookController> logger) : base(new ServiceLibrary.BaseService<SmsHook, SmsHookRequestModel, SmsHookViewModel>(new BaseRepository<SmsHook>(db)), logger)
        {
        }
    }
}
