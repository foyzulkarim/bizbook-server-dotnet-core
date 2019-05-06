using System.Web.Http;
using Model;
using Rm = RequestModel.Customers.AddressRequestModel;
using M = Model.Model.Address;
using Vm = ViewModel.Customers.AddressViewModel;

namespace B2BCoreApi.Controllers.QueryControllers.Customers
{
    using System.IO;
    using System.Linq;

    //using CsvHelper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    //using Server.Inventory.Models;

    [Route("api/CustomerAddressQuery")]
    public class CustomerAddressQueryController : BaseQueryController<M, Rm, Vm>
    {
        public CustomerAddressQueryController(BizBookInventoryContext db, ILogger<CustomerAddressQueryController> logger) : base(new ServiceLibrary.BaseService<M, Rm, Vm>(new BaseRepository<M>(db)), logger)
        {
        }

        //[AllowAnonymous]
        //[Route("Locations")]
        //[ActionName("Locations")]
        //[HttpGet]
        //public IHttpActionResult GetLocations()
        //{
        //    string path = System.Web.HttpContext.Current.Request.MapPath("~\\Files\\locations.csv");
        //    CsvReader reader = CreateCsvReader(path);
        //    var locations = reader.GetRecords<Location>().ToList();
        //    return this.Ok(locations);
        //}

        //private static CsvReader CreateCsvReader(string filename)
        //{
        //    string readToEnd = "";
        //    using (StreamReader reader = File.OpenText(filename))
        //    {
        //        readToEnd = reader.ReadToEnd();
        //    }

        //    TextReader textReader = new StringReader(readToEnd);
        //    CsvReader csv = new CsvReader(textReader);
        //    return csv;
        //}
    }
}
