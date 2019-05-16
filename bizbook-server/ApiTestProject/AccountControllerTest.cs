using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using B2BCoreApi.Controllers;
using B2BCoreApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Shouldly;

namespace ApiIntegrationTestProject
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestRegister()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/Account/Register", Method.POST, DataFormat.Json);
            string suffix = DateTime.Now.ToString("ddMMyyhhmmss");
            RegisterBindingModel model = new RegisterBindingModel
            {
                Email = $"admin{suffix}@demo1.com",
                Password = "Password@123",
                ConfirmPassword = "Password@123",
                FirstName = "Admin",
                LastName = "Demo1",
                Phone = suffix
            };

            request.AddJsonBody(model);
            var response = client.Execute(request);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [TestMethod]
        public void TestGetToken()
        {
            var client = new RestClient(Constants.BaseUrl);
            var request = new RestRequest("api/token", Method.POST, DataFormat.Json);
            LoginViewModel model = new LoginViewModel()
            {
                Username = $"admin@demo1.com",
                Password = "Password@123"
            };

            request.AddJsonBody(model);
            var response = client.Execute(request);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
