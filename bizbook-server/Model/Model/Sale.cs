using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class Sale : ShopChild
    {
        public Sale()
        {
            InstallmentDetails = new HashSet<InstallmentDetail>();
            SaleDetails = new HashSet<SaleDetail>();
            SaleStates = new HashSet<SaleState>();
        }

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

        [Column(TypeName = "varchar(128)")]
        public string CourierShopId { get; set; }

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

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? RequiredDeliveryDateByCustomer { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string RequiredDeliveryTimeByCustomer { get; set; }

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

        public int? WcId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcOrderKey { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcCartHash { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WcOrderStatus { get; set; }

        public double DeliveryChargeAmount { get; set; }

        public int? WcCustomerId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string OrderReferenceNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string EmployeeInfoId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string EmployeeInfoName { get; set; }

        public double PaidByCashAmount { get; set; }

        public double PaidByOtherAmount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        public bool IsTaggedSale { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleTag { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Guarantor1Id { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Guarantor2Id { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string InstallmentId { get; set; }

        public DateTime? OrderDate { get; set; }

        public Address Address { get; set; }

        public Customer Customer { get; set; }

        public Dealer Dealer { get; set; }
        public EmployeeInfo EmployeeInfo { get; set; }

        public Installment Installment { get; set; }

        public Warehouse Warehouse { get; set; }

        public ICollection<InstallmentDetail> InstallmentDetails { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

        public ICollection<SaleState> SaleStates { get; set; }

        [NotMapped] public List<Transaction> Transactions { get; set; }

        [NotMapped] public OrderState NextOrderState { get; set; }
    }

}
