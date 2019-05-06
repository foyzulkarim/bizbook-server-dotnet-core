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
using RequestModel.Warehouses;
using ViewModel.Warehouses;

namespace B2BCoreApi.Controllers.QueryControllers.Warehouses
{
    [Route("api/DamageQuery")]
    public class DamageQueryController : BaseQueryController<Damage,DamageRequestModel,DamageViewModel>
    {
        public DamageQueryController(BizBookInventoryContext db, ILogger<DamageQueryController> logger) : base(new ServiceLibrary.BaseService<Damage, DamageRequestModel, DamageViewModel>(new BaseRepository<Damage>(db)), logger)
        {
        }
    }
}
