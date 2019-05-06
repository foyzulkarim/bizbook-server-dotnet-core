using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class Transaction : ShopChild
    {
        public Transaction()
        {
            DealerProductTransactions = new HashSet<DealerProductTransaction>();
            InstallmentDetails = new HashSet<InstallmentDetail>();
            SupplierProductTransactions = new HashSet<SupplierProductTransaction>();
        }
        public TransactionFlowType TransactionFlowType { get; set; }
        public TransactionMedium TransactionMedium { get; set; }

        public int PaymentGatewayService { get; set; }
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
        public string TransactionMediumName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string PaymentGatewayServiceName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string TransactionNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonPhone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string AccountHeadName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string AccountHeadId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string AccountInfoId { get; set; }

        public DateTime? TransactionDate { get; set; }

        public AccountHead AccountHead { get; set; }

        public AccountInfo AccountInfo { get; set; }

        public ICollection<DealerProductTransaction> DealerProductTransactions { get; set; }

        public ICollection<InstallmentDetail> InstallmentDetails { get; set; }

        public ICollection<SupplierProductTransaction> SupplierProductTransactions { get; set; }

    }
}
