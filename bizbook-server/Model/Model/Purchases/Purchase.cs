using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Purchases
{
    public class Purchase : ShopChild
    {

        [Column(TypeName = "varchar(128)")]
        public string OrderNumber { get; set; }

        public double ShippingAmount { get; set; }

        public double ProductAmount { get; set; }

        public double OtherAmount { get; set; }

        public double DiscountAmount { get; set; }

        public double TotalAmount { get; set; }

        public double PaidAmount { get; set; }

        public double DueAmount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string State { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ShippingProvider { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ShipmentTrackingNo { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SupplierId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string OrderReferenceNumber { get; set; }


        public DateTime? OrderDate { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new HashSet<PurchaseDetail>();

    }
}
