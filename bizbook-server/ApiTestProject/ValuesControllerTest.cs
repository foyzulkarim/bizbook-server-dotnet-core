using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Shouldly;

namespace ApiIntegrationTestProject
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void TestPostMethod()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/values", Method.POST, DataFormat.Json);
            string value = Guid.NewGuid().ToString();
            request.AddParameter("value", value);
            var response = client.Post(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var content = response.Content.Replace("\"", ""); // raw content as string
            content.ShouldNotBeNull();
            content.ShouldBe(value);
        }
    }
}
