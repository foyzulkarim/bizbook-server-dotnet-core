using Model.Constants;
using Model.Model;
using Model.Model.Transactions;

namespace ViewModel.Transactions
{
    using System;

    public class TransactionViewModel : BaseViewModel<Transaction>
    {
        public TransactionViewModel(Transaction x) : base(x)
        {
            TransactionFor = x.TransactionFor;
            TransactionType = x.TransactionFlowType;
            TransactionFlowType = x.TransactionFlowType.ToString();
            TransactionWith = x.TransactionWith;
            TransactionMedium = x.TransactionMedium;

            ParentId = x.ParentId;
            OrderNumber = x.OrderNumber;
            Amount = x.Amount;
            TransactionNumber = x.TransactionNumber;
            Remarks = x.Remarks;
            ContactPersonName = x.ContactPersonName;

            if (x.TransactionDate != null)
            {
                this.TransactionDate = x.TransactionDate.Value;
            }

            ContactPersonPhone = x.ContactPersonPhone;

            AccountHeadId = x.AccountHeadId;
            ShopId = x.ShopId;
            OrderId = x.OrderId;

            PaymentGatewayServiceName = PaymentGatewayService;
            WalletId = x.WalletId;
            if (x.WalletId != null)
            {
                AccountInfoTitle = x.Wallet.Title;
            }
        }

        public string TransactionFlowType { get; set; }

        public string PaymentGatewayServiceName { get; set; }

        public string PaymentGatewayService { get; set; }

        public string OrderId { get; set; }

        public string ShopId { get; set; }

        public TransactionFor TransactionFor { get; set; }

        public TransactionWith TransactionWith { get; set; }

        public TransactionMedium TransactionMedium { get; set; }

        public string ParentId { get; set; }

        public string OrderNumber { get; set; }

        public double Amount { get; set; }

        public string TransactionMediumName { get; set; }

        public string TransactionNumber { get; set; }

        public string Remarks { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonPhone { get; set; }

        public DateTime TransactionDate { get; set; }

        public string AccountHeadName { get; set; }

        public TransactionFlowType TransactionType { get; set; }

        public string AccountHeadId { get; set; }

        public string WalletId { get; set; }

        public string AccountInfoTitle { get; set; }
    }
}