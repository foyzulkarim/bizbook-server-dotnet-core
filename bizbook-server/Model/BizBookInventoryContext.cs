using Microsoft.EntityFrameworkCore;
using Model.Model;
using Model.ModelBuilders;
using Model.Shops;

namespace Model
{
    public partial class BizBookInventoryContext : DbContext
    {
        public virtual DbSet<AccountHead> AccountHeads { get; set; }
        public virtual DbSet<AccountInfo> AccountInfoes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Damage> Damages { get; set; }
        public virtual DbSet<DealerProduct> DealerProducts { get; set; }
        public virtual DbSet<DealerProductTransaction> DealerProductTransactions { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }
        public virtual DbSet<HookDetail> HookDetails { get; set; }
        public virtual DbSet<InstallmentDetail> InstallmentDetails { get; set; }
        public virtual DbSet<Installment> Installments { get; set; }     
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductSerial> ProductSerials { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleState> SaleStates { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Sms> Sms { get; set; }
        public virtual DbSet<SmsHistory> SmsHistories { get; set; }
        public virtual DbSet<SmsHook> SmsHooks { get; set; }
        public virtual DbSet<StockTransferDetail> StockTransferDetails { get; set; }
        public virtual DbSet<StockTransfer> StockTransfers { get; set; }
        public virtual DbSet<SupplierProduct> SupplierProducts { get; set; }
        public virtual DbSet<SupplierProductTransaction> SupplierProductTransactions { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseZone> WarehouseZones { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }

        public BizBookInventoryContext(DbContextOptions<BizBookInventoryContext> options): base(options)
        {
            
        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=.;Database=BizBookCoreDb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            BizBookModelBuilder.BuildModels(modelBuilder);
        }
    }
}
