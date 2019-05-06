using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Message;
using ViewModel.Message;

namespace B2BCoreApi.Controllers.QueryControllers.Message
{
    [Route("api/SmsHistoryQuery")]
    public class SmsHistoryQueryController : BaseQueryController<SmsHistory, SmsHistoryRequestModel,SmsHistoryViewModel>
    {
        public SmsHistoryQueryController(BizBookInventoryContext db, ILogger<SmsHistoryQueryController> logger) : base(new ServiceLibrary.BaseService<SmsHistory, SmsHistoryRequestModel, SmsHistoryViewModel>(new BaseRepository<SmsHistory>(db)), logger)
        {
        }
    }
}
