using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace B2BCoreApi.Attributes
{
    public class BizBookAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal user = context.HttpContext.User;
                ApplicationUser appUser = new ApplicationUser()
                {
                    Id = user.Claims.First(x => x.Type == Helpers.Constants.Strings.JwtClaimIdentifiers.Id).Value,
                    ShopId = user.Claims.First(x => x.Type == Helpers.Constants.Strings.JwtClaimIdentifiers.ShopId).Value,
                    UserName = user.Claims.First(x => x.Type == Helpers.Constants.Strings.JwtClaimIdentifiers.UserName).Value
                };
                context.HttpContext.Items["AppUser"] = appUser;
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            //                controller.AppUser = user;
        }

        //protected override bool IsAuthorized(HttpActionContext actionContext)
        //{
        //    //return true;
        //    string bizbookserveridentity = ConfigurationManager<>.AppSettings["IdentityServer"];
        //    var request = actionContext.Request;
        //    string resourceName = request.RequestUri.AbsolutePath;
        //    var last = resourceName.Split(new string[] { "/api" }, StringSplitOptions.RemoveEmptyEntries).Last();
        //    resourceName = "/api" + last;
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Authorization = request.Headers.Authorization;
        //        PermissionRequest permissionRequest = new PermissionRequest { Name = resourceName };
        //        string url = bizbookserveridentity + "api/Authorization/Authorize";
        //        var responseMessage = client.PostAsJsonAsync(url, permissionRequest).Result;
        //        string result = responseMessage.Content.ReadAsStringAsync().Result;

        //        bool isAuthorized = responseMessage.StatusCode == HttpStatusCode.OK;
        //        if (isAuthorized)
        //        {
        //            ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(result);
        //            if (user != null)
        //            {
        //                actionContext.Request.Properties.Add("AppUser", user);
        //                dynamic controller = actionContext.ControllerContext.Controller;
        //                controller.AppUser = user;
        //            }
        //        }

        //        return isAuthorized;
        //    }
        //}

    }
}