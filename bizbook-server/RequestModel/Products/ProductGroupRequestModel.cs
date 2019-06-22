using System;
using System.Linq.Expressions;
using Model.Model;
using Model.Model.Products;
using ViewModel;

namespace RequestModel.Products
{
    public class ProductGroupRequestModel : RequestModel<ProductGroup>
    {
        public ProductGroupRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") :
            base(keyword, orderBy, isAscending)
        {
        }


        protected override Expression<Func<ProductGroup, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<ProductGroup, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.Name};
        }
    }
}