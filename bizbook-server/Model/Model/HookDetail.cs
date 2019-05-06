using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public partial class HookDetail : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string HookName { get; set; }

        public bool IsEnabled { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string SmsHookId { get; set; }

        public SmsHook SmsHook { get; set; }
    }
}
