using System;
using System.Collections.Generic;
using System.Linq;
using Model.Constants;
using Model.Model;
using Model.Model.Sales;
using Model.Shops;
using ViewModel.Customers;
using ViewModel.Shops;

namespace ViewModel.Sales
{
    using Transactions;

    public class SaleViewModel : BaseViewModel<Sale>
    {
        public SaleViewModel(Sale x) : base(x)
        {
            OrderNumber = x.OrderNumber;
            OrderReferenceNumber = x.OrderReferenceNumber;

            #region Amounts

            ProductAmount = x.ProductAmount;
            DeliveryChargeAmount = x.DeliveryChargeAmount;
            ShippingAmount = x.DeliveryChargeAmount;
            TaxAmount = x.TaxAmount;
            PaymentServiceChargeAmount = x.PaymentServiceChargeAmount;
            OtherAmount = x.OtherAmount;
            TotalAmount = x.TotalAmount;
            DiscountAmount = x.DiscountAmount;
            PayableTotalAmount = x.PayableTotalAmount;
            PaidAmount = x.PaidAmount;
            DueAmount = x.DueAmount;
            CostAmount = x.CostAmount;
            ProfitAmount = x.ProfitAmount;
            ProfitPercent = x.ProfitPercent;

            #endregion

            #region Delevery

            ShippingProvider = x.CourierName;
            ShipmentTrackingNo = x.DeliveryTrackingNo;
            DeliverymanId = x.DeliverymanId;
            DeliverymanName = x.DeliverymanName;
            DeliverymanPhone = x.DeliverymanPhone;


            if (x.RequiredDeliveryDate != null)
                this.RequiredDeliveryDateByCustomer = x.RequiredDeliveryDate.Value;

            if (x.RequiredDeliveryTime != null)
                this.RequiredDeliveryTimeByCustomer = x.RequiredDeliveryTime;


            #endregion

            #region Customer

            CustomerId = x.CustomerId;

            if (x.Customer != null)
            {
                Customer = new CustomerViewModel(x.Customer);
            }

            AddressId = x.AddressId;
            if (x.Address != null)
            {
                Address = new AddressViewModel(x.Address);
            }

            CustomerArea = x.CustomerArea;
            CustomerName = x.CustomerName;
            CustomerPhone = x.CustomerPhone;
            CustomerNote = x.CustomerNote;

            #endregion

            #region Dealer

            IsDealerSale = x.IsDealerSale;
            DealerId = x.DealerId;
            if (x.Dealer != null)
            {
                // dealer population
                Dealer = new DealerViewModel(x.Dealer);
            }

            #endregion

            ShopId = x.ShopId;
            if (x.SaleStates != null)
            {
                SaleStates = x.SaleStates.OrderByDescending(y => y.Modified).ToList()
                    .ConvertAll(y => new SaleStateViewModel(y)).ToList();
            }

            if (x.Transactions != null)
            {
                Transactions = x.Transactions.OrderByDescending(y => y.Modified).ToList()
                    .ConvertAll(y => new TransactionViewModel(y)).ToList();
            }

            //if (CurrentState.CurrentState > OrderState.Pending && CurrentState.CurrentState < OrderState.Completed)
            //{
            //    PreviousState = CurrentState.PreviousSaleStateObject;
            //}
            var saleContext = new SaleContext(x.OrderState);
            CurrentState = saleContext.State;
            if (CurrentState.CurrentState < OrderState.Completed)
            {
                NextState = CurrentState.NextSaleStateObject;
            }

            //  ShippingAmount = x.ShippingAmount;
            Remarks = x.Remarks;
            IsActive = x.IsActive;
            Version = x.Version;
            this.SaleChannel = x.SaleChannel;
            this.SaleFrom = x.SaleFrom;
            OrderFromName = x.SaleFrom.ToString();
            OrderState = x.OrderState;
            if (x.SaleDetails != null)
            {
                SaleDetails = x.SaleDetails.ToList().ConvertAll(y => new SaleDetailViewModel(y)).ToList();
            }

            Date = x.Modified.ToString("dd-MMM-yyyy");
            EmployeeInfoId = x.EmployeeId;
            EmployeeInfoName = x.EmployeeName;

            if (x.Employee != null)
            {
                Employee = x.Employee;
            }



        }

        public string InstallmentId { get; set; }

        // public double PaymentServiceChargeAmount { get; set; }

        // public double DeliveryChargeAmount { get; set; }

        // public double PayableTotalAmount { get; set; }

        //   public string AddressId { get; set; }

        //  public AddressViewModel Address { get; set; }

        //  public ShopViewModel Shop { get; set; }

        //   public string CustomerNote { get; set; }

        //  public List<SaleStateViewModel> SaleStates { get; set; }
        //   public List<TransactionViewModel> Transactions { get; set; }

        //   public string DeliverymanName { get; set; }

        //   public string DeliverymanId { get; set; }

        //   public string CourierShopId { get; set; }

        public SaleOrderState NextState { get; set; }

        public SaleOrderState PreviousState { get; set; }

        public SaleOrderState CurrentState { get; set; }


        [IsViewable] public string OrderNumber { get; set; }
        public string OrderReferenceNumber { get; set; }

        #region Amounts

        public double ProductAmount { get; set; }
        public double DeliveryChargeAmount { get; set; }
        public double TaxAmount { get; set; }
        public double PaymentServiceChargeAmount { get; set; }
        public double PayableTotalAmount { get; set; }
        public double OtherAmount { get; set; } = 0;
        [IsViewable] public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        [IsViewable] public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public double CostAmount { get; set; }
        public double ProfitAmount { get; set; }
        public double ProfitPercent { get; set; }

        public double PaidByCashAmount { get; set; }
        public double PaidByOtherAmount { get; set; }

        #endregion

        #region Delivery

        public string CourierShopId { get; set; }
        public virtual Shop CourierShop { get; set; }
        public string CourierName { get; set; }
        public string DeliveryTrackingNo { get; set; }
        public string DeliverymanId { get; set; }
        public string DeliverymanName { get; set; }
        public string DeliverymanPhone { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime RequiredDeliveryDateByCustomer { get; set; }
        public string RequiredDeliveryTimeByCustomer { get; set; }
        public DateTime OrderDate { get; set; }

        #endregion

        #region  Customer

        public string CustomerId { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
        public string AddressId { get; set; }
        public AddressViewModel Address { get; set; }
        public string CustomerArea { get; set; }
        [IsViewable] public string CustomerName { get; set; }
        [IsViewable] public string CustomerPhone { get; set; }
        public string CustomerNote { get; set; }
        public string Guarantor1Id { get; set; }

        public string Guarantor2Id { get; set; }

        #endregion

        #region Dealer

        public bool IsDealerSale { get; set; }
        public string DealerId { get; set; }
        public virtual DealerViewModel Dealer { get; set; }

        #endregion

        public ShopViewModel Shop { get; set; }
        public List<SaleStateViewModel> SaleStates { get; set; }

        public List<TransactionViewModel> Transactions { get; set; }

        //public SaleOrderState NextState { get; set; }
        //public SaleOrderState PreviousState { get; set; }
        //public SaleOrderState CurrentState { get; set; }
        public string ShopId { get; set; }
        public double ShippingAmount { get; set; } = 0;
        public string State { get; set; }
        public string ShippingProvider { get; set; }
        public string ShipmentTrackingNo { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; } = true;
        public int Version { get; set; }
        public string ParentSaleId { get; set; }
        public SaleChannel SaleChannel { get; set; }
        public SaleFrom SaleFrom { get; set; }
        public string OrderFromName { get; set; }
        public OrderState OrderState { get; set; }
        public virtual ICollection<SaleDetailViewModel> SaleDetails { get; set; }
        public string Date { get; set; }
        public string EmployeeInfoId { get; set; }
        [IsViewable] public string EmployeeInfoName { get; set; }
        public virtual Employee Employee { get; set; }

        public string WarehouseId { get; set; }
    }
}