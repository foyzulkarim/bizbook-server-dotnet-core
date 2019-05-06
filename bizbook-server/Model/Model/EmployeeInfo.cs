using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class EmployeeInfo : ShopChild
    {
        public EmployeeInfo()
        {
            Sales = new HashSet<Sale>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string RoleId { get; set; }

        public double Salary { get; set; }

        public double SaleTargetAmount { get; set; }

        public double SaleAchivedAmount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}
