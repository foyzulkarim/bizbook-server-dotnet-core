using System;
using System.Text;
using B2BCoreApi.Attributes;
using B2BCoreApi.Auth;
using B2BCoreApi.Helpers;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Model;
using RequestModel;
using RequestModel.Customers;
using RequestModel.Employees;
using RequestModel.Message;
using RequestModel.Products;
using RequestModel.Purchases;
using RequestModel.Reports;
using RequestModel.Sales;
using RequestModel.Shops;
using RequestModel.Transactions;
using RequestModel.Warehouses;
using Serilog;
using Serilog.Core;

namespace B2BCoreApi
{
    public class Startup
    {
        private const string SecretKey = "tsKTyBHgEMjBKPcjuYhWWzQdRt1XND0q"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SecurityDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDbContext<BizBookInventoryContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton<IJwtFactory, JwtFactory>();

            const string bizbook365Com = "bizbook365.com";

            services.AddCors();

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = bizbook365Com;
                options.Audience = bizbook365Com;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = bizbook365Com,

                ValidateAudience = true,
                ValidAudience = bizbook365Com,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(
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

            IdentityBuilder builder = services.AddIdentityCore<ApplicationUser>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<SecurityDbContext>().AddDefaultTokenProviders();

            var saleBinder = new AbstractModelBinderProvider<SaleRequestModel>();
            var addressBinder = new AbstractModelBinderProvider<AddressRequestModel>();
            var customersBinder = new AbstractModelBinderProvider<CustomerRequestModel>();
            var employeeInfoBinder = new AbstractModelBinderProvider<EmployeeInfoRequestModel>();
            var brandBinder = new AbstractModelBinderProvider<BrandRequestModel>();
            var courierBinder = new AbstractModelBinderProvider<CourierRequestModel>();
            var dealerBinder = new AbstractModelBinderProvider<DealerRequestModel>();
            var shopBinder = new AbstractModelBinderProvider<ShopRequestModel>();
            var supplierBinder = new AbstractModelBinderProvider<SupplierRequestModel>();
            var dealerProductBinder = new AbstractModelBinderProvider<DealerProductRequestModel>();
            var productCategoryBinder = new AbstractModelBinderProvider<ProductCategoryRequestModel>();
            var productDetailBinder = new AbstractModelBinderProvider<ProductDetailRequestModel>();
            var productGroupBinder = new AbstractModelBinderProvider<ProductGroupRequestModel>();
            var productSerialBinder = new AbstractModelBinderProvider<ProductSerialRequestModel>();
            var supplierProductBinder = new AbstractModelBinderProvider<SupplierProductRequestModel>();
            var purchaseDetailBinder = new AbstractModelBinderProvider<PurchaseDetailRequestModel>();
            var purchaseBinder = new AbstractModelBinderProvider<PurchaseRequestModel>();
            var customerBySaleBinder = new AbstractModelBinderProvider<CustomerBySaleRequestModel>();
            var dailySalesOverviewBinder = new AbstractModelBinderProvider<DailySalesOverviewRequestModel>();
            var salesByProductBinder = new AbstractModelBinderProvider<SalesByProductRequestModel>();
            var courierOrderBinder = new AbstractModelBinderProvider<CourierOrderRequestModel>();
            var installmentDetailtBinder = new AbstractModelBinderProvider<InstallmentDetailRequestModel>();
            var installmentBinder = new AbstractModelBinderProvider<InstallmentRequestModel>();
            var saleDetailBinder = new AbstractModelBinderProvider<SaleDetailRequestModel>();
            var accountHeadBinder = new AbstractModelBinderProvider<AccountHeadRequestModel>();
            var accountInfoBinder = new AbstractModelBinderProvider<AccountInfoRequestModel>();
            var transactionBinder = new AbstractModelBinderProvider<TransactionRequestModel>();
            var damageBinder = new AbstractModelBinderProvider<DamageRequestModel>();
            var stockTransferDetailBinder = new AbstractModelBinderProvider<StockTransferDetailRequestModel>();
            var stockTransferBinder = new AbstractModelBinderProvider<StockTransferRequestModel>();
            var warehouseHistoryBinder = new AbstractModelBinderProvider<WarehouseHistoryRequestModel>();
            var warehouseBinder = new AbstractModelBinderProvider<WarehouseRequestModel>();
            var hookDetailBinder = new AbstractModelBinderProvider<HookDetailRequestModel>();
            var messageBinder = new AbstractModelBinderProvider<MessageRequestModel>();
            var smsHistoryBinder = new AbstractModelBinderProvider<SmsHistoryRequestModel>();
            var smsHookBinder = new AbstractModelBinderProvider<SmsHookRequestModel>();
            var smsBinder = new AbstractModelBinderProvider<SmsRequestModel>();

            services.AddMvc(options =>
            {
                //options.Filters.Add<BizBookAuthorizationAttribute>();
                //options.Filters.Add<EntitySaveFilterAttribute>();     

                options.ModelBinderProviders.Insert(0, saleBinder);
                options.ModelBinderProviders.Insert(1, addressBinder);
                options.ModelBinderProviders.Insert(2, customersBinder);
                options.ModelBinderProviders.Insert(3, employeeInfoBinder);
                options.ModelBinderProviders.Insert(4, brandBinder);
                options.ModelBinderProviders.Insert(5, courierBinder);
                options.ModelBinderProviders.Insert(6, dealerBinder);
                options.ModelBinderProviders.Insert(7, shopBinder);
                options.ModelBinderProviders.Insert(8, supplierBinder);
                options.ModelBinderProviders.Insert(9, dealerProductBinder);
                options.ModelBinderProviders.Insert(10, productCategoryBinder);
                options.ModelBinderProviders.Insert(11, productDetailBinder);
                options.ModelBinderProviders.Insert(12, productGroupBinder);
                options.ModelBinderProviders.Insert(13, productSerialBinder);
                options.ModelBinderProviders.Insert(14, supplierProductBinder);
                options.ModelBinderProviders.Insert(15, purchaseDetailBinder);
                options.ModelBinderProviders.Insert(16, purchaseBinder);
                options.ModelBinderProviders.Insert(17, customerBySaleBinder);
                options.ModelBinderProviders.Insert(18, dailySalesOverviewBinder);
                options.ModelBinderProviders.Insert(19, salesByProductBinder);
                options.ModelBinderProviders.Insert(20, courierOrderBinder);
                options.ModelBinderProviders.Insert(21, installmentDetailtBinder);
                options.ModelBinderProviders.Insert(22, installmentBinder);
                options.ModelBinderProviders.Insert(23, saleDetailBinder);
                options.ModelBinderProviders.Insert(24, accountHeadBinder);
                options.ModelBinderProviders.Insert(25, accountInfoBinder);
                options.ModelBinderProviders.Insert(26, transactionBinder);
                options.ModelBinderProviders.Insert(27, damageBinder);
                options.ModelBinderProviders.Insert(28, stockTransferDetailBinder);
                options.ModelBinderProviders.Insert(29, stockTransferBinder);
                options.ModelBinderProviders.Insert(30, warehouseHistoryBinder);
                options.ModelBinderProviders.Insert(31, warehouseBinder);
                options.ModelBinderProviders.Insert(32, hookDetailBinder);
                options.ModelBinderProviders.Insert(33, messageBinder);
                options.ModelBinderProviders.Insert(34, smsHistoryBinder);
                options.ModelBinderProviders.Insert(35, smsHookBinder);
                options.ModelBinderProviders.Insert(36, smsBinder);
            });

            services.AddLogging(optionsBuilder => optionsBuilder.AddSerilog(dispose: true));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
