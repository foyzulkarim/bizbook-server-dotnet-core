using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Warehouse : ShopChild
    {
        public Warehouse()
        {
            Damages = new HashSet<Damage>();
            EmployeeInfoes = new HashSet<EmployeeInfo>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            Purchases = new HashSet<Purchase>();
            SaleDetails = new HashSet<SaleDetail>();
            Sales = new HashSet<Sale>();
            StockTransferDetailsDestinationWarehouse = new HashSet<StockTransferDetail>();
            StockTransferDetailsSourceWarehouse = new HashSet<StockTransferDetail>();
            StockTransfersDestinationWarehouse = new HashSet<StockTransfer>();
            StockTransfersSourceWarehouse = new HashSet<StockTransfer>();
            WarehouseProducts = new HashSet<WarehouseProduct>();
            WarehouseZones = new HashSet<WarehouseZone>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string StreetAddress { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Area { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string District { get; set; }

        public bool IsMain { get; set; }

        public ICollection<Damage> Damages { get; set; }
        public ICollection<EmployeeInfo> EmployeeInfoes { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<StockTransferDetail> StockTransferDetailsDestinationWarehouse { get; set; }

        public ICollection<StockTransferDetail> StockTransferDetailsSourceWarehouse { get; set; }

        public ICollection<StockTransfer> StockTransfersDestinationWarehouse { get; set; }

        public ICollection<StockTransfer> StockTransfersSourceWarehouse { get; set; }

        public ICollection<WarehouseProduct> WarehouseProducts { get; set; }

        public ICollection<WarehouseZone> WarehouseZones { get; set; }

    }
}
