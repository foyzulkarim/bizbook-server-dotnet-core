using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class WarehouseZone : ShopChild
    {

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ZoneId { get; set; }

        public Warehouse Warehouse { get; set; }

        public Zone Zone { get; set; }

    }
}
