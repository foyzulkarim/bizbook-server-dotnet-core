using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class SaleState : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string State { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleId { get; set; }

        public Sale Sale { get; set; }
    }
}
