using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model.Products;
using RestSharp;
using Shouldly;

namespace ApiIntegrationTestProject
{
    [TestClass]
    public class BrandControllerTest
    {
        [TestMethod]
        public void BrandAddTest()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/Brand/Add", Method.POST, DataFormat.Json);
            var token = TestHelper.GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var model = new Brand()
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "1",
                ModifiedBy = "1",
                CreatedFrom = "Test",
                IsActive = true,
                ShopId = "1",
                Name = $"Brand-{DateTime.Now:ssmmhhddMMyyyy}",
                BrandCode = ""
            };

            model.Name.ShouldNotBeNullOrWhiteSpace();
            request.AddJsonBody(model);

            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
