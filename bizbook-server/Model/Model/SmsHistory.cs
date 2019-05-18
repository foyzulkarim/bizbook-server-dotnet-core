using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class SmsHistory : ShopChild
    {
        public double Amount { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SmsId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string Text { get; set; }
    }
}
