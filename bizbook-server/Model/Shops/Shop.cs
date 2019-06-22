using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Model;
using Model.Model.Customers;
using Model.Model.Products;
using Model.Model.Purchases;
using Model.Model.Sales;
using Model.Model.Transactions;

namespace Model.Shops
{
    public class Shop : Entity
    {
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



        public ICollection<Employee> Employees { get; set; }

        #region Products

        public ICollection<Brand> Brands { get; set; }
        public ICollection<ProductGroup> ProductGroups { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }

        #endregion

        #region Purchases

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        #endregion

        #region Sales
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Dealer> Dealers { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
        public ICollection<SaleState> SaleStates { get; set; }

        #endregion

        #region Transactions

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<AccountHead> AccountHeads { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        #endregion

    }
}
