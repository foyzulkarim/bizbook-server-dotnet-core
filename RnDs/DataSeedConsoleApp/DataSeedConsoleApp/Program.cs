using System;
using System.Linq;
using B2BCoreApi.Models;
using Model;
using Model.Shops;

namespace DataSeedConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertShops();
            InsertRoles();
        }



        private static void InsertRoles()
        {
            using (var db = new SecurityDbContext())
            {
                var roles = db.ApplicationRoles.Where(x => x.ShopId == new Guid().ToString()).ToList();


            }
        }

        private static void InsertShops()
        {
            using (var db = new BizBookInventoryContext())
            {
                var systemShopId = new Guid().ToString();
                var shop = db.Shops.FirstOrDefault(x => x.Id == systemShopId);
                if (shop == null)
                {
                    shop = GetSysShop();
                    db.Shops.Add(shop);
                    db.SaveChanges();
                    Console.WriteLine($"Saved Shop id {systemShopId}");
                }
                else
                {
                    Console.WriteLine($"Shop exists id {systemShopId}. created on {shop.Created}");
                }

                var demoShopId = "00000000-0000-0000-0000-000000000001";
                var demoShop = db.Shops.FirstOrDefault(x => x.Id == demoShopId);

                if (demoShop == null)
                {
                    demoShop = GetDemo1Shop();
                    db.Shops.Add(demoShop);
                    db.SaveChanges();
                    Console.WriteLine($"Saved Shop id {demoShopId}");
                }
                else
                {
                    Console.WriteLine($"Shop exists id {demoShopId}. created on {demoShop.Created}");
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
                CreatedFrom = "System",
                RegistrationDate = DateTime.UtcNow,
                ExpiryDate = new DateTime(2025, 1, 1),
                IsVerified = true,
                TotalUsers = 1,
                District = "Dhaka",
                Website = "http://www.bizbook365.com"
            };

            return sysShop;
        }

        private static Shop GetDemo1Shop()
        {
            Shop sysShop = new Shop()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Name = "Demo1",
                Phone = "demo123",
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                CreatedBy = "foyzulkarim@gmail.com",
                ModifiedBy = "foyzulkarim@gmail.com",
                CreatedFrom = "System",
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
