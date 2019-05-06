namespace ViewModel.Reports
{
    using System;

    public class BaseReportViewModel<T> : BaseViewModel<T> where T : BaseReport
    {
        public BaseReportViewModel(BaseReport x) : base(x)
        {
            this.Value = x.Value;
            this.Date = x.Date;
            this.RowsCount = x.RowsCount;
            this.ShopId = x.ShopId;
        }

        public string Value { get; set; }
        public DateTime Date { get; set; }
        public int RowsCount { get; set; }
        public string ShopId { get; set; }
    }
}