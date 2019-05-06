using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class DealerProduct : ShopChild
    {
        public DealerProduct()
        {
            DealerProductTransactions = new HashSet<DealerProductTransaction>();
        }

        public double Quantity { get; set; }

        public double TotalPrice { get; set; }

        public double Paid { get; set; }

        public double Due { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ProductDetailId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DealerId { get; set; }

        public Dealer Dealer { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public ICollection<DealerProductTransaction> DealerProductTransactions { get; set; }
    }
}
