using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using ViewModel;

namespace RequestModel.Products
{
    public class DealerProductRequestModel : RequestModel<DealerProduct>
    {
        public DealerProductRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") :
            base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<DealerProduct, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x =>
                    x.ProductDetailId.Contains(Keyword) ||
                    x.DealerId.Contains(Keyword);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<DealerProduct, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel()
            {
                Id = x.Id,
                Text = x.ProductDetail.Name
            };
        }

        //include parent
        public override IQueryable<DealerProduct> IncludeParents(IQueryable<DealerProduct> queryable)
        {
            return queryable.Include(x => x.ProductDetail);
        }
    }
}