using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class ProductCategory : ShopChild
    {
        public ProductCategory()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        public int WcId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
