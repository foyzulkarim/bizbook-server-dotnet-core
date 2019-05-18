using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Sales
{
    public class SaleState : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string State { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Remarks { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SaleId { get; set; }

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }
    }
}
