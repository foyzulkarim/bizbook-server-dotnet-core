using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Customers;
using ServiceLibrary.Customers;
using ViewModel.Customers;

//using ILogger = Serilog.ILogger;

namespace B2BCoreApi.Controllers.CommandControllers.Customers
{
    [Route("api/Customer")]
    public class CustomerController : BaseCommandController<Customer, CustomerRequestModel, CustomerViewModel>
    {
        public CustomerController(BizBookInventoryContext db, ILogger<CustomerController> logger) : base(
            new CustomerService(new BaseRepository<Customer>(db)), logger)
        {
            
        }
    }
}