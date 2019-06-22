using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Serilog;
using ServiceLibrary.Shops;
using ViewModel.Shops;
using Rm = RequestModel.Shops.ShopRequestModel;
using M = Model.Shops.Shop;

namespace B2BCoreApi.Controllers.QueryControllers.Shops
{
    [Authorize(Roles = "SuperAdmin")]
    [Route("api/ShopQuery")]
    public class ShopQueryController : Controller
    {
        public static ILogger Logger = Log.ForContext(typeof(ShopQueryController));

        ShopService shopService;

        public ShopQueryController(BizBookInventoryContext db)
        {
            shopService = new ShopService(new BaseRepository<M>(db));
        }

        [Route("Search")]
        [ActionName("Search")]
        [HttpPost]
        public async Task<ActionResult> Search(Rm request)
        {
            try
            {
                Tuple<List<ShopSuperAdminViewModel>, int> content = await shopService.SearchAsync(request);
                return Ok(content);
            }
            catch (Exception exception)
            {
                Logger.Fatal(exception, "Exception occurred while Searching {TypeName} with Request {Request}", typeof(ShopQueryController).ToString(), request);
                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }

        [Route("Dropdown")]
        [ActionName("Dropdown")]
        [HttpPost]
        public async Task<ActionResult> Dropdown(Rm request)
        {
            try
            {
                var content = await shopService.GetDropdownListAsync(request);
                return Ok(content);
            }
            catch (Exception exception)
            {
                Logger.Fatal(
                    exception,
                    "Exception occurred while trying to get Dropdown {TypeName} with Request {Request}",
                    typeof(ShopQueryController).ToString(),
                    request);
                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }

        [Route("Detail")]
        [ActionName("Detail")]
        public ActionResult Detail(string id)
        {
            try
            {
                var content = shopService.GetDetail(id);
                return Ok(content);
            }
            catch (Exception exception)
            {
                Logger.Fatal(exception, "Exception occurred while trying to get Detail {TypeName} with Request {Id}", typeof(ShopQueryController).ToString(), id);
                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }
    }
}