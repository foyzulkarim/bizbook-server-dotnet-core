using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using B2BCoreApi.Attributes;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using Newtonsoft.Json;
using RequestModel;
//using Serilog;
using ServiceLibrary;
using ViewModel;

namespace B2BCoreApi.Controllers
{
    [BizBookAuthorization]
    [ShopChildQuery]
    public class BaseQueryController<T, TRm, TVm> : Controller where T : Entity where TVm : BaseViewModel<T> where TRm : RequestModel<T>
    {
        public ILogger Logger;

        public ApplicationUser AppUser;
        private BizBookInventoryContext Db;
        protected BaseService<T, TRm, TVm> Service;
        protected string typeName = "";

        public BaseQueryController(BaseService<T, TRm, TVm> service, ILogger logger)
        {
            Service = service;
            typeName = typeof(T).Name;
            this.Logger = logger;
        }

        [Route("Search")]
        [ActionName("Search")]
        [HttpPost]
        public async Task<ActionResult<Tuple<List<TVm>, int>>> Search(TRm request)
        {
            try
            {
                //var reader = new StreamReader(Request.Body);
                //string s = reader.ReadToEnd();
                //TRm rm = JsonConvert.DeserializeObject<TRm>(s);
                //rm.ShopId = AppUser.ShopId;
                Tuple<List<TVm>, int> content = await Service.SearchAsync(request);
                return Ok(content);                
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
                return StatusCode(500, exception.Message);
            }
        }
        
        [Route("Dropdown")]
        [ActionName("Dropdown")]
        [HttpPost]
        public async Task<ActionResult> Dropdown(TRm request)
        {
            try
            {
                Tuple<List<DropdownViewModel>, int> content = await Service.GetDropdownListAsync(request);
                return Ok(content);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Exception occurred while trying to get Dropdown {TypeName} with Request {Request}", typeName, request);
                return StatusCode(500, exception.Message);
            }
        }

        [Route("Detail")]
        [ActionName("Detail")]
        public ActionResult<TVm> Detail(string id)
        {
            try
            {
                TVm content = Service.GetDetail(id);
                return Ok(content);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Exception occurred while trying to get Detail {TypeName} with Request {Id}", typeName, id);
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPost]
        [Route("SearchDetail")]
        [ActionName("SearchDetail")]
        public async Task<ActionResult<TVm>> SearchDetail(TRm request)
        {
            try
            {
                request.IsIncludeParents = true;
                Tuple<List<TVm>, int> content = await Service.SearchAsync(request);
                TVm vm = content.Item1.FirstOrDefault();
                return Ok(vm);                
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeName, request);
                return StatusCode(500, exception.Message);
            }
        }
    }
}