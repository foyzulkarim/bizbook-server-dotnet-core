using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model.Transactions
{
    public class Transaction : ShopChild
    {
        public TransactionFlowType TransactionFlowType { get; set; }
        public TransactionMedium TransactionMedium { get; set; }

        public TransactionFor TransactionFor { get; set; }
        public TransactionWith TransactionWith { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ParentId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ParentName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string OrderNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string OrderId { get; set; }

        public double Amount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string TransactionNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonPhone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string AccountHeadId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WalletId { get; set; }

        public DateTime? TransactionDate { get; set; }

        [ForeignKey("AccountHeadId")]
        public virtual AccountHead AccountHead { get; set; }

        [ForeignKey("WalletId")]
        public virtual Wallet Wallet { get; set; }
    }
}
