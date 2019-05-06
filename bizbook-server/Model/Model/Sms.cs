using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Constants;

namespace Model.Model
{
    public partial class Sms : ShopChild
    {
        [Column(TypeName = "varchar(128)")]
        public string Text { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ReceiverNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ReceiverId { get; set; }
        public SmsReasonType ReasonType { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string ReasonId { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string DeliveryStatus { get; set; }

        public bool Ismasked { get; set; }
        public SmsReceiverType SmsReceiverType { get; set; }

    }
}
