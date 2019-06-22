using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace B2BCoreApi.Models
{
    [Serializable]
    public class ClientRequestModel
    {
        public string UserName { get; set; }
        public string ConnectionId { get; set; }

        public string BrowserName { get; set; }

        public string Platform { get; set; }

        public string RawUrl { get; set; }

        public string MobileDeviceModel { get; set; }

        public bool IsMobileDevice { get; set; }

        public string UserHostAddress { get; set; }

        public string ShopId { get; set; }

        public ClientRequestModel(ActionExecutingContext actionContext)
        {
            //var request = actionContext.ActionArguments["MS_HttpContext"];
            //var browser = request.Browser;
            //BrowserName = browser.Browser;
            //Platform = browser.Platform;
            //RawUrl = request.RawUrl;
            //UserHostAddress = request.UserHostAddress;
            //IsMobileDevice = browser.IsMobileDevice;
            //MobileDeviceModel = browser.MobileDeviceModel;
            //ConnectionId = request.Headers["ConnectionId"];
        }

    }
}