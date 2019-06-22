using System.ComponentModel.DataAnnotations.Schema;
using Model.Model.Products;

namespace Model.Model.Purchases
{
    public class PurchaseDetail : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string PurchaseId { get; set; }

        public double Quantity { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        public double CostPricePerUnit { get; set; }

        public double CostTotal { get; set; }

        public double Paid { get; set; }

        public double Payable { get; set; }


        [ForeignKey("ProductDetailId")]
        public virtual ProductDetail ProductDetail { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

    }
}
