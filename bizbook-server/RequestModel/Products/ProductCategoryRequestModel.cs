using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using ViewModel;


namespace RequestModel.Products
{
    public class ProductCategoryRequestModel : RequestModel<ProductCategory>
    {
        public string ProductGroupId { get; set; }

        public ProductCategoryRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") :
            base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<ProductCategory, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword);
            }

            if (ProductGroupId.IdIsOk())
            {
                ExpressionObj = ExpressionObj.And(x => x.ProductGroupId == ProductGroupId);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override IQueryable<ProductCategory> IncludeParents(IQueryable<ProductCategory> queryable)
        {
            return queryable.Include(x => x.ProductGroup);
        }

        public override Expression<Func<ProductCategory, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.Name};
        }
    }
}