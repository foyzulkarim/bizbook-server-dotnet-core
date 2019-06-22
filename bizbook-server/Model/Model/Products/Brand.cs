using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Products
{
    public class Brand : ShopChild
    {
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(36)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string ContactPersonName { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string MadeInCountry { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string BrandCode { get; set; }
    }
}
