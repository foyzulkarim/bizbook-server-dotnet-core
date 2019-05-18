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
    public class EmployeeInfoQueryController : BaseQueryController<Employee, EmployeeInfoRequestModel, EmployeeViewModel>
    {
        public EmployeeInfoQueryController(BizBookInventoryContext db, ILogger<EmployeeInfoQueryController> logger) : base(new ServiceLibrary.BaseService<Employee, EmployeeInfoRequestModel, EmployeeViewModel>(new BaseRepository<Employee>(db)), logger)
        {

        }
    }
}
