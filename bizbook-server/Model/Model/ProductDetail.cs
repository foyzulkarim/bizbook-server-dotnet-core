using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class ProductDetail : ShopChild
    {
        public ProductDetail()
        {
            Damages = new HashSet<Damage>();
            DealerProducts = new HashSet<DealerProduct>();
            ProductImages = new HashSet<ProductImage>();
            ProductSerials = new HashSet<ProductSerial>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            SaleDetails = new HashSet<SaleDetail>();
            StockTransferDetails = new HashSet<StockTransferDetail>();
            SupplierProducts = new HashSet<SupplierProduct>();
            WarehouseProducts = new HashSet<WarehouseProduct>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Model { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Year { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string BarCode { get; set; }

        public bool HasUniqueSerial { get; set; }

        public bool HasWarrenty { get; set; }

        public double SalePrice { get; set; }

        public double CostPrice { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Type { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Color { get; set; }

        public int StartingInventory { get; set; }

        public double Purchased { get; set; }

        public double Sold { get; set; }

        public double OnHand { get; set; }

        public int MinimumStockToNotify { get; set; }

        public int WcId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Permalink { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcType { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Tags { get; set; }

        public int WcCategoryId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string RelatedIds { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcVariationPermalink { get; set; }

        public int WcVariationId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcVariationOption { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductCategoryId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string BrandId { get; set; }

        public bool HasExpiryDate { get; set; }

        public int ExpireInDays { get; set; }

        public double DealerPrice { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductCode { get; set; }

        public Brand Brand { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<Damage> Damages { get; set; }

        public ICollection<DealerProduct> DealerProducts { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<ProductSerial> ProductSerials { get; set; }

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

        public ICollection<StockTransferDetail> StockTransferDetails { get; set; }

        public ICollection<SupplierProduct> SupplierProducts { get; set; }

        public ICollection<WarehouseProduct> WarehouseProducts { get; set; }

    }
}