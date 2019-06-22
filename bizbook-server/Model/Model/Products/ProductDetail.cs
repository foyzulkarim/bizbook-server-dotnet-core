using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Model.Purchases;
using Model.Model.Sales;

namespace Model.Model.Products
{
    public class ProductDetail : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Model { get; set; }


        [Column(TypeName = "varchar(128)")]
        public string BarCode { get; set; }

        public bool HasUniqueSerial { get; set; }

        public bool HasWarrenty { get; set; }

        public double SalePrice { get; set; }

        public double CostPrice { get; set; }

        public int StartingInventory { get; set; }

        public double Purchased { get; set; }

        public double Sold { get; set; }

        public double OnHand { get; set; }

        public int MinimumStockToNotify { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductCategoryId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string BrandId { get; set; }

        public bool HasExpiryDate { get; set; }

        public int ExpireInDays { get; set; }

        public double DealerPrice { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductCode { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }


        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new HashSet<PurchaseDetail>();

        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new HashSet<SaleDetail>();
    }
}