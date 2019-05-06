using System;
using System.Linq.Expressions;
using Model.Model;
using ViewModel;

namespace RequestModel.Message
{
    public class SmsHookRequestModel : RequestModel<SmsHook>
    {
        public SmsHookRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") : base(
            keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<SmsHook, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<SmsHook, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.Name};
        }
    }
}