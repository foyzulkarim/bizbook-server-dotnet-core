using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Products
{
    public class ProductCategory : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        public int WcId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductGroupId { get; set; }

        [ForeignKey("ProductGroupId")]
        public ProductGroup ProductGroup { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new HashSet<ProductDetail>();

    }
}
