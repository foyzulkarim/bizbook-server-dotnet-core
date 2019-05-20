using System;
using System.Linq;
using System.Text;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Shops;

namespace DataSeedConsoleApp
{
    class Program
    {
        private const string SystemShopId = "00000000-0000-0000-0000-000000000000";
        private const string DemoShopId = "00000000-0000-0000-0000-000000000001";
        private const string SuperAdminRoleName = "SuperAdmin";
        private const string ShopAdmin = "ShopAdmin";

        private static IServiceProvider _serviceProvider;

        private const string SecretKey = "tsKTyBHgEMjBKPcjuYhWWzQdRt1XND0q"; // todo: get this from somewhere secure
        private static readonly SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        static void Main(string[] args)
        {
            InsertShops();
            InsertRoles();
            RegisterServices();
            var aspNetUserManager = _serviceProvider.GetService<AspNetUserManager<ApplicationUser>>();
            Console.WriteLine($"{DateTime.Now} : Inserting SuperAdmin user");
            var superAdmin = new ApplicationUser
            {
                UserName = "foyzulkarim@gmail.com",
                Email = "foyzulkarim@gmail.com",
                FirstName = "Foyzul",
                LastName = "Karim",
                PhoneNumber = "foyzul123",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                RoleId = SystemShopId,
                ShopId = SystemShopId,
                ConcurrencyStamp = DateTime.Now.Ticks.ToString(),
                Id = SystemShopId,
                IsActive = true,
            };

            var result = aspNetUserManager.CreateAsync(superAdmin, "Pass@123").GetAwaiter().GetResult();


            Console.WriteLine($"{DateTime.Now} : Inserting Demo1 user");
            var demo1Admin = new ApplicationUser
            {
                UserName = "admin@demo1.com",
                Email = "admin@demo1.com",
                FirstName = "Admin",
                LastName = "Demo1",
                PhoneNumber = "demo123",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                RoleId = DemoShopId,
                ShopId = DemoShopId,
                ConcurrencyStamp = DateTime.Now.Ticks.ToString(),
                Id = DemoShopId,
                IsActive = true,
            };

            var result1 = aspNetUserManager.CreateAsync(demo1Admin, "Pass@123").GetAwaiter().GetResult();

            Console.WriteLine($"{DateTime.Now} : DONE");
            Console.WriteLine(result.Succeeded && result1.Succeeded);
        }

        private static void RegisterServices()
        {
            var serviceCollection = new ServiceCollection();
            const string bizbook365Com = "bizbook365.com";
            serviceCollection.AddDbContext<SecurityDbContext>(options =>
                options.UseSqlServer(@"Server=.;Database=BizBookCoreDb;Trusted_Connection=True;"));
            serviceCollection.AddDbContext<BizBookInventoryContext>(options => options.UseSqlServer(@"Server=.;Database=BizBookCoreDb;Trusted_Connection=True;"));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = bizbook365Com,

                ValidateAudience = true,
                ValidAudience = bizbook365Com,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SigningKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            serviceCollection.AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(
                    options =>
                    {
                        options.ClaimsIssuer = bizbook365Com;
                        options.TokenValidationParameters = tokenValidationParameters;
                        options.SaveToken = true;
                    });

            IdentityBuilder builder = serviceCollection.AddIdentityCore<ApplicationUser>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<SecurityDbContext>().AddDefaultTokenProviders();


            serviceCollection.AddScoped<AspNetUserManager<ApplicationUser>, AspNetUserManager<ApplicationUser>>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }


        private static void InsertRoles()
        {

            using (var db = new SecurityDbContext())
            {
                var superAdmin = db.ApplicationRoles.FirstOrDefault(x => x.ShopId == SystemShopId && x.Name == SuperAdminRoleName);
                if (superAdmin == null)
                {
                    Console.WriteLine($"{DateTime.Now} : Inserting SuperAdmin role ");
                    superAdmin = new ApplicationRole(SuperAdminRoleName)
                    {
                        ConcurrencyStamp = DateTime.Now.Ticks.ToString(),
                        Id = SystemShopId,
                        ShopId = SystemShopId
                    };

                    db.ApplicationRoles.Add(superAdmin);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now} : SuperAdmin role exists");
                }



                var shopAdmin = db.ApplicationRoles.FirstOrDefault(x => x.ShopId == DemoShopId && x.Name == ShopAdmin);
                if (shopAdmin == null)
                {
                    Console.WriteLine($"{DateTime.Now} : Inserting ShopAdmin role ");
                    shopAdmin = new ApplicationRole(ShopAdmin)
                    {
                        ConcurrencyStamp = DateTime.Now.Ticks.ToString(),
                        Id = DemoShopId,
                        ShopId = DemoShopId
                    };

                    db.ApplicationRoles.Add(shopAdmin);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now} : ShopAdmin role exists");
                }
            }
        }

        private static void InsertShops()
        {
            using (var db = new BizBookInventoryContext())
            {
                Console.WriteLine($"{DateTime.Now} : Inserting System shop");

                var shop = db.Shops.FirstOrDefault(x => x.Id == SystemShopId);
                if (shop == null)
                {
                    shop = GetSysShop();
                    db.Shops.Add(shop);
                    db.SaveChanges();
                    Console.WriteLine($"Saved Shop id {SystemShopId}");
                }
                else
                {
                    Console.WriteLine($"System Shop exists id {SystemShopId}. created on {shop.Created}");
                }

                Console.WriteLine($"{DateTime.Now} : Inserting Demo1 shop");

                var demoShop = db.Shops.FirstOrDefault(x => x.Id == DemoShopId);

                if (demoShop == null)
                {
                    demoShop = GetDemo1Shop();
                    db.Shops.Add(demoShop);
                    db.SaveChanges();
                    Console.WriteLine($"Saved Shop id {DemoShopId}");
                }
                else
                {
                    Console.WriteLine($"Demo Shop exists id {DemoShopId}. created on {demoShop.Created}");
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
