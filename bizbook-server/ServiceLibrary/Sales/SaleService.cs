using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Sales;
using ServiceLibrary.Customers;
using Vm = ViewModel.Sales.SaleViewModel;
using Rm = RequestModel.Sales.SaleRequestModel;
using Repo = Model.BaseRepository<Model.Model.Sale>;
using M = Model.Model.Sale;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Constants;
using Model.Model;
using Model.Shops;
using Newtonsoft.Json;
using RequestModel;
using ServiceLibrary.Products;
using ServiceLibrary.StateServices;
using ViewModel.Sales;

namespace ServiceLibrary.Sales
{
    using System.Collections;
    using System.Transactions;
    using RequestModel.Sales;

    using ServiceLibrary.Transactions;

    using ViewModel.Customers;
    using ViewModel.Transactions;

    using Transaction = Model.Model.Transaction;
    using RequestModel.Reports;
    using RequestModel.Transactions;
    using ServiceLibrary.Shops;

    using ViewModel.History;
    using ViewModel.Products;
    using ViewModel.Shops;

    public class SaleService : BaseService<M, Rm, Vm>, IWooCommerceService
    {
        private TransactionService transactionService;

        private CustomerService customerService;

        private BaseRepository<Customer> customerRepository;

        private BaseRepository<ProductDetail> productDetailRepository;

        private BaseRepository<Address> addressRepository;

        //ProductReportService2 productReportService;

        //  private AccountReportService2 accountReportService;

        //  SaleReportService saleReportService;


        public SaleService(Repo repository) : base(repository)
        {
            customerRepository = new BaseRepository<Customer>(Repository.Db);
            customerService = new CustomerService(customerRepository);
            BaseRepository<Transaction> transactionRepo = new BaseRepository<Transaction>(Db);
            this.transactionService = new TransactionService(transactionRepo);
            this.productDetailRepository = new BaseRepository<ProductDetail>(repository.Db);
            this.addressRepository = new BaseRepository<Address>(repository.Db);


            // reports
            //this.saleReportService = new SaleReportService();
            //this.productReportService = new ProductReportService2();
            //this.accountReportService = new AccountReportService2();
        }

        public override Vm GetDetail(string id)
        {
            var dbContext = Repository.Db as BizBookInventoryContext;
            Sale sale = GetById(id);
            Vm viewModel = new Vm(sale);
            viewModel.SaleDetails = dbContext.SaleDetails.Where(x => x.SaleId == id).Include(x => x.ProductDetail)
                .ToList().ConvertAll(x => new SaleDetailViewModel(x)).ToList();

            viewModel.Transactions = dbContext.Transactions.Where(x => x.OrderId == sale.Id).Include(x => x.AccountInfo).ToList()
                .ConvertAll(y => new TransactionViewModel(y)).ToList();

            viewModel.SaleStates = dbContext.SaleStates.Where(x => x.SaleId == id).ToList()
                .ConvertAll(y => new SaleStateViewModel(y)).ToList();

            if (viewModel.AddressId.IdIsOk())
            {
                Address address = this.addressRepository.GetById(viewModel.AddressId);
                if (address != null)
                {
                    viewModel.Address = new AddressViewModel(address);
                }
            }

            if (viewModel.CustomerId.IdIsOk())
            {
                var customer = this.customerRepository.GetById(viewModel.CustomerId);
                if (customer != null)
                {
                    viewModel.Customer = new CustomerViewModel(customer);
                }
            }
            if (viewModel.IsDealerSale)
            {
                var dealerRepository = new BaseRepository<Dealer>(Repository.Db);
                var dealer = dealerRepository.GetById(viewModel.DealerId);
                if (dealer != null)
                {
                    viewModel.Dealer = new DealerViewModel(dealer);
                }
            }

            return viewModel;
        }

        public override bool Add(M sale)
        {
            using (var scope = new TransactionScope())
            {
                double productAmountPaid = 0;

                if (sale.PaidAmount > 0)
                {
                    productAmountPaid = sale.PaidAmount - sale.DeliveryChargeAmount;
                }

                foreach (var detail in sale.SaleDetails)
                {
                    AddCommonValues(sale, detail);
                    detail.ShopId = sale.ShopId;
                    detail.WarehouseId = sale.WarehouseId;
                    var pd = this.productDetailRepository.GetById(detail.ProductDetailId);
                    detail.CostPricePerUnit = pd.CostPrice;
                    detail.CostTotal = detail.CostPricePerUnit * detail.Quantity;
                    if (productAmountPaid > 0)
                    {
                        detail.PaidAmount = productAmountPaid * (detail.Total / sale.ProductAmount);
                    }

                    detail.DueAmount = detail.Total - detail.PaidAmount;
                }

                sale.CostAmount = sale.SaleDetails.Sum(x => x.CostTotal);

                if (sale.CostAmount > 0)
                {
                    sale.ProfitAmount = sale.PayableTotalAmount - sale.CostAmount;
                    sale.ProfitPercent = sale.ProfitAmount * 100 / sale.CostAmount;
                }

                if (!sale.IsDealerSale)
                {
                    SetCustomer(sale);
                    SetAddress(sale);
                }
                else
                {
                    sale.Customer = null;
                    sale.Address = null;
                    sale.CustomerId = null;
                    sale.AddressId = null;
                }

                if (sale.Installment != null && sale.Installment.CashPriceAmount > 0)
                {
                    AddCommonValues(sale, sale.Installment);
                    sale.Installment.ShopId = sale.ShopId;
                    sale.Installment.SaleId = sale.Id;

                    if (sale.Installment.InstallmentDetails != null)
                    {
                        foreach (var detail in sale.Installment.InstallmentDetails)
                        {
                            AddCommonValues(sale, detail);
                            detail.ShopId = sale.ShopId;
                            detail.SaleId = sale.Id;
                        }
                    }

                    sale.InstallmentId = sale.Installment.Id;
                }

                sale.OrderNumber = GetOrderNumber(sale.ShopId).GetAwaiter().GetResult();
                if (sale.Transactions != null && sale.Transactions.Count > 0)
                {
                    AccountInfo accountInfo = GetCashAccountInfo(sale);
                    var paidByCashTransations = sale.Transactions.Where(x => x.AccountInfoId == accountInfo.Id).ToList();
                    if (paidByCashTransations.Count > 0)
                    {
                        sale.PaidByCashAmount = paidByCashTransations.Sum(x => x.Amount);
                    }

                    var paidByOtherTransactions = sale.Transactions.Where(x => x.AccountInfoId != accountInfo.Id).ToList();
                    if (paidByOtherTransactions.Count > 0)
                    {
                        sale.PaidByOtherAmount = paidByOtherTransactions.Sum(x => x.Amount);
                    }
                }

                bool added = base.Add(sale);
                if (added)
                {
                    if (sale.OrderState > OrderState.Pending)
                    {
                        this.UpdateProductDetail(sale);
                        //this.UpdateProductReport(sale);
                    }

                    AddTransaction(sale, TransactionFlowType.Income);
                    AddSaleState(sale, sale.Remarks, sale.OrderState.ToString());
                    customerService.UpdatePoint(sale.CustomerId);

                    if (sale.IsDealerSale)
                    {
                        DealerProductService dealerProductService =
                            new DealerProductService(new BaseRepository<DealerProduct>(Db));
                        dealerProductService.UpsertProductsByDealer(sale);
                    }
                }

                scope.Complete();
            }

            //UpdateSaleReport(sale);
            //UpdateAccountReport(sale);

            return true;
        }

        public bool Add2(M sale)
        {
            BizBookInventoryContext db = this.Repository.Db as BizBookInventoryContext;
            Sale dbSale1 = db.Sales.Find(sale.Id);
            if (dbSale1 == null)
            {
                Customer dbCustomer = db.Customers.Find(sale.CustomerId);
                if (dbCustomer != null)
                {
                    sale.Customer = null;
                }
                else
                {
                    sale.Customer.Addresses = null;
                }

                if (db.Addresses.Find(sale.AddressId) != null)
                {
                    sale.Address = null;
                }

                sale.EstimatedDeliveryDate = sale.RequiredDeliveryDateByCustomer;
                db.Sales.Add(sale);
                db.SaveChanges();
            }

            return true;
        }

        //private void UpdateSaleReport(Sale sale)
        //{
        //    bool result = saleReportService.QuickUpdate(sale.Created, sale.ShopId);
        //}

        //private void UpdateAccountReport(Sale sale)
        //{
        //    AccountHead accountHead = this.GetSaleAccountHead(sale);
        //    this.accountReportService.QuickUpdate(sale.ShopId, accountHead.Id, sale.Created);
        //}

        //private void UpdateProductReport(Sale sale)
        //{
        //    foreach (SaleDetail detail in sale.SaleDetails)
        //    {
        //        this.productReportService.QuickUpdate(sale.ShopId, detail.ProductDetailId, sale.Created);
        //    }
        //}

        private void AddSaleState(Sale sale, string remarks, string orderState)
        {
            if (string.IsNullOrWhiteSpace(remarks))
            {
                remarks = orderState;
            }

            Model.Model.SaleState state = new Model.Model.SaleState()
            {
                Remarks = remarks,
                SaleId = sale.Id,
                ShopId = sale.ShopId,
                State = orderState
            };

            AddCommonValues(sale, state);
            var db = Repository.Db as BizBookInventoryContext;
            db.SaleStates.Add(state);
            db.SaveChanges();
        }

        private void AddTransaction(Sale sale, TransactionFlowType transactionFlowType)
        {
            AccountHead accountHead = this.GetSaleAccountHead(sale);

            if (sale.Transactions == null)
            {
                sale.Transactions = new List<Transaction>();
            }

            foreach (Transaction transaction in sale.Transactions)
            {
                transaction.ShopId = sale.ShopId;
                transaction.AccountHeadId = accountHead.Id;
                transaction.AccountHeadName = accountHead.Name;
                transaction.TransactionFlowType = transactionFlowType;
                transaction.OrderNumber = sale.OrderNumber;
                transaction.ContactPersonName = sale.CustomerName;
                transaction.ContactPersonPhone = sale.CustomerPhone;
                transaction.ParentId = sale.IsDealerSale ? sale.DealerId : sale.CustomerId;
                transaction.TransactionFor = TransactionFor.Sale;
                transaction.OrderId = sale.Id;
                transaction.TransactionWith = sale.IsDealerSale ? TransactionWith.Dealer : TransactionWith.Customer;
                transaction.TransactionDate = DateTime.Now;
                AddCommonValues(sale, transaction);
                this.transactionService.Add(transaction);
            }
        }

        private AccountHead GetSaleAccountHead(Sale sale)
        {
            var db = this.Repository.Db as BizBookInventoryContext;
            AccountHead accountHead = db.AccountHeads.FirstOrDefault(x => x.Name == "Sale" && x.ShopId == sale.ShopId);
            if (accountHead == null)
            {
                accountHead = new AccountHead() { ShopId = sale.ShopId, Name = "Sale" };
                this.AddCommonValues(sale, accountHead);
                db.AccountHeads.Add(accountHead);
                db.SaveChanges();
            }

            return accountHead;
        }

        private AccountInfo GetCashAccountInfo(Sale sale)
        {
            var db = this.Repository.Db as BizBookInventoryContext;
            var accountInfo = db.AccountInfoes.FirstOrDefault(x => x.AccountTitle == "Cash" && x.ShopId == sale.ShopId);
            if (accountInfo == null)
            {
                accountInfo = new AccountInfo() { ShopId = sale.ShopId, AccountTitle = "Cash", AccountInfoType = AccountInfoType.Cash, AccountNumber = "Cash" };
                this.AddCommonValues(sale, accountInfo);
                db.AccountInfoes.Add(accountInfo);
                db.SaveChanges();
            }

            return accountInfo;
        }

        private void SetCustomer(Sale sale)
        {
            Guid customerId;
            bool invaliId = !Guid.TryParse(sale.CustomerId, out customerId);
            if (invaliId || customerId == new Guid())
            {
                Customer customer = customerRepository.Get().FirstOrDefault(x => x.Phone.ToLower() == sale.CustomerPhone && x.ShopId == sale.ShopId);
                if (customer == null)
                {
                    string barcode = customerService.GetBarcode(sale.ShopId);
                    customer = new Customer()
                    {
                        ShopId = sale.ShopId,
                        MembershipCardNo = barcode,
                        Name = sale.CustomerName,
                        Phone = sale.CustomerPhone,
                        IsActive = true,
                    };
                    AddCommonValues(sale, customer);
                    customerService.Add(customer);
                }

                sale.CustomerId = customer.Id;
            }
        }

        private void SetAddress(Sale sale)
        {
            Address address = addressRepository.GetById(sale.AddressId);
            if (address == null)
            {
                if (sale.Address == null)
                {
                    sale.Address = new Address
                    {
                        CustomerId = sale.CustomerId,
                        AddressName = "Inhouse",
                        ShopId = sale.ShopId
                    };
                }
                else
                {
                    sale.Address.CustomerId = sale.CustomerId;
                    sale.Address.ShopId = sale.ShopId;
                }

                address = sale.Address;

                AddCommonValues(sale, address);
                addressRepository.Add(address);
            }


            sale.AddressId = address.Id;
            sale.Address = null;
        }

        public override bool Upsert(Sale sale)
        {
            var detailRepository = new BaseRepository<SaleDetail>(Repository.Db);
            bool success;
            sale.Modified = DateTime.Now;

            if (!Repository.Exists(sale.Id))
            {
                success = Add(sale);
            }
            else
            {
                var temp = sale.SaleDetails;
                sale.SaleDetails = null;

                var existingSaleDetailsInDb = detailRepository.Get().Where(x => x.SaleId == sale.Id).Select(x => x.Id).ToList();
                foreach (string s in existingSaleDetailsInDb)
                {
                    detailRepository.Delete(s);
                    detailRepository.Save();
                }

                success = Edit(sale);
                foreach (var detail in temp)
                {
                    if (detailRepository.Exists(detail.Id))
                    {
                        detailRepository.Edit(detail);
                    }
                    else
                    {
                        detailRepository.Add(detail);
                    }
                    detailRepository.Save();
                }
            }

            if (success)
            {
                UpdateProductDetail(sale);
            }

            return success;
        }

        private void UpdateProductDetail(Sale sale)
        {
            if (sale.SaleDetails != null)
            {
                List<string> ids = sale.SaleDetails.Select(x => x.ProductDetailId).ToList();
                foreach (var id in ids)
                {
                    var sold = Repository.Db.Set<SaleDetail>()
                        .Where(x => x.ProductDetailId == id)
                        .Sum(y => y.Quantity);
                    ProductDetail productDetail = Repository.Db.Set<ProductDetail>().Find(id);
                    if (productDetail != null)
                    {
                        productDetail.Sold = sold;
                        productDetail.OnHand = productDetail.Purchased + productDetail.StartingInventory - productDetail.Sold;
                    }

                    var warehouseProduct = this.Repository.Db.Set<WarehouseProduct>().FirstOrDefault(
                        x => x.ShopId == sale.ShopId && x.ProductDetailId == id && x.WarehouseId == sale.WarehouseId);
                    if (warehouseProduct == null)
                    {
                        warehouseProduct = new WarehouseProduct
                        {
                            ShopId = sale.ShopId,
                            WarehouseId = sale.WarehouseId,
                            MinimumStockToNotify =
                                                       productDetail.MinimumStockToNotify,
                            ProductDetailId = productDetail.Id,
                        };
                        this.AddCommonValues(sale, warehouseProduct);
                        this.Repository.Db.Set<WarehouseProduct>().Add(warehouseProduct);
                        Repository.Save();
                    }

                    var saleDetailsByWh = this.Repository.Db.Set<SaleDetail>()
                        .Where(x => x.ShopId == sale.ShopId && x.ProductDetailId == id && x.WarehouseId == sale.WarehouseId && x.Quantity != null && x.Quantity > 0);
                    var soldByWh = saleDetailsByWh.Any() ? saleDetailsByWh.Sum(y => y.Quantity) : 0;
                    warehouseProduct.Sold = soldByWh;
                    warehouseProduct.OnHand = warehouseProduct.Purchased + warehouseProduct.StartingInventory + warehouseProduct.TransferredIn
                                              - warehouseProduct.Sold - warehouseProduct.TransferredOut;
                    warehouseProduct.Modified = DateTime.Now;
                    Repository.Save();
                }
            }
        }


        public bool NextState(Sale sale)
        {
            SaleContext context = new SaleContext(sale.OrderState);
            bool tryNext = context.TryNext();
            if (tryNext)
            {
                this.UpdateState(sale, context.State.CurrentState);
            }

            return tryNext;
        }

        public bool UpdateState(Sale sale, OrderState nextState)
        {
            var dbSale = this.Repository.GetById(sale.Id);
            var saleDetailRepository = new BaseRepository<SaleDetail>(this.Repository.Db);
            dbSale.SaleDetails = saleDetailRepository.Get().Where(x => x.SaleId == dbSale.Id).ToList();

            if (dbSale.OrderState == OrderState.Pending && nextState > OrderState.Pending && nextState != OrderState.Cancel)
            {
                UpdateProductDetail(dbSale);
                //UpdateProductReport(dbSale);
            }

            dbSale.OrderState = nextState;

            if (!string.IsNullOrWhiteSpace(sale.DeliverymanId))
            {
                dbSale.DeliverymanId = sale.DeliverymanId;
            }

            if (!string.IsNullOrWhiteSpace(sale.DeliverymanName))
            {
                dbSale.DeliverymanName = sale.DeliverymanName;
            }

            if (!string.IsNullOrWhiteSpace(sale.CourierShopId))
            {
                dbSale.CourierShopId = sale.CourierShopId;
            }

            if (!string.IsNullOrWhiteSpace(sale.CourierName))
            {
                dbSale.CourierName = sale.CourierName;
            }

            this.Repository.Save();

            this.AddSaleState(sale, sale.Remarks, dbSale.OrderState.ToString());

            if (dbSale.OrderState == OrderState.Completed)
            {
                this.customerService.UpdatePoint(sale.CustomerId);
            }

            if (dbSale.OrderState == OrderState.Cancel)
            {
                using (var scope = new TransactionScope())
                {
                    dbSale.CostAmount = 0;
                    dbSale.DeliveryChargeAmount = 0;
                    dbSale.DiscountAmount = 0;
                    dbSale.DueAmount = 0;
                    dbSale.OtherAmount = 0;
                    dbSale.PaidAmount = 0;
                    dbSale.PayableTotalAmount = 0;
                    dbSale.PaymentServiceChargeAmount = 0;
                    dbSale.ProductAmount = 0;
                    dbSale.ProfitAmount = 0;
                    dbSale.ProfitPercent = 0;
                    dbSale.TaxAmount = 0;
                    dbSale.TotalAmount = 0;
                    this.Repository.Save();

                    foreach (var saleDetail in dbSale.SaleDetails)
                    {
                        saleDetail.CostTotal = 0;
                        saleDetail.DiscountTotal = 0;
                        saleDetail.PriceTotal = 0;
                        saleDetail.SalePricePerUnit = 0;
                        saleDetail.Total = 0;
                        saleDetail.Quantity = 0;
                        saleDetail.CostPricePerUnit = 0;
                        saleDetail.IsActive = false;
                        saleDetailRepository.Save();
                    }

                    //var transactionRepository = new BaseRepository<Transaction>(this.Repository.Db);
                    //var transactions = transactionRepository.Get().Where(x => x.OrderId == dbSale.Id).ToList();
                    //foreach (var transaction in transactions)
                    //{
                    //    transaction.Amount = 0;
                    //    transactionRepository.Save();
                    //}

                    UpdateProductDetail(dbSale);
                    // UpdateProductReport(dbSale);
                    this.customerService.UpdatePoint(sale.CustomerId);
                    scope.Complete();
                }
            }

            return true;
        }

        public Tuple<List<SaleViewModel>, int> SearchDelivery(string myId, string myShopId)
        {
            var sales = Repository.Get();
            sales = sales.Where(
                x =>
                    x.OrderState == OrderState.ReadyToDeparture || x.OrderState == OrderState.OnTheWay);
            sales = sales.Where(x => x.DeliverymanId == myId && (x.ShopId == myShopId || x.CourierShopId == myShopId));
            var saleVms = sales.ToList().ConvertAll(x => new Vm(x));
            return new Tuple<List<SaleViewModel>, int>(saleVms, saleVms.Count);
        }

        public Tuple<List<SaleViewModel>, int> SearchReadyToDeparture(string myShopId)
        {
            var sales = Repository.Get();
            sales = sales.Where(x => x.OrderState == OrderState.ReadyToDeparture
            || x.OrderState == OrderState.OnTheWay || x.OrderState == OrderState.Delivered);
            sales = sales.Where(x => x.CourierShopId == myShopId);
            var saleVms = sales.ToList().ConvertAll(x => new Vm(x));
            return new Tuple<List<SaleViewModel>, int>(saleVms, saleVms.Count);
        }

        public async Task<Tuple<List<SaleViewModel>, int>> SearchReadyToDeparture(CourierOrderRequestModel request)
        {
            var sales = this.Repository.Get();
            var queryable = request.GetOrderedData(sales);
            int count = queryable.Count();
            queryable = request.SkipAndTake(queryable);
            var list = await queryable.ToListAsync();
            var vms = list.ConvertAll(CreateVmInstance);
            return new Tuple<List<SaleViewModel>, int>(vms, count);
        }
        private static SaleViewModel CreateVmInstance(Sale x)
        {
            return (SaleViewModel)Activator.CreateInstance(typeof(SaleViewModel), x);
        }

        //public async Task<int> PullWcData(string shopId, string username)
        //{
        //    int count = 0;
        //    BizBookInventoryContext db = base.Repository.Db as BizBookInventoryContext;
        //    Shop shop = await db.Shops.FindAsync(shopId);

        //    WcRepository wcRepository = new WcRepository(shop.WcUrl, shop.Key, shop.Secret);
        //    bool hasData = true;
        //    int start = 1;
        //    var productDetails = await db.ProductDetails.Where(x => x.ShopId == shopId).ToListAsync();
        //    var sales = await Repository.Get().Where(x => x.ShopId == shopId).Select(x => new { x.Id, x.ShopId, x.WcId }).ToListAsync();
        //    var customers = await db.Customers.Where(x => x.ShopId == shopId).Select(x => new { x.Id, x.WcId, x.ShopId, x.Billing }).ToListAsync();
        //    while (hasData)
        //    {
        //        count = 0;
        //        var list = await wcRepository.GetSales(start);
        //        if (list.Count == 0)
        //        {
        //            hasData = false;
        //        }
        //        foreach (Sale item in list)
        //        {
        //            bool doContinue = false;
        //            bool found = sales.Any(x => x.ShopId == shopId && x.WcId == item.WcId);
        //            if (!found)
        //            {
        //                item.Id = Guid.NewGuid().ToString();
        //                item.CreatedBy = username;
        //                item.ModifiedBy = username;
        //                item.ShopId = shopId;
        //                item.CreatedFrom = "Website";
        //                item.OrderType = item.PaymentMethod == "cod" ? OrderType.CashOnDelivery : OrderType.Courier;
        //                item.OrderState = OrderState.Pending;
        //                item.IsActive = true;
        //                item.OrderNumber = item.WcId.ToString();
        //                item.DeliveryDate = DateTime.UtcNow.AddDays(1).Date;
        //                item.TransactionDate = DateTime.UtcNow;
        //                foreach (var detail in item.SaleDetails)
        //                {
        //                    detail.Id = Guid.NewGuid().ToString();
        //                    detail.Created = item.Created;
        //                    detail.Modified = item.Modified;
        //                    detail.CreatedBy = username;
        //                    detail.ModifiedBy = username;
        //                    detail.ShopId = shopId;
        //                    detail.CreatedFrom = "Website";
        //                    detail.SaleId = item.Id;
        //                    var productDetail = productDetails.FirstOrDefault(x => x.ShopId == shopId && x.WcId == detail.WcProductId && x.WcVariationId == detail.WcProductVariationId);
        //                    if (productDetail != null)
        //                    {
        //                        detail.ProductDetailId = productDetail.Id;
        //                        detail.Name = productDetail.Name;
        //                    }
        //                    else
        //                    {
        //                        doContinue = true;
        //                        break;
        //                    }
        //                }
        //                if (doContinue)
        //                {
        //                    continue;
        //                }


        //                var customer = customers.FirstOrDefault(x => x.ShopId == shopId && (x.Billing.Email == item.Billing.Email || x.Billing.Phone.Contains(item.Billing.Phone)));
        //                if (customer == null)
        //                {
        //                    var dbCustomer = new Customer();
        //                    dbCustomer.Id = Guid.NewGuid().ToString();
        //                    dbCustomer.Created = DateTime.UtcNow;
        //                    dbCustomer.Modified = DateTime.UtcNow;
        //                    dbCustomer.CreatedBy = username;
        //                    dbCustomer.ModifiedBy = username;
        //                    dbCustomer.ShopId = shopId;
        //                    dbCustomer.CreatedFrom = OrderFrom.Website.ToString();
        //                    dbCustomer.Country = item.Billing.Country;
        //                    dbCustomer.District = item.Billing.City;
        //                    dbCustomer.IsActive = true;
        //                    dbCustomer.MembershipCardNo = customerService.GetBarcode(shopId);
        //                    dbCustomer.Phone = item.Billing.Phone;
        //                    dbCustomer.Name = item.Billing.FirstName;
        //                    dbCustomer.LastName = item.Billing.LastName;
        //                    dbCustomer.Billing = item.Billing;
        //                    dbCustomer.Shipping = item.Shipping;
        //                    dbCustomer.Email = item.Billing.Email;
        //                    customerService.Add(dbCustomer);
        //                    item.CustomerId = dbCustomer.Id;
        //                }
        //                else
        //                {
        //                    item.CustomerId = customer.Id;
        //                }

        //                try
        //                {
        //                    Add(item);
        //                    count++;
        //                }
        //                catch (Exception exception)
        //                {
        //                    doContinue = true;
        //                }
        //            }
        //        }

        //        start++;
        //        if (count == 0)
        //        {
        //            hasData = false;
        //        }
        //    }

        //    return count;
        //}

        public async Task<dynamic> GetSalesAmounts(string shopId)
        {
            var today = DateTime.Today;
            var db = Repository.Db as BizBookInventoryContext;
            var totalSales = db.Sales.Where(x => x.ShopId == shopId)
                .Where(x => x.Created >= today)
                ;
            double total = 0;
            if (totalSales.Count() > 0)
            {
                total = await totalSales.SumAsync(x => x.TotalAmount);
            }

            var bizbookSales = totalSales.Where(x => x.SaleFrom == SaleFrom.BizBook365);
            double bizbook = 0;
            if (bizbookSales.Count() > 0)
            {
                bizbook = await bizbookSales.SumAsync(x => x.TotalAmount);
            }

            var facebookSales = totalSales.Where(x => x.SaleFrom == SaleFrom.Facebook);
            double facebook = 0;
            if (facebookSales.Count() > 0)
            {
                facebook = await facebookSales.SumAsync(x => x.TotalAmount);
            }

            var websiteSales = totalSales.Where(x => x.SaleFrom == SaleFrom.Website);
            double website = 0;
            if (websiteSales.Count() > 0)
            {
                website = await websiteSales.SumAsync(x => x.TotalAmount);
            }
            return new { Total = total, Bizbook365 = bizbook, Facebook = facebook, Website = website };
        }

        public async Task<dynamic> GetPendingOrders(string shopId)
        {
            var sevenDaysAgo = DateTime.Now.AddDays(-7).Date;
            var db = Repository.Db as BizBookInventoryContext;
            var sales = await db.Sales.Where(x => x.OrderState == OrderState.Pending && x.ShopId == shopId && x.Modified >= sevenDaysAgo).OrderBy(x => x.RequiredDeliveryDateByCustomer)
                .Select(x => new
                {
                    x.Id,
                    x.TotalAmount,
                    x.OrderNumber,
                    State = x.OrderState.ToString(),
                    OrderFromName = x.SaleFrom.ToString(),
                    OrderDate = x.RequiredDeliveryDateByCustomer,
                    OrderTime = x.RequiredDeliveryTimeByCustomer,
                    x.Remarks,
                    x.Modified
                }).ToListAsync();
            return sales;
        }

        public override bool Edit(Sale sale)
        {
            using (var scope = new TransactionScope())
            {
                BizBookInventoryContext db = this.Repository.Db as BizBookInventoryContext;
                Sale dbSale = db.Sales.Where(x => x.Id == sale.Id).Include(x => x.SaleDetails).FirstOrDefault();
                if (dbSale == null)
                {
                    var exception = new KeyNotFoundException("No sale found by this id");
                    throw exception;
                }

                if (dbSale.WarehouseId != sale.WarehouseId)
                {
                    dbSale.WarehouseId = sale.WarehouseId;
                }

                var detailRepository = new BaseRepository<SaleDetail>(this.Repository.Db);

                foreach (var detail in sale.SaleDetails)
                {
                    var dbDetail = dbSale.SaleDetails.FirstOrDefault(x => x.Id == detail.Id);
                    if (dbDetail != null)
                    {
                        dbDetail.SalePricePerUnit = detail.SalePricePerUnit;
                        dbDetail.DiscountTotal = detail.DiscountTotal;
                        dbDetail.CostPricePerUnit = detail.CostPricePerUnit;
                        dbDetail.Quantity = detail.Quantity;
                        dbDetail.Total = detail.Total;
                        if (dbDetail.WarehouseId != dbSale.WarehouseId)
                        {
                            dbDetail.WarehouseId = dbSale.WarehouseId;
                        }

                        dbDetail.Modified = DateTime.Now;
                        dbDetail.ModifiedBy = sale.ModifiedBy;

                        this.Repository.Db.SaveChanges();
                    }
                    else
                    {
                        this.AddCommonValues(sale, detail);
                        detail.ShopId = sale.ShopId;
                        detail.SaleId = sale.Id;
                        detail.WarehouseId = sale.WarehouseId;
                        detailRepository.Add(detail);
                    }
                }

                dbSale.DeliveryChargeAmount = sale.DeliveryChargeAmount;
                dbSale.DiscountAmount = sale.DiscountAmount;

                dbSale.Modified = DateTime.Now;
                dbSale.ModifiedBy = sale.ModifiedBy;

                this.Repository.Db.SaveChanges();
                this.UpdateSaleAmounts(dbSale.Id);
                this.customerService.UpdatePoint(sale.CustomerId);
                scope.Complete();
            }

            if (sale.OrderState > OrderState.Pending)
            {
                UpdateProductDetail(sale);
                //UpdateProductReport(sale);
            }

            return true;
        }

        private void UpdateSaleAmounts(string saleId)
        {
            var db = this.Repository.Db as BizBookInventoryContext;
            Sale dbSale2 = db.Sales.First(x => x.Id == saleId);
            var saleDetails = db.SaleDetails.Where(x => x.SaleId == saleId);
            dbSale2.ProductAmount = saleDetails.Sum(x => x.Total);
            dbSale2.TotalAmount = dbSale2.ProductAmount + dbSale2.OtherAmount + dbSale2.DeliveryChargeAmount + dbSale2.PaymentServiceChargeAmount;
            dbSale2.PayableTotalAmount = dbSale2.TotalAmount - dbSale2.DiscountAmount;


            var transactions = db.Transactions.Where(x => x.OrderId == saleId);
            var incomeForThisOrder = transactions
                .Where(x => x.TransactionFlowType == TransactionFlowType.Income)
                .Select(x => x.Amount).ToList();
            double customerPaidTotal = incomeForThisOrder.Sum(x => x);
            var expenseForThisOrder = transactions
                .Where(x => x.TransactionFlowType == TransactionFlowType.Expense)
                .Select(x => x.Amount).ToList();
            double customerReturnTotal = expenseForThisOrder.Sum(x => x);
            dbSale2.PaidAmount = customerPaidTotal - customerReturnTotal;
            dbSale2.DueAmount = dbSale2.PayableTotalAmount - dbSale2.PaidAmount;
            db.SaveChanges();
        }


        public async Task<string> GetOrderNumber(string shopId)
        {
            var queryable = this.Repository.Get().Where(x => x.ShopId == shopId).OrderBy(x => x.Id);
            int count = queryable.Count() + 1;

            do
            {
                var number = "S-" + count.ToString().PadLeft(7, '0');
                var prod = queryable.FirstOrDefault(x => x.OrderNumber == number) == null;
                if (prod)
                {
                    return number;
                }

                count = count + 1;
            }
            while (true);
        }

        public async Task<Tuple<List<HistoryViewModel>, int>> GetProductHistory(Rm rm)
        {
            BizBookInventoryContext db = this.Repository.Db as BizBookInventoryContext;
            IQueryable<SaleDetail> saleDetails = db.SaleDetails.Include(x => x.Sale).Include(x => x.ProductDetail).Where(x => x.ShopId == rm.ShopId);
            if (rm.IsDealerSale)
            {
                saleDetails = saleDetails.Where(x => x.Sale.DealerId == rm.ParentId);
            }
            else
            {
                saleDetails = saleDetails.Where(x => x.Sale.CustomerId == rm.ParentId);
            }

            List<SaleDetail> models = await saleDetails.ToListAsync();
            List<SaleDetailViewModel> viewModels = models.ConvertAll(x => new SaleDetailViewModel(x)).ToList();
            List<HistoryViewModel> historyViewModels = viewModels.ConvertAll(x => new HistoryViewModel(x, x.ProductDetailName, x.SalePricePerUnit)).ToList();
            var list = historyViewModels.GroupBy(x => x.ProductDetailId).ToList();

            var histories = new List<HistoryViewModel>();
            foreach (var v in list)
            {
                HistoryViewModel m = new HistoryViewModel();
                string pid = v.Key;
                var pList = v.ToList();
                m.ProductName = pList.First().ProductName;
                m.ProductDetailId = pid;
                m.Quantity = pList.Sum(x => x.Quantity);
                m.Total = pList.Sum(x => x.Total);
                if (m.Quantity > 0)
                {
                    m.UnitPrice = m.Total / m.Quantity;
                }

                m.Paid = pList.Sum(x => x.Paid);
                m.Due = pList.Sum(x => x.Due);
                histories.Add(m);
            }

            return new Tuple<List<HistoryViewModel>, int>(histories, histories.Count);
        }

        public async Task<Tuple<List<HistoryViewModel>, int>> GetBuyerHistory(Rm rm)
        {
            Tuple<List<SaleViewModel>, int> salesTuple = await this.SearchAsync(rm);
            List<HistoryViewModel> saleHistories = salesTuple.Item1.ConvertAll(x => new HistoryViewModel(x)).ToList();

            var transactionService = new BaseService<Transaction, TransactionRequestModel, TransactionViewModel>(new BaseRepository<Transaction>(Repository.Db));
            var transactionRequestModel =
                new TransactionRequestModel(string.Empty, "Modified", "False")
                { ShopId = rm.ShopId, ParentId = rm.ParentId, Page = -1 };
            Tuple<List<TransactionViewModel>, int> transactionsTuple =
                await transactionService.SearchAsync(transactionRequestModel);

            List<HistoryViewModel> trxHistories =
                transactionsTuple.Item1.ConvertAll(x => new HistoryViewModel(x) { Type = "Payment", SaleId = x.OrderId }).ToList();
            saleHistories.AddRange(trxHistories);

            List<HistoryViewModel> merged = saleHistories.OrderBy(x => x.Date).ToList();
            return new Tuple<List<HistoryViewModel>, int>(merged, merged.Count);
        }

        public async Task<Tuple<List<SaleViewModel>, List<HistoryViewModel>>> GetPendingProducts(SaleRequestModel rm)
        {
            BizBookInventoryContext dbContext = this.Repository.Db as BizBookInventoryContext;
            var pList = await dbContext.ProductDetails.Where(x => x.ShopId == rm.ShopId).Select(x => new { x.Name, x.Id }).ToListAsync();

            Tuple<List<SaleViewModel>, int> salesTuple = await this.SearchAsync(rm);
            List<SaleViewModel> item1 = salesTuple.Item1;
            List<SaleDetailViewModel> list = item1.SelectMany(x => x.SaleDetails).ToList();
            var historyViewModels = list.ConvertAll(x => new HistoryViewModel(x, x.ProductDetailName, x.SalePricePerUnit)).ToList();
            var groupBy = historyViewModels.GroupBy(x => x.ProductDetailId);

            var details = new List<HistoryViewModel>();

            foreach (var v in groupBy)
            {
                string vKey = v.Key;
                var viewModels = v.ToList();

                HistoryViewModel hvm = new HistoryViewModel
                {
                    ProductDetailId = vKey,
                    ProductName = pList.First(x => x.Id == vKey).Name,
                    Quantity = viewModels.Sum(x => x.Quantity),
                    Total = viewModels.Sum(x => x.Total)
                };
                details.Add(hvm);
            }

            return new Tuple<List<SaleViewModel>, List<HistoryViewModel>>(item1, details);
        }

        public Sale GetSaleFromWcSale(Sale sale)
        {
            BizBookInventoryContext db = this.Repository.Db as BizBookInventoryContext;
            if (db.Sales.Any(x => x.ShopId == sale.ShopId && x.WcId == sale.WcId))
            {
                return null;
            }

            Shop shop = db.Shops.First(x => x.Id == sale.ShopId);
            string brandId = GetBrandId(db, shop, sale.CreatedBy);
            string shopId = sale.ShopId;
            string shopWcUrl = shop.WcWebhookSource;

            sale.CreatedBy = shopWcUrl;
            sale.ModifiedBy = shopWcUrl;
            sale.CreatedFrom = shopWcUrl;
            sale.SaleFrom = SaleFrom.Website;

            sale.Id = Guid.NewGuid().ToString();
            sale.Modified = DateTime.Now;
            sale.Created = DateTime.Now;
            sale.OrderState = OrderState.Pending;
            sale.OrderNumber = Guid.NewGuid().ToString();
            sale.OrderReferenceNumber = sale.WcId.ToString();

            sale.RequiredDeliveryDateByCustomer = sale.Created.Date.AddDays(1);
            sale.RequiredDeliveryTimeByCustomer = "";

            //// prepare customer
            Customer dbCustomer = db.Customers.FirstOrDefault(x => x.ShopId == sale.ShopId && x.WcId == sale.WcCustomerId);

            if (dbCustomer == null)
            {
                CustomerService customerService = new CustomerService(new BaseRepository<Customer>(db));
                var barCode = customerService.GetBarcode(shopId);
                dbCustomer = new Customer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Email = sale.Customer.Email,
                    Name = sale.Customer.Name,
                    Phone = sale.Customer.Phone,
                    MembershipCardNo = barCode,
                    CreatedBy = shopWcUrl,
                    CreatedFrom = shopWcUrl,
                    IsActive = true,
                    ModifiedBy = shopWcUrl,
                    ShopId = shopId,
                    WcId = (int)sale.WcCustomerId,
                };
                db.Customers.Add(dbCustomer);
                db.SaveChanges();
            }

            sale.CustomerId = dbCustomer.Id;
            sale.Customer = null;

            //// prepare sale address 
            var address = new Address
            {
                AddressName = "Billing",
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = shopWcUrl,
                ModifiedBy = shopWcUrl,
                CreatedFrom = shopWcUrl,
                IsActive = true,
                ShopId = shopId,
                ContactName = sale.Address.ContactName,
                ContactPhone = sale.Address.ContactPhone,
                Country = "Bangladesh",
                District = sale.Address.District,
                PostCode = sale.Address.PostCode,
                StreetAddress =
                                      string.Format(
                                          $"{sale.Address.StreetAddress} {sale.Address.District} {sale.Address.PostCode}"),
                IsDefault = true,
                CustomerId = sale.CustomerId
            };
            sale.Address = address;

            // sale details 

            foreach (SaleDetail detail in sale.SaleDetails)
            {
                AddCommonValues(sale, detail);
                var productDetail = GetProductDetail(db, detail, shopWcUrl, shopId, brandId);
                detail.ShopId = shopId;
                detail.ProductDetailId = productDetail.Id;
                detail.ProductDetail = null;
                detail.SaleId = sale.Id;
            }

            return sale;
        }

        private static ProductDetail GetProductDetail(
            BizBookInventoryContext db,
            SaleDetail detail,
            string shopWcUrl,
            string shopId,
            string brandId)
        {
            ProductDetail productDetail = db.ProductDetails.FirstOrDefault(
                x => x.ShopId == detail.ShopId && x.WcId == detail.WcProductId
                                               && x.WcVariationId == detail.WcProductVariationId);
            if (productDetail == null)
            {
                ProductDetailService productService = new ProductDetailService(new BaseRepository<ProductDetail>(db));
                ProductCategory category =
                    db.ProductCategories.FirstOrDefault(x => x.ShopId == detail.ShopId && x.Name == "Unknown");
                if (category == null)
                {
                    ProductGroup productGroup =
                        db.ProductGroups.FirstOrDefault(x => x.ShopId == detail.ShopId && x.Name == "Unknown");
                    if (productGroup == null)
                    {
                        productGroup = new ProductGroup()
                        {
                            CreatedBy = shopWcUrl,
                            ModifiedBy = shopWcUrl,
                            CreatedFrom = shopWcUrl,
                            ShopId = shopId,
                            IsActive = true,
                            Id = Guid.NewGuid().ToString(),
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            Name = "Unknown",
                        };

                        db.ProductGroups.Add(productGroup);
                        db.SaveChanges();
                    }

                    category = new ProductCategory()
                    {
                        CreatedBy = shopWcUrl,
                        ModifiedBy = shopWcUrl,
                        CreatedFrom = shopWcUrl,
                        ShopId = shopId,
                        IsActive = true,
                        Id = Guid.NewGuid().ToString(),
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Name = "Unknown",
                        ProductGroupId = productGroup.Id
                    };
                    db.ProductCategories.Add(category);
                    db.SaveChanges();
                }

                string barCode = productService.GetBarcode2(shopId);
                productDetail = new ProductDetail()
                {
                    CreatedBy = shopWcUrl,
                    ModifiedBy = shopWcUrl,
                    CreatedFrom = shopWcUrl,
                    ShopId = shopId,
                    IsActive = true,
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Name = detail.ProductDetail.Name,
                    ProductCode = productService.GetProductCode(detail.ProductDetail.Name),
                    BarCode = barCode,
                    BrandId = brandId,
                    CostPrice = 0,
                    DealerPrice = 0,
                    HasExpiryDate = true,
                    OnHand = 0,
                    ProductCategoryId = category.Id,
                    SalePrice = detail.ProductDetail.SalePrice,
                    WcId = (int)detail.WcProductId,
                    WcVariationId = (int)detail.WcProductVariationId,
                    HasUniqueSerial = false,
                };

                db.ProductDetails.Add(productDetail);
                db.SaveChanges();
            }

            return productDetail;
        }

        private string GetBrandId(BizBookInventoryContext db, Shop shop, string createdBy)
        {
            BrandService service = new BrandService(new BaseRepository<Brand>(db));
            Brand brand = service.GetDefaultBrand(shop.Id, createdBy);
            return brand.Id;
        }

        public async Task<IList> DailySalesOverviewAsync(DailySalesOverviewRequestModel request)
        {
            var db = Repository.Db as BizBookInventoryContext;
            request.StartDate = request.StartDate.Date;
            request.EndDate = request.EndDate.Date;
            IQueryable<Sale> qSales = db.Sales.Where(x => x.ShopId == request.ShopId && x.OrderState != OrderState.Cancel && x.Created.Date >= request.StartDate && x.Created.Date <= request.EndDate);
            if (!string.IsNullOrWhiteSpace(request.WarehouseId))
            {
                qSales = qSales.Where(x => x.WarehouseId == request.WarehouseId);
            }

            if (request.SaleFrom != SaleFrom.All)
            {
                qSales = qSales.Where(x => x.SaleFrom == request.SaleFrom);
            }

            var qGroupBy = qSales.Include(x => x.Customer).GroupBy(x => x.Created.Date);
            var list1 = await qGroupBy.OrderBy(x => x.Key).Select(
                x => new
                {
                    Date = x.Key,
                    OrderCount = x.Count(),
                    NewCustomersCount = x.Count(y => y.Customer.Created.Date == x.Key),
                    ProductAmount = x.Sum(y => y.ProductAmount),
                    TotalAmount = x.Sum(y => y.TotalAmount),
                    PayableAmount = x.Sum(y => y.PayableTotalAmount),
                    AverageOrderAmount = x.Sum(y => y.PayableTotalAmount) / x.Count(),
                    PaidAmount = x.Sum(y => y.PaidAmount),
                    DueAmount = x.Sum(y => y.DueAmount),
                    CostAmount = x.Sum(y => y.CostAmount)
                }).ToListAsync();

            return list1;
        }

        public async Task<IList> CustomerSearchBySale(CustomerBySaleRequestModel request)
        {
            var db = this.Repository.Db as BizBookInventoryContext;

            var queryable = db.Sales.Include(x => x.Customer).Where(x => x.ShopId == request.ShopId);
            if (!string.IsNullOrWhiteSpace(request.WarehouseId))
            {
                queryable = queryable.Where(x => x.WarehouseId == request.WarehouseId);
            }

            var sales = await queryable
                            .GroupBy(x => x.CustomerId)
                            .Select(
                                x => new
                                {
                                    CustomerId = x.Key,
                                    PayableAmount = x.Sum(y => y.PayableTotalAmount),
                                    PaidAmount = x.Sum(y => y.PaidAmount),
                                    DueAmount = x.Sum(y => y.DueAmount),
                                    OrderCount = x.Count(),
                                    EndOrderDate = x.Max(z => z.Modified),
                                    StartOrderDate = x.Min(z => z.Modified),
                                    Customer = x.FirstOrDefault().Customer
                                })
                            .Where(x => x.EndOrderDate <= request.EndDate && x.StartOrderDate >= request.StartDate
                                                                      && x.PaidAmount > request.MinimumAmountSpend)
                            .OrderByDescending(x => x.EndOrderDate).Take(100).ToListAsync();

            return sales;
        }

        public async Task<IList> SalesByProductDetail(SalesByProductRequestModel request)
        {
            request.StartDate = request.StartDate.Date;
            request.EndDate = request.EndDate.Date;

            var saleDetails = Db.SaleDetails.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.WarehouseId))
            {
                saleDetails = saleDetails.Where(x => x.WarehouseId == request.WarehouseId);
            }

            var allTotal = saleDetails.Sum(x => x.Total);

            var queryable = saleDetails.Include(x => x.ProductDetail)
                .Where(x => x.ShopId == request.ShopId && x.Created.Date >= request.StartDate && x.Created.Date <= request.EndDate);
            var groups = await queryable.GroupBy(x => x.ProductDetailId).Select(
                             x => new
                             {
                                 Id = x.Key,
                                 Product = x.FirstOrDefault().ProductDetail,
                                 Quantity = x.Sum(y => y.Quantity),
                                 CostTotal = x.Sum(y => y.CostTotal),
                                 PriceTotal = x.Sum(y => y.PriceTotal),
                                 DiscountTotal = x.Sum(y => y.DiscountTotal),
                                 Total = x.Sum(y => y.Total),
                                 TotalPercent = (x.Sum(y => y.Total) / allTotal) * 100,
                                 Paid = x.Sum(y => y.PaidAmount),
                                 Due = x.Sum(y => y.DueAmount),
                                 SaleCount = x.Select(y => y.SaleId).Distinct().Count()
                             }).OrderByDescending(x => x.Total).ToListAsync();
            return groups;
        }

        public async Task<IList> SalesByProductCategory(SalesByProductRequestModel request)
        {
            request.StartDate = request.StartDate.Date;
            request.EndDate = request.EndDate.Date;

            var saleDetails = Db.SaleDetails.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.WarehouseId))
            {
                saleDetails = saleDetails.Where(x => x.WarehouseId == request.WarehouseId);
            }

            var allTotal = saleDetails.Sum(x => x.Total);

            var queryable = saleDetails.Include(x => x.ProductDetail).Include(x => x.ProductDetail.ProductCategory)
                .Where(x => x.ShopId == request.ShopId && x.Created.Date >= request.StartDate && x.Created.Date <= request.EndDate);
            var groups = await queryable.GroupBy(x => x.ProductDetail.ProductCategoryId).Select(
                             x => new
                             {
                                 Id = x.Key,
                                 Product = x.FirstOrDefault().ProductDetail.ProductCategory,
                                 Quantity = x.Sum(y => y.Quantity),
                                 CostTotal = x.Sum(y => y.CostTotal),
                                 PriceTotal = x.Sum(y => y.PriceTotal),
                                 DiscountTotal = x.Sum(y => y.DiscountTotal),
                                 Total = x.Sum(y => y.Total),
                                 TotalPercent = (x.Sum(y => y.Total) / allTotal) * 100,
                                 Paid = x.Sum(y => y.PaidAmount),
                                 Due = x.Sum(y => y.DueAmount),
                                 SaleCount = x.Select(y => y.SaleId).Distinct().Count()
                             }).OrderByDescending(x => x.Total).ToListAsync();
            return groups;
        }

        public async Task<IList> SalesByProductGroup(SalesByProductRequestModel request)
        {
            request.StartDate = request.StartDate.Date;
            request.EndDate = request.EndDate.Date;

            var saleDetails = Db.SaleDetails.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.WarehouseId))
            {
                saleDetails = saleDetails.Where(x => x.WarehouseId == request.WarehouseId);
            }

            var queryable = saleDetails
                .Where(x => x.ShopId == request.ShopId && x.Created.Date >= request.StartDate && x.Created.Date <= request.EndDate)
                .Include(x => x.ProductDetail)
                .Include(x => x.ProductDetail.ProductCategory)
                .Include(x => x.ProductDetail.ProductCategory.ProductGroup);
            var allTotal = queryable.Where(x => x.Total != null).Sum(x => x.Total);
            var groups = await queryable.GroupBy(x => x.ProductDetail.ProductCategory.ProductGroupId).Select(
                             x => new
                             {
                                 Id = x.Key,
                                 Product = x.FirstOrDefault().ProductDetail.ProductCategory.ProductGroup,
                                 Quantity = x.Sum(y => y.Quantity),
                                 CostTotal = x.Sum(y => y.CostTotal),
                                 PriceTotal = x.Sum(y => y.PriceTotal),
                                 DiscountTotal = x.Sum(y => y.DiscountTotal),
                                 Total = x.Sum(y => y.Total),
                                 TotalPercent = (x.Sum(y => y.Total) / allTotal) * 100,
                                 Paid = x.Sum(y => y.PaidAmount),
                                 Due = x.Sum(y => y.DueAmount),
                                 SaleCount = x.Select(y => y.SaleId).Distinct().Count()
                             }).OrderByDescending(x => x.Total).ToListAsync();
            return groups;
        }

        public bool SalesDuesUpdate(SalesDuesUpdateModel model)
        {
            using (var scope = new TransactionScope())
            {
                var db = Repository.Db as BizBookInventoryContext;
                AccountHead head = db.AccountHeads.First(x => x.ShopId == model.ShopId && x.Name == "Sale");
                model.Transaction.AccountHeadId = head.Id;
                model.Transaction.AccountHeadName = head.Name;
                model.Transaction.TransactionFlowType = TransactionFlowType.Income;
                model.Transaction.TransactionFor = TransactionFor.Sale;
                model.Transaction.TransactionWith = TransactionWith.Customer;

                var saleDues = model.Sales.Where(x => x.NewlyPaid > 0).ToList();
                foreach (var s in saleDues)
                {
                    Sale sale = db.Sales.Find(s.Id);
                    if (sale != null)
                    {
                        Transaction transaction = JsonConvert.DeserializeObject<Transaction>(JsonConvert.SerializeObject(model.Transaction));
                        transaction.Id = Guid.NewGuid().ToString();
                        transaction.ParentId = sale.CustomerId;
                        transaction.OrderId = sale.Id;
                        transaction.OrderNumber = sale.OrderNumber;
                        transaction.Amount = s.NewlyPaid;
                        this.transactionService.Add(transaction);
                    }
                }

                scope.Complete();

                return true;
            }
        }

        public async Task<IList> DeliveredProductCategories(SaleRequestModel request)
        {
            var dbContext = this.Repository.Db as BizBookInventoryContext;
            IQueryable<SaleDetail> saleDetails = dbContext.Sales.Where(x => x.ShopId == request.ShopId && x.OrderState == OrderState.Delivered)
                .Include(x => x.SaleDetails).SelectMany(x => x.SaleDetails);
            List<SaleDetail> details = await saleDetails.Include(x => x.ProductDetail).Include(x => x.ProductDetail.ProductCategory).ToListAsync();
            var list = details.GroupBy(x => x.ProductDetail.ProductCategoryId).Select(
                x => new
                {
                    ProductCategoryId = x.Key,
                    ProductCategory =
                                 new ProductCategoryViewModel(x.FirstOrDefault().ProductDetail.ProductCategory),
                    Quantity = x.Sum(y => y.Quantity),
                    Total = x.Sum(y => y.Total),
                    Cost = x.Sum(y => y.CostTotal),
                    Paid = x.Sum(y => y.PaidAmount),
                    Due = x.Sum(y => y.DueAmount),
                    Percent = 0
                }).ToList();

            return list;
        }
    }
}
