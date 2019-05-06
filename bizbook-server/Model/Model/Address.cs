using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class Address: ShopChild
    {
        [Column(TypeName = "nvarchar(64)")]
        public string AddressName { get; set; }

        public bool IsDefault { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string ContactName { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string ContactPhone { get; set; }

        [Column(TypeName = "nvarchar(700)")]
        public string StreetAddress { get; set; }

        [Column(TypeName = "nvarchar(172)")]
        public string Area { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string Thana { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string PostCode { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string District { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string SpecialNote { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string CustomerId { get; set; }    
        
        public Customer Customer { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}
