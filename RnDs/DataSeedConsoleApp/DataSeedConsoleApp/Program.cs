using System;
using System.Linq;
using Model;
using Model.Shops;

namespace DataSeedConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertSystemShop();

        }

        private static void InsertSystemShop()
        {
            using (var db = new BizBookInventoryContext())
            {
                var shopId = new Guid().ToString();
                var shop = db.Shops.FirstOrDefault(x => x.Id == shopId);
                if (shop == null)
                {
                    shop = GetSysShop();
                    db.Shops.Add(shop);
                    db.SaveChanges();
                    Console.WriteLine("Saved Shop");
                }
                else
                {
                    Console.WriteLine($"Shop exists. created on {shop.Created}");
                }
            }
        }

        private static Shop GetSysShop()
        {
            Shop sysShop = new Shop()
            {
                Id = new Guid().ToString(),
                Name = "System",
                Phone = "system",
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                CreatedBy = "foyzulkarim@gmail.com",
                ModifiedBy = "foyzulkarim@gmail.com",
                CreatedFrom = "Browser",
                RegistrationDate = DateTime.UtcNow,
                ExpiryDate = new DateTime(2025, 1, 1),
                IsVerified = true,
                TotalUsers = 1,
                District = "Dhaka",
                Website = "http://www.bizbook365.com"
            };

            return sysShop;
        }
    }
}
