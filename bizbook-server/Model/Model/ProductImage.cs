using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class ProductImage : ShopChild
    {
        public int WcId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Src { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Alt { get; set; }

        public int? Position { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        public ProductDetail ProductDetail { get; set; }

    }
}
