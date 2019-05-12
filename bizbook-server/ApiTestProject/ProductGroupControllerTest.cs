using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using B2BCoreApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
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
            ProductGroup model = new ProductGroup()
            {
                Name = "Group",
                IsActive = true
            };

            request.AddJsonBody(model);
            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
