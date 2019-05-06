using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Damage : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        public double Quantity { get; set; }

        public ProductDetail ProductDetail { get; set; }    
        
        public Warehouse Warehouse { get; set; }
    }
}
