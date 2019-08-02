using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
//using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace B2BCoreApi.Attributes
{
    public class ShopChildQueryAttribute : ActionFilterAttribute
    {
        public static ILogger logger;        

        public override Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            var appUser = actionContext.HttpContext.Items["AppUser"] as ApplicationUser;
            Stream requestBody = actionContext.HttpContext.Request.Body;
            var reader = new StreamReader(requestBody);
            string s = reader.ReadToEnd();
            var actionDescriptorParameters = actionContext.ActionDescriptor.Parameters;

            if (actionDescriptorParameters.Count > 0)
            {

                Type type = Type.GetType(actionDescriptorParameters[0].ParameterType.AssemblyQualifiedName);
                var deserializeObject = JsonConvert.DeserializeObject(s, type) ?? new System.Dynamic.ExpandoObject();
                actionContext.ActionArguments.Add("request", deserializeObject);
            } else {

                actionContext.ActionArguments.Add("request", new System.Dynamic.ExpandoObject());

            }


            if (appUser is ApplicationUser user)
            {
                dynamic controller = actionContext.Controller;
                controller.AppUser = appUser;
                ClientRequestModel client =
                    new ClientRequestModel(actionContext) { UserName = user.UserName, ShopId = user.ShopId };

                //string clientConnectionId = client.ConnectionId;
                Thread.SetData(Thread.GetNamedDataSlot("AppUser"), user);
                //logger.Debug("Query Request: {@Client} {ConnectionId}", client, clientConnectionId);
                bool containsKey = actionContext.ActionArguments.ContainsKey("request");
                if (containsKey)
                {
                    dynamic request = actionContext.ActionArguments["request"];
                    request.ShopId = user.ShopId;                   
                }
            }

            return base.OnActionExecutionAsync(actionContext, next);
        }
    }


}