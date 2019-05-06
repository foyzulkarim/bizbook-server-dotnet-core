using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Zone : ShopChild
    {
        public Zone()
        {
            WarehouseZones = new HashSet<WarehouseZone>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DistrictId { get; set; }

        public District District { get; set; }

        public ICollection<WarehouseZone> WarehouseZones { get; set; }

    }
}
