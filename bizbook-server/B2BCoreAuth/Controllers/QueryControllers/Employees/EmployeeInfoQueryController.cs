using Model.Model;
using RequestModel.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel.Employees;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace B2BCoreApi.Controllers.QueryControllers.Employees
{
    [Route("api/EmployeeInfoQuery")]
    public class EmployeeInfoQueryController : BaseQueryController<EmployeeInfo, EmployeeInfoRequestModel, EmployeeInfoViewModel>
    {
        public EmployeeInfoQueryController(BizBookInventoryContext db, ILogger<EmployeeInfoQueryController> logger) : base(new ServiceLibrary.BaseService<EmployeeInfo, EmployeeInfoRequestModel, EmployeeInfoViewModel>(new BaseRepository<EmployeeInfo>(db)), logger)
        {

        }
    }
}
