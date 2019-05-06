using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using ServiceLibrary.Customers;
using Rm = RequestModel.Customers.CustomerRequestModel;
using M = Model.Model.Customer;
using Vm = ViewModel.Customers.CustomerViewModel;

namespace B2BCoreApi.Controllers.QueryControllers.Customers
{
    [Route("api/CustomerQuery")]
    public class CustomerQueryController : BaseQueryController<M, Rm, Vm>
    {
        private readonly CustomerService _service;

        public CustomerQueryController(BizBookInventoryContext db, ILogger<CustomerQueryController> logger) : base(new CustomerService(new BaseRepository<M>(db)), logger)
        {
            _service = (CustomerService)Service;
        }

        [Route("Barcode")]
        [ActionName("Barcode")]
        [HttpGet]
        public ActionResult GetBarcode()
        {
            string barcode = _service.GetBarcode(AppUser.ShopId);
            return Ok(barcode);
        }           
    }
}

