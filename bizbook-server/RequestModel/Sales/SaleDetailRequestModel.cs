using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using ViewModel;

namespace RequestModel.Sales
{
    public class SaleDetailRequestModel : RequestModel<SaleDetail>
    {
        public SaleDetailRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") : base(
            keyword, orderBy, isAscending)
        {
        }

        public string ProductDetailId { get; set; }

        protected override Expression<Func<SaleDetail, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(ParentId))
            {
                ExpressionObj = ExpressionObj.And(x => x.SaleId == ParentId);
            }

            if (!string.IsNullOrWhiteSpace(ProductDetailId))
            {
                ExpressionObj = ExpressionObj.And(x => x.ProductDetailId == ProductDetailId);
            }

            if (WarehouseId.IdIsOk())
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.WarehouseId == WarehouseId);
            }

            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public string WarehouseId { get; set; }

        public override IQueryable<SaleDetail> IncludeParents(IQueryable<SaleDetail> queryable)
        {
            return queryable.Include(x => x.Sale).Include(x => x.ProductDetail);
        }

        public override Expression<Func<SaleDetail, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.ProductDetail.Name};
        }
    }
}