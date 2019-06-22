using Model.Model;
using Model.Model.Transactions;
using ViewModel;

namespace RequestModel.Transactions
{
    using System;
    using System.Linq.Expressions;

    public class TransactionRequestModel : RequestModel<Transaction>
    {
        public string AccountHeadId { get; set; }

        public string WalletId { get; set; }

        public TransactionRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy,
            isAscending)
        {
        }

        protected override Expression<Func<Transaction, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj =
                    x =>
                        x.OrderNumber.ToLower().Contains(Keyword) || x.TransactionNumber.ToLower().Contains(Keyword);
            }

            if (!string.IsNullOrWhiteSpace(AccountHeadId))
            {
                ExpressionObj = ExpressionObj.And(x => x.AccountHeadId == AccountHeadId);
            }

            if (!string.IsNullOrWhiteSpace(WalletId))
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.WalletId == WalletId);
            }

            if (!string.IsNullOrWhiteSpace(ParentId))
            {
                ExpressionObj = ExpressionObj.And(x => x.ParentId == ParentId);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<Transaction, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() { Id = x.Id, Text = x.OrderNumber };
        }
    }
}