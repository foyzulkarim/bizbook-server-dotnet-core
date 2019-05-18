using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Model.Sales;

namespace Model.Model.Customers
{
    public class Customer : ShopChild
    {
        [Required]
        [Column(TypeName = "varchar(36)")]
        public string MembershipCardNo { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Occupation { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string University { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Company { get; set; }

        public int Point { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        public int OrdersCount { get; set; }

        public double ProductAmount { get; set; }

        public double OtherAmount { get; set; }

        public double TotalDiscount { get; set; }

        public double TotalAmount { get; set; }

        public double TotalPaid { get; set; }

        public double TotalDue { get; set; }

        public int WcId { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string NationalId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
