//using System;
//using System.Collections.Generic;
////using System.Data.Entity.Validation;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using Model.Model;
//using Serilog;

//namespace Server.Inventory.Controllers.CommandControllers.Sales
//{
//    //using System.Data.Entity;
//    using System.Security;
//    using System.Threading.Tasks;
//    using Microsoft.AspNetCore.Mvc;

//    //using CommonLibrary.Repository;

//    //using ExternalModel;

//    using Model;
//    using Model.Model;
    

//    using Newtonsoft.Json;

//    using RequestModel.Sales;

//    using Serilog.Core;

//   // using Server.Inventory.Filters;

//    using ServiceLibrary.Customers;
//    using ServiceLibrary.Products;
//    using ServiceLibrary.Sales;
//    using ServiceLibrary.Transactions;

//    using ViewModel.Sales;

//    [Route("api/ExternalSale")]
//    public class ExternalSaleController : ApiController
//    {
//        public static ILogger Logger = Log.ForContext(typeof(ExternalSaleController));
//        [HttpPost]
//        [Route("EvAdd")]
//        [ActionName("EvAdd")]
//        [AllowAnonymous]
//        public IHttpActionResult EvAdd([FromBody] EvSale2 model)
//        {
//            // Logger.Debug("EvAdd : ");
//            string o = JsonConvert.SerializeObject(model);
//            // Logger.Debug(o);
//            if (string.IsNullOrWhiteSpace(model.id))
//            {
//                return this.BadRequest("Model Id not found. Model : " + o);
//            }

//            if (model.billingInfo == null)
//            {
//                return this.BadRequest("BillingInfo not found");
//            }

//            if (string.IsNullOrWhiteSpace(model.billingInfo.blling_name))
//            {
//                return this.BadRequest("BillingInfo Billing name not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.billingInfo.blling_phone))
//            {
//                return this.BadRequest("BillingInfo Billing phone not found. Model : " + o);
//            }


//            //shopingCart

//            if (model.shoppingCart == null)
//            {
//                return this.BadRequest("ShoppingCart not found");
//            }

//            foreach (var cart in model.shoppingCart)
//            {
//                if (cart == null)
//                {
//                    return this.BadRequest("ShoppingCart cart not found");
//                }

//                if (string.IsNullOrWhiteSpace(cart.productId))
//                {
//                    return this.BadRequest("ShoppingCart productId not found. Model: " + o);
//                }

//                if (string.IsNullOrWhiteSpace(cart.productName))
//                {
//                    return this.BadRequest("ShoppingCart Product Name not found. Model: " + o);
//                }

//                if (string.IsNullOrWhiteSpace(cart.productSlug))
//                {
//                    return this.BadRequest("ShoppingCart ProductSlug not found.Model: " + o);
//                }

//                if (cart.price == 0)
//                {
//                    return this.BadRequest("ShoppingCart price not found. Model: " + o);
//                }

//                if (cart.quantity == 0)
//                {
//                    return this.BadRequest("ShoppingCart Quantity not found. Model: " + o);
//                }

//                foreach (var category in cart.multi_category)
//                {
//                    if (category == null)
//                    {
//                        return BadRequest("ShoppingCart Multicategory category is null. Model : " + o);
//                    }

//                    if (string.IsNullOrWhiteSpace(category.categoryId))
//                    {
//                        return this.BadRequest("ShoppingCart Multicategory Category Id not found. Model: " + o);
//                    }

//                    if (string.IsNullOrWhiteSpace(category.categorySlug))
//                    {
//                        return this.BadRequest("ShoppingCart Multicategory CategorySlug not found. Model: " + o);
//                    }

//                    if (category.categoryVal == false)
//                    {
//                        return this.BadRequest("ShoppingCart CategoryVal not found. Model: " + o);
//                    }
//                }
//            }

//            //Order summary
//            if (model.orderSummary == null)
//            {
//                return this.BadRequest("OrderSummary not found.");
//            }

//            if (string.IsNullOrWhiteSpace(model.orderSummary.totalprice.ToString()))
//            {
//                return this.BadRequest("OrderSummary Total price not found. Model : " + o);
//            }

//            if (model.orderSummary.grandtotal == 0)
//            {
//                return this.BadRequest("OrderSummary GrandTotal not found. Model : " + o);
//            }

//            if (CheckIfHeaderMissing())
//            {
//                return this.BadRequest("Header missing or invalid header value");
//            }

//            try
//            {
//                BusinessDbContext db = BusinessDbContext.Create();
//                SaleService Service = new SaleService(new BaseRepository<Sale>(db));

//                var response = new List<dynamic>();
//                {
//                    Sale sale1 = GetSaleFromEv2(model);
//                    if (sale1 == null)
//                    {
//                        return BadRequest("Couldnt parse the sale from provided model");
//                    }

//                    List<Sale> sales = new List<Sale> { };
//                    if (model.deliveryInfo.deliveryType == "Subscription")
//                    {
//                        var newTotal = model.orderSummary.grandtotal / model.deliveryInfo.deliveryDays.Length;
//                        foreach (var deliveryDay in model.deliveryInfo.deliveryDays)
//                        {
//                            var temp = JsonConvert.SerializeObject(sale1);
//                            Sale sale = JsonConvert.DeserializeObject<Sale>(temp);
//                            sale.Id = Guid.NewGuid().ToString();
//                            sale.IsActive = true;
//                            sale.RequiredDeliveryDateByCustomer = Convert.ToDateTime(deliveryDay);
//                            sale.TotalAmount = newTotal;
//                            sale.PayableTotalAmount = newTotal;
//                            sale.DueAmount = newTotal;
//                            sales.Add(sale);
//                        }
//                    }
//                    else
//                    {
//                        sales.Add(sale1);
//                    }

//                    foreach (Sale s in sales)
//                    {
//                        bool exists = db.Sales.Any(x => x.Id == s.Id);
//                        if (!exists)
//                        {
//                            var add = Service.Add(s);
//                            var content = new { s.Id, s.OrderNumber, s.OrderReferenceNumber };
//                            response.Add(content);
//                        }
//                        else
//                        {
//                            return BadRequest("This Sale Id is already saved in database");
//                        }
//                    }
//                }

//                return Ok(response);
//            }
//            catch (DbEntityValidationException validationException)
//            {
//                var exceptionMessage = PrepareValidationExceptionMessage(model, validationException);
//                return BadRequest(exceptionMessage);
//            }
//            catch (Exception exception)
//            {
//                var s = exception.ToString();
//                return BadRequest(s);
//            }
//        }

//        private string PrepareValidationExceptionMessage(object model, DbEntityValidationException validationException)
//        {
//            List<string> messages = new List<string>();
//            IEnumerable<DbEntityValidationResult> entityValidationErrors = validationException.EntityValidationErrors;
//            foreach (var validationError in entityValidationErrors)
//            {
//                IEnumerable<string> enumerable = validationError.ValidationErrors.ToList().Select(
//                    x => $"{validationError.Entry.Entity.ToString()} - {x.PropertyName} - {x.ErrorMessage}");
//                var error = new { ValidationErrors = enumerable };
//                messages.Add(JsonConvert.SerializeObject(error));
//            }

//            StringBuilder builder = new StringBuilder();
//            foreach (string message in messages)
//            {
//                builder.Append(message);
//            }

//            string actualModel = JsonConvert.SerializeObject(model);
//            string exceptionMessage = string.Concat(
//                validationException.Message,
//                "Validation errors are : ",
//                builder.ToString(),
//                ". Actual Model found: " + actualModel);
//            return exceptionMessage;
//        }

//        private bool CheckIfHeaderMissing()
//        {
//            bool headerMissing = false;
//            string header = "x-bizbook-security-header";
//            if (Request.Headers.Any(x => x.Key == header))
//            {
//                var pair = this.Request.Headers.First(x => x.Key == header);
//                string value = pair.Value.FirstOrDefault();
//                if (string.IsNullOrWhiteSpace(value))
//                {
//                    headerMissing = true;
//                }

//                BusinessDbContext db = BusinessDbContext.Create();
//                Shop kf = db.Shops.First(x => x.Name == "Khaas Food");
//                if (kf.WcSecret != value)
//                {
//                    headerMissing = true;
//                }
//            }
//            else
//            {
//                headerMissing = true;
//            }

//            return headerMissing;
//        }

//        private Sale GetSaleFromEv2(EvSale2 evSale)
//        {
//            BusinessDbContext db = BusinessDbContext.Create();

//            #region sale model prepare
//            string shopId = "35574125-3609-49de-a607-ae27788f3b56";
//            string brandId = "d0ef0e14-2b09-43c5-9aea-e3b838f676e8";
//            const string KhaasfoodCom = "khaasfood.com";
//            const string EvKhaasfoodCom = "ev@khaasfood.com";
//            const string productGroupId = "fcf766c3-368a-4603-80f9-9bab5f913ca3";

//            Sale bSale = new Sale();
//            bSale.ShopId = shopId;
//            bSale.CreatedBy = KhaasfoodCom;
//            bSale.ModifiedBy = KhaasfoodCom;
//            bSale.CreatedFrom = KhaasfoodCom;
//            bSale.SaleFrom = SaleFrom.Website;
//            // prepare sale object 
//            bSale.Id = evSale.id;
//            bSale.Modified = DateTime.Now;
//            bSale.Created = DateTime.Now;
//            bSale.IsActive = true;
//            bSale.OrderState = OrderState.Pending;
//            bSale.OrderNumber = Guid.NewGuid().ToString();
//            bSale.OrderReferenceNumber = evSale.id;

//            bSale.RequiredDeliveryDateByCustomer = evSale.deliveryInfo.deliveryDay;
//            bSale.RequiredDeliveryTimeByCustomer = evSale.deliveryInfo.deliveryTime;

//            bSale.OrderDate = evSale.deliveryInfo.deliveryDay;

//            //// prepare customer

//            Customer dbCustomer;
//            var dbCustomers = db.Customers.Where(x => x.ShopId == shopId).AsQueryable();
//            if (evSale.userInfo == null || string.IsNullOrWhiteSpace(evSale.userInfo.userId))
//            {
//                dbCustomer = dbCustomers.FirstOrDefault(x => x.Phone == evSale.billingInfo.blling_phone);
//            }
//            else
//            {
//                dbCustomer = dbCustomers.FirstOrDefault(x => x.Id == evSale.userInfo.userId);
//            }

//            if (dbCustomer == null)
//            {
//                CustomerService customerService = new CustomerService(new BaseRepository<Customer>(db));
//                var barCode = customerService.GetBarcode(shopId);
//                dbCustomer = new Customer()
//                {
//                    Id = evSale.userInfo != null && !string.IsNullOrWhiteSpace(evSale.userInfo.userId) ? evSale.userInfo.userId : Guid.NewGuid().ToString(),
//                    Created = DateTime.Now,
//                    Modified = DateTime.Now,
//                    Email = evSale.userInfo != null && !string.IsNullOrWhiteSpace(evSale.userInfo.email) ? evSale.userInfo.email : string.Empty,
//                    Name = evSale.billingInfo.blling_name,
//                    Phone = evSale.billingInfo.blling_phone,
//                    MembershipCardNo = barCode,
//                    CreatedBy = EvKhaasfoodCom,
//                    CreatedFrom = KhaasfoodCom,
//                    IsActive = true,
//                    ModifiedBy = EvKhaasfoodCom,
//                    ShopId = shopId,
//                };
//                db.Customers.Add(dbCustomer);
//                db.SaveChanges();
//            }

//            bSale.CustomerName = evSale.billingInfo.blling_name;
//            bSale.CustomerPhone = evSale.billingInfo.blling_phone;
//            bSale.CustomerId = dbCustomer.Id;

//            //// prepare sale address 
//            var address = new Address
//            {
//                AddressName = "Shipping",
//                Id = Guid.NewGuid().ToString(),
//                Created = DateTime.Now,
//                Modified = DateTime.Now,
//                CreatedBy = EvKhaasfoodCom,
//                ModifiedBy = EvKhaasfoodCom,
//                CreatedFrom = KhaasfoodCom,
//                IsActive = true,
//                ShopId = shopId,
//                ContactName = evSale.billingInfo.blling_name,
//                ContactPhone = evSale.billingInfo.blling_phone,
//                Area = evSale.shippingInfo.shiping_zone,
//                District = evSale.shippingInfo.shiping_city,
//                PostCode = evSale.shippingInfo.shiping_zipCode,
//                Country = "Bangladesh",
//                StreetAddress =
//                                      string.Format(
//                                          $"{evSale.shippingInfo.shiping_address} {evSale.shippingInfo.shiping_zone} {evSale.shippingInfo.shiping_city} {evSale.shippingInfo.shiping_zipCode}"),
//                IsDefault = true,
//                CustomerId = bSale.CustomerId
//            };
//            bSale.Address = address;

//            bSale.SaleDetails = new List<SaleDetail>();
//            foreach (EvShoppingCart2 ed in evSale.shoppingCart)
//            {
//                EvMultiCatagory2 catagory2 = ed.multi_category.FirstOrDefault();
//                string categoryId = catagory2.categoryId;
//                ProductCategory category = db.ProductCategories.FirstOrDefault(x => x.ShopId == shopId && x.Id == categoryId);
//                if (category == null)
//                {
//                    category = new ProductCategory()
//                    {
//                        CreatedBy = EvKhaasfoodCom,
//                        ModifiedBy = EvKhaasfoodCom,
//                        CreatedFrom = KhaasfoodCom,
//                        ShopId = shopId,
//                        IsActive = true,
//                        Id = categoryId,
//                        Created = DateTime.Now,
//                        Modified = DateTime.Now,
//                        Name = string.IsNullOrWhiteSpace(catagory2.categorySlug)
//                                                  ? "Unknown"
//                                                  : catagory2.categorySlug,
//                        ProductGroupId = productGroupId
//                    };
//                    db.ProductCategories.Add(category);
//                    db.SaveChanges();
//                }

//                ProductDetailService productService = new ProductDetailService(new BaseRepository<ProductDetail>(db));
//                ProductDetail detail = db.ProductDetails.FirstOrDefault(x => x.ShopId == shopId && x.Id == ed.productId);
//                if (detail == null)
//                {
//                    string barCode = productService.GetBarcode2(shopId);
//                    detail = new ProductDetail()
//                    {
//                        CreatedBy = EvKhaasfoodCom,
//                        ModifiedBy = EvKhaasfoodCom,
//                        CreatedFrom = KhaasfoodCom,
//                        ShopId = shopId,
//                        IsActive = true,
//                        Id = ed.productId,
//                        Created = DateTime.Now,
//                        Modified = DateTime.Now,
//                        Name = string.Format($"{ed.productName} ({ed.productSlug})"),
//                        ProductCode = GetProductCode(ed.productSlug),
//                        BarCode = barCode,
//                        BrandId = brandId,
//                        CostPrice = 0,
//                        DealerPrice = 0,
//                        HasExpiryDate = true,
//                        OnHand = 0,
//                        ProductCategoryId = category.Id,
//                        SalePrice = ed.price,
//                    };

//                    db.ProductDetails.Add(detail);
//                    db.SaveChanges();
//                }

//                SaleDetail saleDetail = new SaleDetail
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    Created = DateTime.Now,
//                    Modified = DateTime.Now,
//                    CreatedBy = EvKhaasfoodCom,
//                    ModifiedBy = EvKhaasfoodCom,
//                    CreatedFrom = KhaasfoodCom,
//                    IsActive = true,
//                    ShopId = shopId,
//                    SalePricePerUnit = ed.discountPrice > 0 ? ed.discountPrice : ed.price,
//                    Quantity = ed.quantity,
//                    ProductDetailId = detail.Id,
//                    SaleId = evSale.id,
//                };
//                saleDetail.PriceTotal = saleDetail.SalePricePerUnit * saleDetail.Quantity;
//                saleDetail.Total = saleDetail.PriceTotal;
//                bSale.SaleDetails.Add(saleDetail);
//            }

//            // warehouse assign
//            SetWarehouseId(db, bSale);

//            //// complete sale object
//            bSale.DeliveryChargeAmount = evSale.orderSummary.deliverycharge;
//            bSale.ProductAmount = evSale.orderSummary.totalDiscountPrice;
//            bSale.TotalAmount = evSale.orderSummary.grandtotal;
//            bSale.PayableTotalAmount = bSale.TotalAmount;
//            bSale.DueAmount = evSale.orderSummary.grandtotal;

//            //// end 

//            #endregion

//            bSale.Transactions = new List<Transaction>();


//            return bSale;
//        }

//        private static void SetWarehouseId(BusinessDbContext db, Sale bSale)
//        {
//            List<Warehouse> warehouses = db.Warehouses.Where(x => x.ShopId == bSale.ShopId).ToList();
//            if (!string.IsNullOrWhiteSpace(bSale.Address.Area) && !string.IsNullOrWhiteSpace(bSale.Address.District))
//            {
//                if (bSale.Address.District == "Dhaka")
//                {
//                    List<string> baddaList = new List<string>()
//                                                 {
//                                                     "Paltan",
//                                                     "Badda",
//                                                     "Banani",
//                                                     "Tejgaon I/A",
//                                                     "Malibag",
//                                                     "Motijheel",
//                                                     "Khilgaon",
//                                                     "Rampura",
//                                                     "Basabo",
//                                                     "Mohakhali",
//                                                     "Gulshan 1-2",
//                                                     "Sayedabad",
//                                                     "Jattrabari",
//                                                     "Kamalapur",
//                                                     "Shantinagar",
//                                                     "Kakrail",
//                                                     "Mogbazar",
//                                                     "Segunbagicha",
//                                                     "Wari",
//                                                     "Gulistan",
//                                                     "Rajarbag"
//                                                 };
//                    List<string> mohammadpurList = new List<string>()
//                                                       {
//                                                           "Old dhaka",
//                                                           "Mohakhali DOHS",
//                                                           "Mohammadpur",
//                                                           "Dhanmondi",
//                                                           "Dhaka University area",
//                                                           "Mirpur 1-14",
//                                                           "Kawranbazar",
//                                                           "Farmgate",
//                                                           "Nakhalpara",
//                                                           "Agargaon",
//                                                           "Shyamoli",
//                                                           "Kallyanpur",
//                                                           "Eskaton"
//                                                       };
//                    List<string> uttaraList = new List<string>()
//                                                  {
//                                                      "Basundhara",
//                                                      "Baridhara",
//                                                      "Uttara",
//                                                      "Khilkhet",
//                                                      "Nikunja",
//                                                      "Mirpur cantonment",
//                                                      "Dhaka cantonment",
//                                                      "Mirpur DOHS",
//                                                      "Balughat",
//                                                      "Manikdi",
//                                                      "Vashantek"
//                                                  };

//                    if (baddaList.Contains(bSale.Address.Area))
//                    {
//                        Warehouse warehouse = warehouses.FirstOrDefault(x => x.Name == "Badda");
//                        if (warehouse != null)
//                        {
//                            bSale.WarehouseId = warehouse.Id;
//                        }
//                    }

//                    if (mohammadpurList.Contains(bSale.Address.Area))
//                    {
//                        Warehouse warehouse = warehouses.FirstOrDefault(x => x.Name == "Mohammadpur");
//                        if (warehouse != null)
//                        {
//                            bSale.WarehouseId = warehouse.Id;
//                        }
//                    }

//                    if (uttaraList.Contains(bSale.Address.Area))
//                    {
//                        Warehouse warehouse = warehouses.FirstOrDefault(x => x.Name == "Uttara");
//                        if (warehouse != null)
//                        {
//                            bSale.WarehouseId = warehouse.Id;
//                        }
//                    }
//                }

//                if (bSale.Address.District == "Chittagong")
//                {

//                    List<string> ctgList = new List<string>()
//                                               {
//                                                   "Akbar Shah",
//                                                   "Bakalia",
//                                                   "Bayezid Bostami",
//                                                   "Chandgaon",
//                                                   "Chawkbazar",
//                                                   "Kotwali",
//                                                   "Double Mooring",
//                                                   "Halishahar",
//                                                   "Khulshi",
//                                                   "Pahartoli",
//                                                   "Panchlaish",
//                                                   "Sadarghat"
//                                               };

//                    if (ctgList.Contains(bSale.Address.Area))
//                    {
//                        Warehouse warehouse = warehouses.FirstOrDefault(x => x.Name == "Chittagong");
//                        if (warehouse != null)
//                        {
//                            bSale.WarehouseId = warehouse.Id;
//                        }
//                    }
//                }
//            }
//        }

//        private EvSale2 MangoConvert(Mango mango)
//        {
//            BusinessDbContext db = new BusinessDbContext();
//            string shopId = "35574125-3609-49de-a607-ae27788f3b56";
//            string brandId = "d0ef0e14-2b09-43c5-9aea-e3b838f676e8";
//            const string KhaasfoodCom = "khaasfood.com";
//            const string EvKhaasfoodCom = "ev@khaasfood.com";
//            const string categoryId = "024dae31-5dc3-4650-9e6a-756009a00b8b";

//            ProductDetailService productService = new ProductDetailService(new BaseRepository<ProductDetail>(db));
//            ProductDetail detail = db.ProductDetails.FirstOrDefault(x => x.ShopId == shopId && x.Name == mango.mangoType);
//            if (detail == null)
//            {
//                string barCode = productService.GetBarcode2(shopId);
//                detail = new ProductDetail()
//                {
//                    CreatedBy = EvKhaasfoodCom,
//                    ModifiedBy = EvKhaasfoodCom,
//                    CreatedFrom = KhaasfoodCom,
//                    ShopId = shopId,
//                    IsActive = true,
//                    Id = Guid.NewGuid().ToString(),
//                    Created = DateTime.Now,
//                    Modified = DateTime.Now,
//                    Name = string.Format($"{mango.mangoType}"),
//                    ProductCode = GetProductCode(mango.mangoType),
//                    BarCode = barCode,
//                    BrandId = brandId,
//                    CostPrice = 0,
//                    DealerPrice = 0,
//                    HasExpiryDate = true,
//                    OnHand = 0,
//                    ProductCategoryId = categoryId,
//                    SalePrice = mango.unitPrice,
//                };

//                db.ProductDetails.Add(detail);
//                db.SaveChanges();
//            }

//            EvBillingInfo2 billing = new EvBillingInfo2()
//            {
//                blling_name = mango.name,
//                blling_phone = mango.phone1,
//            };
//            EvDeliveryInfo2 delivery = new EvDeliveryInfo2()
//            {
//                deliveryDay = DateTime.Now.AddDays(1),
//                deliveryTime = ""
//            };

//            EvOrderRemark2 remark = new EvOrderRemark2()
//            {
//                orderRemark = ""
//            };
//            EvOrderSummary2 summary = new EvOrderSummary2()
//            {
//                deliverycharge = mango.deliveryCost,
//                grandtotal = mango.grandTotalPrice,
//                totalprice = mango.totalPrice,
//                totalDiscountPrice = mango.totalPrice,
//            };
//            EvShippingInfo2 shipping = new EvShippingInfo2()
//            {
//                shiping_address = mango.address,
//                shiping_city = mango.deliveryCity,
//                shiping_phone = mango.phone1,
//                shiping_zipCode = mango.deliveryZone,
//                shiping_zone = mango.deliveryZone
//            };

//            EvMultiCatagory2 category = new EvMultiCatagory2() { categoryId = categoryId };
//            EvShoppingCart2 item = new EvShoppingCart2()
//            {
//                measurement = mango.mangoMeasurement,
//                price = mango.unitPrice,
//                quantity = mango.totalPrice / mango.unitPrice,
//                productName = mango.mangoType,
//                multi_category = new List<EvMultiCatagory2>() { category },
//                productId = detail.Id,
//            };
//            List<EvShoppingCart2> cart = new List<EvShoppingCart2>() { item };
//            EvUserInfo2 user = new EvUserInfo2() { email = mango.email1, _phone = mango.phone1 };
//            EvSale2 sale = new EvSale2()
//            {
//                billingInfo = billing,
//                deliveryInfo = delivery,
//                id = mango.id,
//                orderRemark = remark,
//                orderSummary = summary,
//                shippingInfo = shipping,
//                shoppingCart = cart,
//                userInfo = user
//            };

//            return sale;
//        }

//        private EvSale2 LitchiConvert(Litchi litchi)
//        {
//            BusinessDbContext db = new BusinessDbContext();
//            string shopId = "35574125-3609-49de-a607-ae27788f3b56";
//            string brandId = "d0ef0e14-2b09-43c5-9aea-e3b838f676e8";
//            const string KhaasfoodCom = "khaasfood.com";
//            const string EvKhaasfoodCom = "ev@khaasfood.com";
//            const string categoryId = "024dae31-5dc3-4650-9e6a-756009a00b8b";

//            ProductDetailService productService = new ProductDetailService(new BaseRepository<ProductDetail>(db));
//            ProductDetail detail = db.ProductDetails.FirstOrDefault(x => x.ShopId == shopId && x.Name == litchi.lichuType);
//            if (detail == null)
//            {
//                string barCode = productService.GetBarcode2(shopId);
//                detail = new ProductDetail()
//                {
//                    CreatedBy = EvKhaasfoodCom,
//                    ModifiedBy = EvKhaasfoodCom,
//                    CreatedFrom = KhaasfoodCom,
//                    ShopId = shopId,
//                    IsActive = true,
//                    Id = Guid.NewGuid().ToString(),
//                    Created = DateTime.Now,
//                    Modified = DateTime.Now,
//                    Name = string.Format($"{litchi.lichuType}"),
//                    ProductCode = GetProductCode(litchi.lichuType),
//                    BarCode = barCode,
//                    BrandId = brandId,
//                    CostPrice = 0,
//                    DealerPrice = 0,
//                    HasExpiryDate = true,
//                    OnHand = 0,
//                    ProductCategoryId = categoryId,
//                    SalePrice = litchi.unitPrice,
//                };

//                db.ProductDetails.Add(detail);
//                db.SaveChanges();
//            }

//            EvBillingInfo2 billing = new EvBillingInfo2()
//            {
//                blling_name = litchi.name,
//                blling_phone = litchi.phone,
//            };
//            EvDeliveryInfo2 delivery = new EvDeliveryInfo2()
//            {
//                deliveryDay = DateTime.Now.AddDays(1),
//                deliveryTime = ""
//            };

//            EvOrderRemark2 remark = new EvOrderRemark2()
//            {
//                orderRemark = ""
//            };
//            EvOrderSummary2 summary = new EvOrderSummary2()
//            {
//                deliverycharge = litchi.deliveryCost,
//                grandtotal = litchi.grandTotalPrice,
//                totalprice = litchi.totalPrice,
//                totalDiscountPrice = litchi.totalPrice,
//            };
//            EvShippingInfo2 shipping = new EvShippingInfo2()
//            {
//                shiping_address = litchi.address,
//                shiping_city = litchi.deliveryCity,
//                shiping_phone = litchi.phone,
//                shiping_zipCode = litchi.deliveryZone,
//                shiping_zone = litchi.deliveryZone
//            };

//            EvMultiCatagory2 category = new EvMultiCatagory2() { categoryId = categoryId };
//            EvShoppingCart2 item = new EvShoppingCart2()
//            {
//                measurement = litchi.lichuMeasurement,
//                price = litchi.unitPrice,
//                quantity = litchi.totalPrice / litchi.unitPrice,
//                productName = litchi.lichuType,
//                multi_category = new List<EvMultiCatagory2>() { category },
//                productId = detail.Id,
//            };
//            List<EvShoppingCart2> cart = new List<EvShoppingCart2>() { item };
//            EvUserInfo2 user = new EvUserInfo2() { email = litchi.email1, _phone = litchi.phone };
//            EvSale2 sale = new EvSale2()
//            {
//                billingInfo = billing,
//                deliveryInfo = delivery,
//                id = litchi.id,
//                orderRemark = remark,
//                orderSummary = summary,
//                shippingInfo = shipping,
//                shoppingCart = cart,
//                userInfo = user
//            };

//            return sale;
//        }

//        [Route("EvCancelState")]
//        [ActionName("EvCancelState")]
//        public IHttpActionResult EvCancelState([FromBody] EvSale2 model)
//        {
//            try
//            {
//                string o = JsonConvert.SerializeObject(model);
//                if (string.IsNullOrWhiteSpace(model.id))
//                {
//                    return this.BadRequest("Model Id not found. Model : " + o);
//                }

//                if (CheckIfHeaderMissing())
//                {
//                    return this.BadRequest("Header missing or invalid header value");
//                }

//                BusinessDbContext db = BusinessDbContext.Create();
//                SaleService service = new SaleService(new BaseRepository<Sale>(db));
//                Sale saleById = service.GetById(model.id);
//                if (saleById == null)
//                {
//                    return this.NotFound();
//                }

//                saleById.Remarks = "order cancelled by khaasfood.com";
//                bool edit = service.UpdateState(saleById, OrderState.Cancel);
//                return Ok(edit);
//            }
//            catch (Exception exception)
//            {
//                Logger.Fatal(exception, "Exception occurred while moving Next State {TypeName}", typeof(ExternalSaleController));
//                return InternalServerError(exception);
//            }
//        }

//        [Route("EvSalePay")]
//        [ActionName("EvSalePay")]
//        public async Task<IHttpActionResult> SalePay([FromBody] Transaction transaction)
//        {
//            var o = JsonConvert.SerializeObject(transaction);

//            if (string.IsNullOrWhiteSpace(transaction.OrderId))
//            {
//                return this.BadRequest("Invalid OrderId. Model : " + o);
//            }


//            if (CheckIfHeaderMissing())
//            {
//                return this.BadRequest("Header missing or invalid header value");
//            }

//            BusinessDbContext db = BusinessDbContext.Create();
//            TransactionService transactionService = new TransactionService(new BaseRepository<Transaction>(db));
//            SaleService saleService = new SaleService(new BaseRepository<Sale>(db));
//            // SaleRequestModel request = new SaleRequestModel(transaction.OrderId) { Id = transaction.OrderId };
//            // Tuple<List<SaleViewModel>, int> tuple = await saleService.SearchAsync(request);
//            var saleViewModel = saleService.GetDetail(transaction.OrderId);
//            //SaleViewModel saleViewModel = tuple.Item1.FirstOrDefault();

//            if (saleViewModel == null)
//            {
//                return this.NotFound();
//            }

//            transaction.Id = Guid.NewGuid().ToString();
//            transaction.OrderId = saleViewModel.Id;
//            transaction.OrderNumber = saleViewModel.OrderNumber;
//            transaction.ParentId = saleViewModel.CustomerId;
//            transaction.ShopId = saleViewModel.ShopId;
//            transaction.TransactionFor = TransactionFor.Sale;
//            transaction.TransactionFlowType = TransactionFlowType.Income;
//            transaction.CreatedFrom = "khaasfood.com";
//            transaction.CreatedBy = "khaasfood.com";
//            transaction.ModifiedBy = "khaasfood.com";
//            transaction.Created = DateTime.Now;
//            transaction.Modified = DateTime.Now;
//            transaction.AccountHeadId = "a6c51a5d-6e87-4a13-bca7-7a728baf4cb3";
//            transaction.AccountHeadName = "Sale";
//            transaction.TransactionDate = DateTime.Now;

//            if (transaction.TransactionMedium == TransactionMedium.Card)
//            {
//                transaction.TransactionMediumName = "Card";
//                transaction.AccountInfoId = "94d7bb80-1a5d-4ee4-a532-4c95d7fd530f";
//                transaction.PaymentGatewayServiceName = "Bank";
//            }
//            else
//            {
//                transaction.TransactionMedium = TransactionMedium.Mobile;
//                transaction.TransactionMediumName = "Bkash";
//                transaction.AccountInfoId = "94d7bb80-1a5d-4ee4-a532-4c95d7fd530f";
//                transaction.PaymentGatewayServiceName = "Bank";
//            }

//            //transaction.Amount = saleViewModel.PayableTotalAmount;

//            try
//            {
//                bool add = transactionService.Add(transaction);
//                dynamic response = new { OrderId = saleViewModel.Id, OrderNumber = saleViewModel.OrderNumber, TransactionId = transaction.Id };
//                return this.Ok(response);
//            }
//            catch (DbEntityValidationException validationException)
//            {
//                string message = this.PrepareValidationExceptionMessage(transaction, validationException);
//                return this.BadRequest(message);
//            }
//            catch (Exception exception)
//            {
//                var s = exception.ToString();
//                return BadRequest(s);
//            }
//        }

//        private string GetProductCode(string detailName)
//        {
//            string[] separator = new[] { " ", "-" };
//            string[] strings = detailName.Split(separator, StringSplitOptions.RemoveEmptyEntries);
//            string c = string.Empty;
//            foreach (string s in strings)
//            {
//                c += s[0].ToString();
//            }

//            Console.WriteLine($"Code : {c}");
//            return c;
//        }

//        [Route("EvMangoSale")]
//        [ActionName("EvMangoSale")]
//        public async Task<IHttpActionResult> MangoSale([FromBody] Mango model)
//        {
//            string o = JsonConvert.SerializeObject(model);
//            if (string.IsNullOrWhiteSpace(model.id))
//            {
//                return this.BadRequest("Model Id not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.address))
//            {
//                return this.BadRequest("Model Address not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.deliveryCity))
//            {
//                return this.BadRequest("Model deliveryCity not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.deliveryCost.ToString()))
//            {
//                return this.BadRequest("Model deliveryCost not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.deliveryZone))
//            {
//                return this.BadRequest("Model deliveryZone not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.mangoType))
//            {
//                return this.BadRequest("Model mangoType not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.name))
//            {
//                return this.BadRequest("Model name not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.phone1))
//            {
//                return this.BadRequest("Model phone1 not found. Model : " + o);
//            }


//            if (CheckIfHeaderMissing())
//            {
//                return this.BadRequest("Header missing or invalid header value");
//            }

//            try
//            {
//                BusinessDbContext db = new BusinessDbContext();
//                SaleService service = new SaleService(new BaseRepository<Sale>(db));
//                EvSale2 evSale2 = this.MangoConvert(model);
//                Sale sale = this.GetSaleFromEv2(evSale2);
//                sale.IsTaggedSale = true;
//                sale.SaleTag = "Mango";
//                bool exists = await db.Sales.AnyAsync(x => x.Id == sale.Id);
//                if (!exists)
//                {
//                    var add = service.Add(sale);
//                    var content = new { sale.Id, sale.OrderNumber };
//                    return this.Ok(content);
//                }
//                else
//                {
//                    return BadRequest("This Sale Id is already saved in database");
//                }
//            }
//            catch (DbEntityValidationException validationException)
//            {
//                var exceptionMessage = PrepareValidationExceptionMessage(model, validationException);
//                return BadRequest(exceptionMessage);
//            }
//            catch (Exception exception)
//            {
//                var s = exception.ToString();
//                return BadRequest(s);
//            }
//        }

//        [Route("EvLitchiSale")]
//        [ActionName("EvLitchiSale")]
//        public async Task<IHttpActionResult> LitchiSale([FromBody] Litchi model)
//        {
//            string o = JsonConvert.SerializeObject(model);
//            if (string.IsNullOrWhiteSpace(model.id))
//            {
//                return this.BadRequest("Model Id not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.address))
//            {
//                return this.BadRequest("Model Address not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.deliveryCity))
//            {
//                return this.BadRequest("Model deliveryCity not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.deliveryCost.ToString()))
//            {
//                return this.BadRequest("Model deliveryCost not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.deliveryZone))
//            {
//                return this.BadRequest("Model deliveryZone not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.lichuType))
//            {
//                return this.BadRequest("Model lichu type not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.name))
//            {
//                return this.BadRequest("Model name not found. Model : " + o);
//            }

//            if (string.IsNullOrWhiteSpace(model.phone))
//            {
//                return this.BadRequest("Model phone1 not found. Model : " + o);
//            }


//            if (CheckIfHeaderMissing())
//            {
//                return this.BadRequest("Header missing or invalid header value");
//            }

//            try
//            {
//                BusinessDbContext db = new BusinessDbContext();
//                SaleService service = new SaleService(new BaseRepository<Sale>(db));
//                EvSale2 evSale2 = this.LitchiConvert(model);
//                Sale sale = this.GetSaleFromEv2(evSale2);
//                sale.IsTaggedSale = true;
//                sale.SaleTag = "Litchi";
//                bool exists = await db.Sales.AnyAsync(x => x.Id == sale.Id);
//                if (!exists)
//                {
//                    var add = service.Add(sale);
//                    var content = new { sale.Id, sale.OrderNumber };
//                    return this.Ok(content);
//                }
//                else
//                {
//                    return BadRequest("This Sale Id is already saved in database");
//                }
//            }
//            catch (DbEntityValidationException validationException)
//            {
//                var exceptionMessage = PrepareValidationExceptionMessage(model, validationException);
//                return BadRequest(exceptionMessage);
//            }
//            catch (Exception exception)
//            {
//                var s = exception.ToString();
//                return BadRequest(s);
//            }
//        }
//    }
//}
