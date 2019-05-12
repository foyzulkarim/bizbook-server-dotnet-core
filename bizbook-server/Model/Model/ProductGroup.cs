
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class ProductGroup : ShopChild
    {
        public ProductGroup()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
