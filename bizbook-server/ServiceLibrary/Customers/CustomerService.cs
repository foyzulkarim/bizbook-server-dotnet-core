using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Constants;
using Model.Model;
using Vm = ViewModel.Customers.CustomerViewModel;
using Rm = RequestModel.Customers.CustomerRequestModel;
using M = Model.Model.Customer;
using Repo = Model.BaseRepository<Model.Model.Customer>;
using ServiceLibrary.Products;

namespace ServiceLibrary.Customers
{
    public class CustomerService : BaseService<M, Rm, Vm>, IWooCommerceService
    {
        public CustomerService(Repo repository) : base(repository)
        {
        }

        public bool UpdatePoint(string customerId)
        {
            M customer = Db.Customers.Include(x => x.Sales).FirstOrDefault(x => x.Id == customerId);

            bool updatePoint = false;
            if (customer?.Sales != null)
            {
                var sales = customer.Sales;
                double productAmount = sales.Sum(x => x.ProductAmount);
                double discount = sales.Sum(x => x.DiscountAmount);
                double orderAmount = sales.Sum(x => x.PayableTotalAmount);

                var transactions = this.Db.Transactions.Where(x => x.ParentId == customerId);
                var paids = transactions.Where(x => x.TransactionFlowType == TransactionFlowType.Income);

                double customerPaidTotal = 0;
                if (paids.Any())
                {
                    customerPaidTotal = paids.Sum(x => x.Amount);
                }

                var returneds = transactions.Where(x => x.TransactionFlowType == TransactionFlowType.Expense);
                double customerReturnedTotal = 0;
                if (returneds.Any())
                {
                    customerReturnedTotal = returneds.Sum(x => x.Amount);
                }

                double actualPaid = customerPaidTotal - customerReturnedTotal;

                customer.Point = (int)(actualPaid / 100);
                customer.OrdersCount = sales.Count();

                customer.ProductAmount = productAmount;
                customer.TotalDiscount = discount;
                customer.TotalAmount = orderAmount;
                customer.TotalPaid = actualPaid;
                customer.TotalDue = orderAmount - actualPaid;

                updatePoint = this.Edit(customer);
            }

            return updatePoint;
        }

        public string GetBarcode(string shopId)
        {
            int count = Repository.Get().Count(x => x.ShopId == shopId) + 1;
            String s = DateTime.Now.Year + string.Empty + DateTime.Now.Month.ToString().PadLeft(2, '0') + string.Empty +
                   DateTime.Now.Day.ToString().PadLeft(2, '0');
            var queryable = Repository.Get();
            do
            {
                var barcode = s + count.ToString().PadLeft(10, '0');
                var prod = queryable.FirstOrDefault(x => x.MembershipCardNo == barcode) == null;
                if (prod)
                {
                    return barcode;
                }
                count = count + 1;
            } while (true);
        }
    }
}