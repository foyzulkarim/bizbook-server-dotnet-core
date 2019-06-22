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

namespace B2BCoreApi.Controllers.QueryControllers.Message
{
    [Route("api/SmsQuery")]
    public class SmsQueryController : BaseQueryController<Sms, MessageRequestModel, SmsViewModel>
    {
        public SmsQueryController(BizBookInventoryContext db, ILogger<SmsQueryController> logger) : base(new ServiceLibrary.BaseService<Sms, MessageRequestModel, SmsViewModel>(new BaseRepository<Sms>(db)), logger)
        {

        }
    }
}
