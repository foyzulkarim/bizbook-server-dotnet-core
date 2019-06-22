using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Model.Sales;

namespace Model.Model
{
    public class Employee : ShopChild
    {

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string RoleId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string UserId { get; set; }

        public double Salary { get; set; }

        public double SaleTargetAmount { get; set; }

        public double SaleAchivedAmount { get; set; }
    }
}
