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
    [Route("api/HookDetail")]
    public class HookDetailController : BaseCommandController<HookDetail, HookDetailRequestModel, HookDetailViewModel>
    {
        public HookDetailController(BizBookInventoryContext db, ILogger<HookDetailController> logger) : base(new ServiceLibrary.BaseService<HookDetail, HookDetailRequestModel, HookDetailViewModel>(new BaseRepository<HookDetail>(db)), logger)
        {
        }
    }
}
