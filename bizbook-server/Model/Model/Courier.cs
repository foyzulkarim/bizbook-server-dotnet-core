using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Courier : ShopChild
    {
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string ContactPersonName { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string CourierShopId { get; set; }
       
        [Column(TypeName = "varchar(64)")]
        public string CourierShopName { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string CourierShopPhone { get; set; }
    }
}
