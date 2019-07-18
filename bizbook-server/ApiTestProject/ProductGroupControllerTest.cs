using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using B2BCoreApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using Model.Model.Products;
using RestSharp;
using Shouldly;

namespace ApiIntegrationTestProject
{
    [TestClass]
    public class ProductGroupControllerTest
    {
        [TestMethod]
        public void ProductGroupAddTest()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/ProductGroup/Add", Method.POST, DataFormat.Json);
            var token = TestHelper.GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            ProductGroup model = new ProductGroup()
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "1",
                ModifiedBy = "1",
                CreatedFrom = "Test",
                IsActive = true,
                ShopId = "1",
                Name = $"ProductGroup-{DateTime.Now:ssmmhhddMMyyyy}",
            };

            request.AddJsonBody(model);
            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
