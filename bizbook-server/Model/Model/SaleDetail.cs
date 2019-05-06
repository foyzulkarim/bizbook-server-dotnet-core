using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class SaleDetail : ShopChild
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

        public int? WcId { get; set; }

        public int? WcProductId { get; set; }

        public int? WcProductVariationId { get; set; }

        public double PaidAmount { get; set; }

        public double DueAmount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public Sale Sale { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}
