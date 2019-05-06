using Model.Model;

namespace ViewModel.Warehouses
{
    public class StockTransferDetailViewModel : BaseViewModel<StockTransferDetail>
    {
        public StockTransferDetailViewModel(StockTransferDetail x) : base(x)
        {
            ShopId = x.ShopId;
            Quantity = x.Quantity;
            SalePricePerUnit = x.SalePricePerUnit;
            StockTransferId = x.StockTransferId;
            ProductDetailId = x.ProductDetailId;
            SourceWarehouseId = x.SourceWarehouseId;
            DestinationWarehouseId = x.DestinationWarehouseId;
            Remarks = x.Remarks;
            PriceTotal = x.PriceTotal;

            if (x.ProductDetail != null)
            {
                ProductDetailName = x.ProductDetail.Name;
                ProductCategoryId = x.ProductDetail.ProductCategoryId;
            }

            if (x.StockTransfer != null)
            {
                StockTransferOrderNumber = x.StockTransfer.OrderNumber;
            }
        }

        public string ShopId { get; set; }
        public double Quantity { get; set; }
        public double SalePricePerUnit { get; set; }
        public string StockTransferId { get; set; }
        public string ProductDetailId { get; set; }
        public string SourceWarehouseId { get; set; }
        public string DestinationWarehouseId { get; set; }
        public string Remarks { get; set; }
        public double PriceTotal { get; set; }
        public string ProductDetailName { get; set; }
        public string ProductCategoryId { get; set; }
        public string StockTransferOrderNumber { get; set; }
    }
}