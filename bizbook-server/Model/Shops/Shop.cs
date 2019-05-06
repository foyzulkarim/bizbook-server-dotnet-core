using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Model;

namespace Model.Shops
{
    public partial class Shop : Entity
    {
        public Shop()
        {
            AccountHeads = new HashSet<AccountHead>();
            AccountInfoes = new HashSet<AccountInfo>();
            Addresses = new HashSet<Address>();
            Brands = new HashSet<Brand>();
            Couriers = new HashSet<Courier>();            
            Customers = new HashSet<Customer>();
            Damages = new HashSet<Damage>();
            DealerProductTransactions = new HashSet<DealerProductTransaction>();
            DealerProducts = new HashSet<DealerProduct>();
            Dealers = new HashSet<Dealer>();
            EmployeeInfoes = new HashSet<EmployeeInfo>();
            HookDetails = new HashSet<HookDetail>();
            InstallmentDetails = new HashSet<InstallmentDetail>();
            Installments = new HashSet<Installment>();
            ProductCategories = new HashSet<ProductCategory>();
            ProductDetails = new HashSet<ProductDetail>();
            ProductGroups = new HashSet<ProductGroup>();
            ProductImages = new HashSet<ProductImage>();
            ProductSerials = new HashSet<ProductSerial>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            Purchases = new HashSet<Purchase>();
            SaleDetails = new HashSet<SaleDetail>();
            SaleStates = new HashSet<SaleState>();
            Sales = new HashSet<Sale>();
            Sms = new HashSet<Sms>();
            SmsHistories = new HashSet<SmsHistory>();
            SmsHooks = new HashSet<SmsHook>();
            StockTransferDetails = new HashSet<StockTransferDetail>();
            StockTransfers = new HashSet<StockTransfer>();
            SupplierProductTransactions = new HashSet<SupplierProductTransaction>();
            SupplierProducts = new HashSet<SupplierProduct>();
            SuppliersShop = new HashSet<Supplier>();
            SuppliersShopId1Navigation = new HashSet<Supplier>();
            SuppliersSupplierShop = new HashSet<Supplier>();
            Transactions = new HashSet<Transaction>();
            WarehouseProducts = new HashSet<WarehouseProduct>();
            WarehouseZones = new HashSet<WarehouseZone>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(512)")]
        public string StreetAddress { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Area { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Thana { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string PostCode { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string District { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonPhone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonDesignation { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Website { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Facebook { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string About { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SubscriptionType { get; set; }

        public int TotalUsers { get; set; }

        public bool IsVerified { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcUrl { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string LogoUrl { get; set; }

        public bool HasDeliveryChain { get; set; }

        public bool IsShowOrderNumber { get; set; }

        public bool IsAutoAddToCart { get; set; }

        public float DeliveryCharge { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ReceiptName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ChalanName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcKey { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcSecret { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string WcVersion { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcWebhookSource { get; set; }

        public ICollection<AccountHead> AccountHeads { get; set; }

        public ICollection<AccountInfo> AccountInfoes { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Brand> Brands { get; set; }

        public ICollection<Courier> Couriers { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ICollection<Damage> Damages { get; set; }

        public ICollection<DealerProductTransaction> DealerProductTransactions { get; set; }

        public ICollection<DealerProduct> DealerProducts { get; set; }

        public ICollection<Dealer> Dealers { get; set; }
        public ICollection<EmployeeInfo> EmployeeInfoes { get; set; }

        public ICollection<HookDetail> HookDetails { get; set; }

        public ICollection<InstallmentDetail> InstallmentDetails { get; set; }

        public ICollection<Installment> Installments { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }

        public ICollection<ProductGroup> ProductGroups { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<ProductSerial> ProductSerials { get; set; }

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

        public ICollection<SaleState> SaleStates { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<Sms> Sms { get; set; }

        public ICollection<SmsHistory> SmsHistories { get; set; }

        public ICollection<SmsHook> SmsHooks { get; set; }

        public ICollection<StockTransferDetail> StockTransferDetails { get; set; }

        public ICollection<StockTransfer> StockTransfers { get; set; }

        public ICollection<SupplierProductTransaction> SupplierProductTransactions { get; set; }
        
        public ICollection<SupplierProduct> SupplierProducts { get; set; }

        public ICollection<Supplier> SuppliersShop { get; set; }

        public ICollection<Supplier> SuppliersShopId1Navigation { get; set; }

        public ICollection<Supplier> SuppliersSupplierShop { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<WarehouseProduct> WarehouseProducts { get; set; }

        public ICollection<WarehouseZone> WarehouseZones { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }

    }
}
