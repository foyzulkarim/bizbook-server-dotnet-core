using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model.Transactions
{
    public class AccountHead : ShopChild
    {

        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

        public AccountType AccountHeadType { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

    }
}
