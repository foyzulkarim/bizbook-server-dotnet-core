using System;
using System.Linq.Expressions;
using Model.Model;
using ViewModel;

namespace RequestModel.Message
{
    public class HookDetailRequestModel : RequestModel<HookDetail>
    {
        public string HookId { get; set; }

        public HookDetailRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") : base(
            keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<HookDetail, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.HookName.ToLower().Contains(Keyword);
            }

            if (HookId.IdIsOk())
            {
                ExpressionObj = ExpressionObj.And(x => x.SmsHookId == HookId);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<HookDetail, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.HookName};
        }
    }
}