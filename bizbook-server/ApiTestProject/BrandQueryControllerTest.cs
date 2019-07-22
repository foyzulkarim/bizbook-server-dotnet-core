using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model.Products;
using RequestModel.Shops;
using RestSharp;
using Shouldly;

namespace ApiIntegrationTestProject
{
    [TestClass]
    public class BrandQueryControllerTest
    {
        [TestMethod]
        public void BrandQueryTest()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/BrandQuery/Search", Method.POST, DataFormat.Json);
            var token = TestHelper.GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var model = new BrandRequestModel("")
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
