//using CommonLibrary.Repository;

//using ServiceLibrary.Sales;
//using WcConverter;
//using WcModel;

namespace B2BCoreApi.Controllers.CommandControllers.Wc
{
    //using Microsoft.AspNet.SignalR;

    //using Server.Inventory.Attributes;
    //using Server.Inventory.Helpers;

    // [HmacSignatureFilter]
    //[AllowAnonymous]
    //[RoutePrefix("api/WcHook")]
    //public class WcHookController : ApiController
    //{
    //    public static ILogger Logger = Log.ForContext(typeof(WcHookController));

    //    [HttpGet]
    //    [Route("GetValue")]
    //    [ActionName("GetValue")]
    //    public IHttpActionResult GetValue()
    //    {
    //        Logger.Debug("GetValue API Called. ");
    //        return this.Ok(DateTime.Now);
    //    }

    //    [HttpPost]
    //    [Route("PostValue")]
    //    public IHttpActionResult PostValue()
    //    {
    //        string result = this.Request.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    //        //string s = JsonConvert.SerializeObject(o);
    //        Logger.Debug("Post value api called" + result);            
    //        return Ok(DateTime.Now);
    //    }

    //    [HmacSignatureFilter]
    //    [HttpPost]
    //    [Route("ProductCreated")]
    //    [ActionName("ProductCreated")]
    //    public IHttpActionResult ProductCreated([FromBody] WcProduct wcProduct)
    //    {
    //        Logger.Debug($"ProductCreated: {wcProduct.id}");

    //        List<ProductDetail> productDetails = wcProduct.GetProductDetails();
    //        BusinessDbContext db = BusinessDbContext.Create();
    //        Shop shop = GetShop(db);
    //        BaseRepository<ProductDetail> repository = new BaseRepository<ProductDetail>(db);
    //        ProductDetailService service = new ProductDetailService(repository);
    //        foreach (ProductDetail detail in productDetails)
    //        {
    //            detail.ShopId = shop.Id;
    //            detail.ModifiedBy = this.GetSource();
    //            detail.CreatedBy = this.GetSource();
    //            var productDetail = service.GetProductDetailFromWcProductDetail(detail, db);
    //            if (productDetail != null)
    //            {
    //                bool isSaved = service.AddWcProductDetail(productDetail, db);
    //            }
    //            else
    //            {
    //                return this.BadRequest("Product exists");
    //            }
    //        }

    //        return this.Ok(true);
    //    }

    //    [HmacSignatureFilter]
    //    [HttpPost]
    //    [Route("ProductUpdated")]
    //    [ActionName("ProductUpdated")]
    //    public IHttpActionResult ProductUpdated([FromBody] WcProduct wcProduct)
    //    {
    //        Logger.Debug("ProductUpdated: ");

    //        List<ProductDetail> productDetails = wcProduct.GetProductDetails();
    //        BusinessDbContext db = BusinessDbContext.Create();
    //        Shop shop = GetShop(db);
    //        BaseRepository<ProductDetail> repository = new BaseRepository<ProductDetail>(db);
    //        ProductDetailService service = new ProductDetailService(repository);
    //        foreach (ProductDetail detail in productDetails)
    //        {
    //            detail.ShopId = shop.Id;
    //            detail.ModifiedBy = this.GetSource();
    //            detail.CreatedBy = this.GetSource();
    //            var productDetail = service.GetProductDetailFromWcProductDetail(detail, db);
    //            if (productDetail == null)
    //            {
    //                bool isSaved = service.AddWcProductDetail(detail, db);
    //            }
    //        }

    //        return this.Ok(true);
    //    }

    //   // [HmacSignatureFilter]
    //    [HttpPost]
    //    [Route("OrderCreated")]
    //    [ActionName("OrderCreated")]
    //    public IHttpActionResult OrderCreated([FromBody] WcOrder wcOrder)
    //    {
    //        Logger.Debug("OrderCreated: ");
    //        Logger.Debug(JsonConvert.SerializeObject(wcOrder));
    //        BusinessDbContext db = BusinessDbContext.Create();
    //        SaleService saleService = new SaleService(new BaseRepository<Sale>(db));
    //        Shop shop = GetShop(db);
    //        Sale wcSale = wcOrder.GetSale();
    //        wcSale.ShopId = shop.Id;
    //        wcSale.ModifiedBy = this.GetSource();
    //        wcSale.CreatedBy = this.GetSource();
    //        Sale sale = saleService.GetSaleFromWcSale(wcSale);
    //        if (sale == null)
    //        {
    //            return this.BadRequest("Sale exists");
    //        }

    //        bool add = saleService.Add(sale);
    //        if (add)
    //        {
    //            string connections = RedisService.GetValue(RedisKeys.Connections);
    //            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, ConnectionModel>>(connections);
    //            List<ConnectionModel> connectionModels = dictionary.Values.ToList();
    //            var connectionIds = connectionModels.Where(x => x.ShopId == shop.Id).Select(y => y.ConnectionId).ToList();
    //            var hub = GlobalHost.ConnectionManager.GetHubContext("NotificationHub");
    //            Microsoft.AspNet.SignalR.Hubs.MultipleSignalProxy clients = hub.Clients.Clients(connectionIds);
    //            clients.Invoke("orderCreated", "New order created.");
    //        }

    //        return this.Ok(add);
    //    }

    //    private bool IsAllowed(object o)
    //    {
    //        var byteContent = ObjectToByteArray(o);
    //        //var byteContent = this.Request.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
    //        var bodyHash = HashHMAC("123", byteContent);
    //        var signature = Request.Headers.GetValues("x-wc-webhook-signature");

    //        if (bodyHash != signature.FirstOrDefault())
    //        {
    //            throw new HttpResponseException(HttpStatusCode.Forbidden);
    //        }

    //        return true;
    //    }

    //    public static byte[] ObjectToByteArray(Object obj)
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        using (var ms = new MemoryStream())
    //        {
    //            bf.Serialize(ms, obj);
    //            return ms.ToArray();
    //        }
    //    }

    //    private static string HashHMAC(string key, byte[] message)
    //    {
    //        var keyBytes = Encoding.UTF8.GetBytes(key);
    //        var hash = new HMACSHA256(keyBytes);

    //        var computedHash = hash.ComputeHash(message);
    //        return Convert.ToBase64String(computedHash);
    //    }

    //    private Shop GetShop(BusinessDbContext db)
    //    {
    //        string source = this.GetSource();
    //        Shop shop = db.Shops.FirstOrDefault(x => x.WcWebhookSource == source);
    //        if (shop == null)
    //        {
    //            throw new KeyNotFoundException("Invalid source");
    //        }

    //        return shop;
    //    }

    //    private string GetSource()
    //    {
    //        object sourceObj;
    //        this.Request.Properties.TryGetValue("Source", out sourceObj);
    //        string source = sourceObj.ToString();
    //        return source;
    //    }
    //}
}
