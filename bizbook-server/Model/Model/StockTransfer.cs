using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class StockTransfer : ShopChild
    {
        public StockTransfer()
        {
            StockTransferDetails = new HashSet<StockTransferDetail>();
        }

        [Column(TypeName = "varchar(128)")]
        public string OrderNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string OrderReferenceNumber { get; set; }

        public double ProductAmount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DeliveryTrackingNo { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DeliverymanId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DeliverymanName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DeliverymanPhone { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SourceWarehouseId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DestinationWarehouseId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Remarks { get; set; }

        public Warehouse DestinationWarehouse { get; set; }

        public Warehouse SourceWarehouse { get; set; }

        public StockTransferState TransferState { get; set; }

        public ICollection<StockTransferDetail> StockTransferDetails { get; set; }
    }
}
