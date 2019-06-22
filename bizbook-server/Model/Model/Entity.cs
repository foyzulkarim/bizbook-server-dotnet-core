using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Shops;

namespace Model.Model
{
    [Serializable]
    public abstract class Entity
    {
        [Key]
        [Column(TypeName = "varchar(128)")]
        public string Id { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string CreatedBy { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string CreatedFrom { get; set; }
        
        [Required]
        public DateTime Modified { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public string ModifiedBy { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }

    public abstract class ShopChild : Entity
    {
        [Required]
        [Column(TypeName = "varchar(128)")]
        public string ShopId { get; set; }

        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
    }
}