using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class AccountInfo : ShopChild
    {
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string AccountTitle { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string BankName { get; set; }

        public AccountInfoType AccountInfoType { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

    }
}
