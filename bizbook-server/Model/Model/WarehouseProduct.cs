using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class WarehouseProduct : ShopChild
    {
        public int StartingInventory { get; set; }

        public double Purchased { get; set; }

        public double Sold { get; set; }

        public double TransferredIn { get; set; }

        public double TransferredOut { get; set; }

        public double OnHand { get; set; }

        public int MinimumStockToNotify { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}
