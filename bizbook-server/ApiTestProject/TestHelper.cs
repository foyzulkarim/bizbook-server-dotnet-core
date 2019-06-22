using System.Net;
using B2BCoreApi.Controllers;
using Newtonsoft.Json;
using RestSharp;
using Shouldly;

namespace ApiIntegrationTestProject
{
    public class TestHelper
    {
        public static string GetToken()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/token", Method.POST, DataFormat.Json);
            LoginViewModel model = new LoginViewModel()
            {
                Username = $"admin@demo1.com",
                Password = "Pass@123"
            };

            request.AddJsonBody(model);
            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var content = response.Content;
            var o = JsonConvert.DeserializeObject<dynamic>(content);
            string oAccessToken = o["access_token"].ToString();
            return oAccessToken;
        }
    }
}