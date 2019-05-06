using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class InstallmentDetail : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string InstallmentId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string TansactionId { get; set; }

        public double ScheduledAmount { get; set; }

        public double PaidAmount { get; set; }

        public double DueAmount { get; set; }

        public DateTime ScheduledDate { get; set; }

        public DateTime? PaidDate { get; set; }

        public Installment Installment { get; set; }

        public Sale Sale { get; set; }

        public Transaction Tansaction { get; set; }

    }
}
