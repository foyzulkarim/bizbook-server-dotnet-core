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

namespace B2BCoreApi.Controllers.CommandControllers.Message
{
    [Route("api/SmsHistory")]
    public class SmsHistoryController : BaseCommandController<SmsHistory, SmsHistoryRequestModel, SmsHistoryViewModel>
    {
        public SmsHistoryController(BizBookInventoryContext db, ILogger<SmsHistoryController> logger) : base(new ServiceLibrary.BaseService<SmsHistory, SmsHistoryRequestModel, SmsHistoryViewModel>(new BaseRepository<SmsHistory>(db)), logger)
        {

        }       
    }
}
