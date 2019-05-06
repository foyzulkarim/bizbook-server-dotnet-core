using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class PurchaseDetail : ShopChild
    {
        public PurchaseDetail()
        {
            ProductSerials = new HashSet<ProductSerial>();
        }

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

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public Purchase Purchase { get; set; }

        public Warehouse Warehouse { get; set; }

        public ICollection<ProductSerial> ProductSerials { get; set; }

    }
}
