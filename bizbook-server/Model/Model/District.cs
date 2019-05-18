using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class District : Entity
    {
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(128)")]

        public string NameBn { get; set; }

    }
}
