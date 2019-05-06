using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class ProductSerial : ShopChild
    {

        [Column(TypeName = "varchar(128)")]
        public string SerialNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string PurchaseDetailId { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public PurchaseDetail PurchaseDetail { get; set; }

    }
}
