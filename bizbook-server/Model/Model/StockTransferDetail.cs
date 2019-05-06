using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class StockTransferDetail : ShopChild
    {
        public double Quantity { get; set; }

        public double SalePricePerUnit { get; set; }

        public double PriceTotal { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string StockTransferId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SourceWarehouseId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DestinationWarehouseId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Remarks { get; set; }

        public Warehouse DestinationWarehouse { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public Warehouse SourceWarehouse { get; set; }

        public StockTransfer StockTransfer { get; set; }

    }
}
