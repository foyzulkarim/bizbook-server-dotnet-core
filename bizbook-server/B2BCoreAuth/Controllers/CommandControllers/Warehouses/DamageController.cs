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

namespace B2BCoreApi.Controllers.CommandControllers.Warehouses
{
    [Route("api/Damage")]
    public class DamageController : BaseCommandController<Damage,DamageRequestModel,DamageViewModel>
    {
        public DamageController(BizBookInventoryContext db, ILogger<DamageController> logger) : base(new ServiceLibrary.BaseService<Damage, DamageRequestModel, DamageViewModel>(new BaseRepository<Damage>(db)), logger)
        {
        }
    }
}
