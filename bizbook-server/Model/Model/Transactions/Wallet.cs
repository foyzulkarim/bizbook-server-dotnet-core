using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Model.Model.Transactions
{
    public class Wallet : ShopChild
    {

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string AccountNumber { get; set; }

        [MaxLength(50)]
        public string BankName { get; set; }

        [MaxLength(20)]
        public string CardNumber { get; set; }

        [MaxLength(20)]
        public string MobileNumber { get; set; }

        public double Balance { get; set; }

        public double StartingBalance { get; set; }

        [Required]
        public WalletType WalletType { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WalletType
    {
        Cash = 1,
        Bank,
        Mobile,
        Goods,
        Online,
        Other
    }
}