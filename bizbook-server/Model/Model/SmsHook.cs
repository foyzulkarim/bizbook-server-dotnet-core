using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class SmsHook : ShopChild
    {
        public SmsHook()
        {
            HookDetails = new HashSet<HookDetail>();
        }

        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }

        public bool IsEnabled { get; set; }
        public BizSmsHook BizSmsHook { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string Description { get; set; }

        public ICollection<HookDetail> HookDetails { get; set; }

    }
}
