using System;
using System.Net;
using System.Security.Claims;
using System.Threading;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Protocols;
using Model.Model;
using Serilog;

namespace B2BCoreApi.Attributes
{
    public class EntitySaveFilterAttribute : ActionFilterAttribute , IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            object data = actionContext;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var data = actionContext.ActionArguments["model"];
            //Log.Logger.Debug("Save request: Data {@Data}", data);
            var appUser = actionContext.HttpContext.Items["AppUser"] as ApplicationUser;
            //bool tryGetValue = actionContext.ActionArguments.TryGetValue("AppUser", out appUser);
            bool tryGetValue = appUser != null;

            if (tryGetValue && data != null)
            {
                string username = appUser.UserName;               
                {
                    var isEntity = data is Entity;
                    Entity entity = data as Entity;
                    if (isEntity)
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        entity.Created = DateTime.Now;
                        entity.Modified = DateTime.Now;
                        entity.CreatedBy = username;
                        entity.ModifiedBy = username;
                        entity.IsActive = true;
                    }
                }

                var isShopChild = data is ShopChild;
                if (isShopChild)
                {
                    var shopChild = data as ShopChild;
                    shopChild.ShopId = appUser.ShopId;
                }

                ClientRequestModel client =
                    new ClientRequestModel(actionContext) { UserName = username, ShopId = appUser.ShopId };
                string clientConnectionId = client.ConnectionId;
                Thread.SetData(Thread.GetNamedDataSlot("ConnectionId"), clientConnectionId);
                appUser.ConnectionId = clientConnectionId;              
                Log.Logger.Debug("Client details: {@Client} ", client);

                dynamic controller = actionContext.Controller;
                controller.AppUser = appUser;
            }
            else
            {
                actionContext.Result = new BadRequestResult();
            }
        }

      
    }
}