using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class SupplierProduct : ShopChild
    {
        public SupplierProduct()
        {
            SupplierProductTransactions = new HashSet<SupplierProductTransaction>();
        }

        public double Quantity { get; set; }

        public double TotalPrice { get; set; }

        public double Paid { get; set; }

        public double Due { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SupplierId { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<SupplierProductTransaction> SupplierProductTransactions { get; set; }

    }
}
