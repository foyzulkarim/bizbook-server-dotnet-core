using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Purchase : ShopChild
    {
        public Purchase()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

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

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        public DateTime? OrderDate { get; set; }

        public Supplier Supplier { get; set; }

        public Warehouse Warehouse { get; set; }

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

    }
}
