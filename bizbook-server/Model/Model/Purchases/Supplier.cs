using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Purchases
{
    public class Supplier : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string StreetAddress { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Area { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Thana { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string PostCode { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string District { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ContactPersonName { get; set; }

        public bool IsVerified { get; set; }

        public int OrdersCount { get; set; }

        public double ProductAmount { get; set; }

        public double OtherAmount { get; set; }

        public double TotalDiscount { get; set; }

        public double TotalAmount { get; set; }

        public double TotalPaid { get; set; }

        public double TotalDue { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
