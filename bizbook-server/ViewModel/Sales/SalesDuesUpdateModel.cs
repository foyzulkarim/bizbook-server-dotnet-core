using Model.Model;

namespace ViewModel.Sales
{
    using System.Collections.Generic;

    public class SalesDuesUpdateModel
    {
        public string ShopId { get; set; }

        public Transaction Transaction { get; set; }

        public List<SaleDue> Sales { get; set; }
    }

    public class SaleDue
    {
        public string Id { get; set; }

        public double NewlyPaid { get; set; }
    }
}