using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Installment : ShopChild
    {
        public Installment()
        {
            InstallmentDetails = new HashSet<InstallmentDetail>();
            Sales = new HashSet<Sale>();
        }

        public double CashPriceAmount { get; set; }

        public double ProfitPercent { get; set; }

        public double ProfitAmount { get; set; }

        public double InstallmentTotalAmount { get; set; }

        public double DownPaymentPercent { get; set; }

        public double DownPaymentAmount { get; set; }

        public double InstallmentDueAmount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string InstallmentMonth { get; set; }

        public double InstallmentPerMonthAmount { get; set; }

        public int SaleType { get; set; }

        public double CashPriceDueAmount { get; set; }

        public double ProfitAmountPerMonth { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleId { get; set; }

        public ICollection<InstallmentDetail> InstallmentDetails { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
