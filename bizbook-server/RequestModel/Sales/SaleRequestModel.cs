using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Constants;
using Model.Model;
using Model.Model.Sales;
using ViewModel;

namespace RequestModel.Sales
{
    public class SaleRequestModel : RequestModel<Sale>
    {
        public ReportTimeType TimeType { get; set; }

        public SaleRequestModel(string keyword, string orderBy = "Modified", string isAscending = "False") : base(
            keyword, orderBy, isAscending)
        {
        }

        public bool OnlyDues { get; set; }

        public string CustomerId { get; set; }
        public SaleChannel SaleChannel { get; set; } = SaleChannel.All;
        public SaleFrom SaleFrom { get; set; } = SaleFrom.All;

        public string OrderState { get; set; } = All;

        public string DeliverymanId { get; set; }

        public string Thana { get; set; }

        public bool IsDealerSale { get; set; }

        public string SalesmanId { get; set; }


        public bool IsTaggedSale { get; set; }

        public string SaleTag { get; set; }

        protected override Expression<Func<Sale, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x =>
                    x.OrderNumber.ToLower().Contains(Keyword) || x.OrderReferenceNumber.ToLower().Contains(Keyword) ||
                    x.CustomerPhone.ToLower().Contains(Keyword) || x.CustomerName.ToLower().Contains(Keyword);
            }

            if (this.SaleChannel != SaleChannel.All)
            {
                ExpressionObj = ExpressionObj.And(x => x.SaleChannel == this.SaleChannel);
            }

            if (this.SaleFrom != SaleFrom.All)
            {
                ExpressionObj = ExpressionObj.And(x => x.SaleFrom == this.SaleFrom);
            }

            if (this.OrderState != All)
            {
                OrderState state = (OrderState)Enum.Parse(typeof(OrderState), this.OrderState);
                ExpressionObj = ExpressionObj.And(x => x.OrderState == state);
            }

            if (!string.IsNullOrWhiteSpace(DeliverymanId))
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.DeliverymanId == DeliverymanId);
            }

            if (!string.IsNullOrWhiteSpace(Thana) && Thana != All)
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.Address.Thana == Thana);
            }

            this.ExpressionObj = this.ExpressionObj.And(x => x.IsDealerSale == this.IsDealerSale);

            if (OnlyDues)
            {
                this.ExpressionObj =
                    this.ExpressionObj.And(x => x.DueAmount >= 1 && x.OrderState != Model.Constants.OrderState.Cancel);
            }

            if (IsDealerSale)
            {
                if (ParentId.IdIsOk())
                {
                    this.ExpressionObj = this.ExpressionObj.And(x => x.DealerId == ParentId);
                }
            }
            else
            {
                if (ParentId.IdIsOk())
                {
                    this.ExpressionObj = this.ExpressionObj.And(x => x.CustomerId == ParentId);
                }
            }

            if (SalesmanId.IdIsOk())
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.EmployeeId == SalesmanId);
            }



            this.ExpressionObj = this.ExpressionObj.And(x => x.IsTaggedSale == IsTaggedSale);
            if (IsTaggedSale)
            {
                this.ExpressionObj = this.ExpressionObj.And(x => x.SaleTag == SaleTag);
            }


            ExpressionObj = ExpressionObj.And(x => x.ShopId == ShopId);
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override IQueryable<Sale> IncludeParents(IQueryable<Sale> queryable)
        {
            return queryable.Include(x => x.Address).Include(x => x.Customer).Include(x => x.Dealer)
                .Include(x => x.Employee).Include(x => x.SaleDetails);
        }

        public override Expression<Func<Sale, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel()
            {
                Id = x.Id,
                Text = x.OrderNumber + " (Due: " + x.DueAmount + ")",
                Data = new
                {
                    x.TotalAmount,
                    x.PaidAmount,
                    x.DueAmount,
                    x.ProductAmount,
                    x.OrderNumber
                }
            };
        }
    }
}