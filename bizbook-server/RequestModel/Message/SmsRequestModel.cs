using System;
using System.Linq.Expressions;
using Model.Model;
using ViewModel;

namespace RequestModel.Message
{
    public class SmsRequestModel : RequestModel<Sms>
    {
        public SmsRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") : base(
            keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Sms, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x =>
                    x.ReceiverNumber.ToLower().Contains(Keyword) || x.ReceiverId.ToLower().Contains(Keyword) ||
                    x.ReasonType.Equals(Keyword) || x.ReasonId.ToLower().Contains(Keyword);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<Sms, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.Text};
        }
    }
}