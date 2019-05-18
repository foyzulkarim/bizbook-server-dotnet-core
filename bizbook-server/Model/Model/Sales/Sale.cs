using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;
using Model.Model.Customers;
using Model.Model.Transactions;

namespace Model.Model.Sales
{
    public class Sale : ShopChild
    {
        [Column(TypeName = "varchar(50)")]
        public string OrderNumber { get; set; }

        public double ProductAmount { get; set; }

        public double TaxAmount { get; set; }

        public double PaymentServiceChargeAmount { get; set; }

        public double OtherAmount { get; set; }

        public double TotalAmount { get; set; }

        public double DiscountAmount { get; set; }

        public double PayableTotalAmount { get; set; }

        public double PaidAmount { get; set; }

        public double DueAmount { get; set; }

        public double CostAmount { get; set; }

        public double ProfitAmount { get; set; }

        public double ProfitPercent { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string CourierName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DeliveryTrackingNo { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DeliverymanId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DeliverymanName { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string DeliverymanPhone { get; set; }

        public DateTime? RequiredDeliveryDate { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string RequiredDeliveryTime { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string CustomerId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string AddressId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string CustomerArea { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string CustomerName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string CustomerPhone { get; set; }

        [Column(TypeName = "varchar(800)")]
        public string CustomerNote { get; set; }

        public bool IsDealerSale { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DealerId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Remarks { get; set; }

        public int Version { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ParentSaleId { get; set; }

        public SaleChannel SaleChannel { get; set; }
        public SaleFrom SaleFrom { get; set; }
        public OrderState OrderState { get; set; }

        public double DeliveryChargeAmount { get; set; }

        public int? WcCustomerId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string OrderReferenceNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string EmployeeId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string EmployeeName { get; set; }


        public bool IsTaggedSale { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleTag { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("DealerId")]
        public virtual Dealer Dealer { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new HashSet<SaleDetail>();

        public virtual ICollection<SaleState> SaleStates { get; set; } = new HashSet<SaleState>();

        [NotMapped] public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [NotMapped] public OrderState NextOrderState { get; set; }
    }

}
