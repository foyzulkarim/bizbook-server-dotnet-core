using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class DealerProductTransaction : ShopChild
    {
        public double Amount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string TransactionId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DealerProductId { get; set; }

        public DealerProduct DealerProduct { get; set; }

        public Transaction Transaction { get; set; }
    }
}
