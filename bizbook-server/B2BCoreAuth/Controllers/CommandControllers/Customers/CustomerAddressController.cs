using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Model;
using RequestModel.Customers;
using ViewModel.Customers;

namespace B2BCoreApi.Controllers.CommandControllers.Customers
{
    [Route("api/CustomerAddress")]
    public class CustomerAddressController : BaseCommandController<Address,AddressRequestModel,AddressViewModel>
    {
        public CustomerAddressController(BizBookInventoryContext db, ILogger<CustomerAddressController> logger) : base(new ServiceLibrary.BaseService<Address, AddressRequestModel, AddressViewModel>(new BaseRepository<Address>(db)), logger)
        {
        }
    }
}
