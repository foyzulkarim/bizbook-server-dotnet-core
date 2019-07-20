using Microsoft.VisualStudio.TestTools.UnitTesting;
using RequestModel.Customers;
using RestSharp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ApiIntegrationTestProject
{
    [TestClass]
   public class CustomerQueryControllerTest
    {
        [TestMethod]
        public void CustomerQueryTest()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/CustomerQuery/Search", Method.POST, DataFormat.Json);
            var token = TestHelper.GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var model = new CustomerRequestModel("")
            {
                ShopId = "1"
            };

            model.ShopId.ShouldNotBeNullOrWhiteSpace();
            request.AddJsonBody(model);

            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
