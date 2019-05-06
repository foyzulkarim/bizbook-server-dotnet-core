using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using ViewModel;

namespace RequestModel.Purchases
{
    public enum OrderType
    {
        All,
        SalesOrder,
        PurchaseOrder
    }

    public class PurchaseRequestModel : RequestModel<Purchase>
    {
        public PurchaseRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") : base(
            keyword, orderBy, isAscending)
        {
        }

        public string SupplierId { get; set; }

        protected override Expression<Func<Purchase, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x =>
                    x.OrderNumber.ToLower().Contains(Keyword) || x.ShipmentTrackingNo.ToLower().Contains(Keyword);
            }

            if (ParentId.IdIsOk())
            {
                ExpressionObj = ExpressionObj.And(x => x.SupplierId == ParentId);
            }

            if (SupplierId.IdIsOk())
            {
                ExpressionObj = ExpressionObj.And(x => x.SupplierId == SupplierId);
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

        public override IQueryable<Purchase> IncludeParents(IQueryable<Purchase> queryable)
        {
            return queryable.Include(x => x.Supplier).Include(x => x.PurchaseDetails);
        }

        public override Expression<Func<Purchase, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() {Id = x.Id, Text = x.OrderNumber};
        }
    }
}