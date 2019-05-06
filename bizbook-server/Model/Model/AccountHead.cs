using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class AccountHead : ShopChild
    {
        public AccountHead()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

        public AccountType AccountHeadType { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
