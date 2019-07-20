using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model.Customers;
using RestSharp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ApiIntegrationTestProject
{
    [TestClass]
  public class CustomerControllerTest
    {
        [TestMethod]
        public void CustomerAddTest()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/Customer/Add", Method.POST, DataFormat.Json);
            var token = TestHelper.GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var model = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "1",
                ModifiedBy = "1",
                CreatedFrom = "Test",
                IsActive = true,
                ShopId = "1",
                Name = $"Customer-{DateTime.Now:ssmmhhddMMyyyy}",
                MembershipCardNo= Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                OrdersCount = 0,
                ProductAmount = 0,
                OtherAmount = 0,
                TotalDiscount = 0,
                TotalAmount = 0,
                TotalPaid = 0,
                TotalDue = 0,
                WcId = 1,


            };

            model.Name.ShouldNotBeNullOrWhiteSpace();
            model.MembershipCardNo.ShouldNotBeNullOrWhiteSpace();
            model.Phone.ShouldNotBeNullOrWhiteSpace();
            model.OrdersCount.ShouldNotBeNull();
            model.ProductAmount.ShouldNotBeNull();
            model.OtherAmount.ShouldNotBeNull();
            model.TotalDiscount.ShouldNotBeNull();
            model.TotalAmount.ShouldNotBeNull();
            model.TotalPaid.ShouldNotBeNull();
            model.TotalDue.ShouldNotBeNull();
            model.WcId.ShouldNotBeNull();

            request.AddJsonBody(model);

            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}

