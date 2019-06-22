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
    [Route("api/Sms")]
    public class SmsController : BaseCommandController<Sms, SmsRequestModel, SmsViewModel>
    {
        public SmsController(BizBookInventoryContext db, ILogger<SmsController> logger) : base(new ServiceLibrary.BaseService<Sms, SmsRequestModel, SmsViewModel>(new BaseRepository<Sms>(db)), logger)
        {
        }
    }
}
