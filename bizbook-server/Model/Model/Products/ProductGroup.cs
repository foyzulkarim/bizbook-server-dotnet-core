using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Products
{
    public class ProductGroup : ShopChild
    {
        [Required]
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();
    }
}
