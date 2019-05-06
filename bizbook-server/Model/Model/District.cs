using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class District : Entity
    {
        public District()
        {
            Zones = new HashSet<Zone>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]

        public string NameBn { get; set; }

        public ICollection<Zone> Zones { get; set; }
    }
}
