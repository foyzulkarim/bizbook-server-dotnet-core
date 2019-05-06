using System;
using Model.Model;
using ViewModel;

namespace RequestModel.Warehouses
{
    using System.Linq.Expressions;

    public class WarehouseHistoryRequestModel : RequestModel<Warehouse>
    {
        public WarehouseHistoryRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False")
            : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Warehouse, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x =>
                    x.Name.ToLower().Contains(Keyword) || x.Area.ToString().ToLower().Contains(Keyword);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<Warehouse, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.Name};
        }
    }
}