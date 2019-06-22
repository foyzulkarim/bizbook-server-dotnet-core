using System.ComponentModel.DataAnnotations.Schema;
using Model.Model.Products;

namespace Model.Model.Sales
{
    public class SaleDetail : ShopChild
    {
        public double Quantity { get; set; }

        public double CostPricePerUnit { get; set; }

        public double CostTotal { get; set; }

        public double SalePricePerUnit { get; set; }

        public double PriceTotal { get; set; }

        public double DiscountTotal { get; set; }

        public double Total { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductSerialNumber { get; set; }

        public bool IsReturned { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ReturnReason { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        public double PaidAmount { get; set; }

        public double DueAmount { get; set; }


        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [ForeignKey("ProductDetailId")]
        public virtual ProductDetail ProductDetail { get; set; }

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }


    }
}
