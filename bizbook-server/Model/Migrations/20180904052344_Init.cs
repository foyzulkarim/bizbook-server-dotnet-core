using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    NameBn = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(512)", nullable: true),
                    Area = table.Column<string>(type: "varchar(128)", nullable: true),
                    Thana = table.Column<string>(type: "varchar(128)", nullable: true),
                    PostCode = table.Column<string>(type: "varchar(128)", nullable: true),
                    District = table.Column<string>(type: "varchar(128)", nullable: true),
                    Country = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonDesignation = table.Column<string>(type: "varchar(128)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(128)", nullable: true),
                    Website = table.Column<string>(type: "varchar(128)", nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", nullable: true),
                    Facebook = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    About = table.Column<string>(type: "varchar(128)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SubscriptionType = table.Column<string>(type: "varchar(128)", nullable: true),
                    TotalUsers = table.Column<int>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    WcUrl = table.Column<string>(type: "varchar(128)", nullable: true),
                    LogoUrl = table.Column<string>(type: "varchar(128)", nullable: true),
                    HasDeliveryChain = table.Column<bool>(nullable: false),
                    IsShowOrderNumber = table.Column<bool>(nullable: false),
                    IsAutoAddToCart = table.Column<bool>(nullable: false),
                    DeliveryCharge = table.Column<float>(nullable: false),
                    ReceiptName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ChalanName = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcKey = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcSecret = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcWebhookSource = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountHeads",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    AccountHeadType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountHeads_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountInfoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    AccountTitle = table.Column<string>(type: "varchar(100)", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(64)", nullable: true),
                    BankName = table.Column<string>(type: "varchar(64)", nullable: true),
                    AccountInfoType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountInfoes_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Address = table.Column<string>(type: "varchar(128)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(36)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(64)", nullable: true),
                    Country = table.Column<string>(type: "varchar(32)", nullable: true),
                    MadeInCountry = table.Column<string>(type: "varchar(32)", nullable: true),
                    Email = table.Column<string>(type: "varchar(32)", nullable: true),
                    BrandCode = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "varchar(64)", nullable: false),
                    CourierShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    CourierShopName = table.Column<string>(type: "varchar(64)", nullable: true),
                    CourierShopPhone = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couriers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    MembershipCardNo = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", nullable: true),
                    Occupation = table.Column<string>(type: "varchar(32)", nullable: true),
                    University = table.Column<string>(type: "varchar(32)", nullable: true),
                    Company = table.Column<string>(type: "varchar(32)", nullable: true),
                    Point = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrdersCount = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    TotalDiscount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    TotalPaid = table.Column<double>(nullable: false),
                    TotalDue = table.Column<double>(nullable: false),
                    WcId = table.Column<int>(nullable: false),
                    NationalId = table.Column<string>(type: "varchar(32)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(128)", nullable: true),
                    Area = table.Column<string>(type: "varchar(128)", nullable: true),
                    Thana = table.Column<string>(type: "varchar(128)", nullable: true),
                    PostCode = table.Column<string>(type: "varchar(128)", nullable: true),
                    District = table.Column<string>(type: "varchar(128)", nullable: true),
                    Country = table.Column<string>(type: "varchar(128)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    OrdersCount = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    TotalDiscount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    TotalPaid = table.Column<double>(nullable: false),
                    TotalDue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    CashPriceAmount = table.Column<double>(nullable: false),
                    ProfitPercent = table.Column<double>(nullable: false),
                    ProfitAmount = table.Column<double>(nullable: false),
                    InstallmentTotalAmount = table.Column<double>(nullable: false),
                    DownPaymentPercent = table.Column<double>(nullable: false),
                    DownPaymentAmount = table.Column<double>(nullable: false),
                    InstallmentDueAmount = table.Column<double>(nullable: false),
                    InstallmentMonth = table.Column<string>(type: "varchar(128)", nullable: true),
                    InstallmentPerMonthAmount = table.Column<double>(nullable: false),
                    SaleType = table.Column<int>(nullable: false),
                    CashPriceDueAmount = table.Column<double>(nullable: false),
                    ProfitAmountPerMonth = table.Column<double>(nullable: false),
                    SaleId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installments_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroups_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Text = table.Column<string>(type: "varchar(128)", nullable: true),
                    ReceiverNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    ReceiverId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ReasonType = table.Column<int>(nullable: false),
                    ReasonId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliveryStatus = table.Column<string>(type: "varchar(128)", nullable: true),
                    Ismasked = table.Column<bool>(nullable: false),
                    SmsReceiverType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sms_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmsHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    SmsId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Text = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsHistories_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmsHooks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    BizSmsHook = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsHooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsHooks_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(128)", nullable: true),
                    Area = table.Column<string>(type: "varchar(128)", nullable: true),
                    Thana = table.Column<string>(type: "varchar(128)", nullable: true),
                    PostCode = table.Column<string>(type: "varchar(128)", nullable: true),
                    District = table.Column<string>(type: "varchar(128)", nullable: true),
                    Country = table.Column<string>(type: "varchar(128)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    SupplierShopId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ShopId1 = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrdersCount = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    TotalDiscount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    TotalPaid = table.Column<double>(nullable: false),
                    TotalDue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suppliers_Shops_ShopId1",
                        column: x => x.ShopId1,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suppliers_Shops_SupplierShopId",
                        column: x => x.SupplierShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(128)", nullable: true),
                    Area = table.Column<string>(type: "varchar(128)", nullable: true),
                    District = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    DistrictId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zones_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    TransactionFlowType = table.Column<int>(nullable: false),
                    TransactionMedium = table.Column<int>(nullable: false),
                    PaymentGatewayService = table.Column<int>(nullable: false),
                    TransactionFor = table.Column<int>(nullable: false),
                    TransactionWith = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ParentName = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    TransactionMediumName = table.Column<string>(type: "varchar(128)", nullable: true),
                    PaymentGatewayServiceName = table.Column<string>(type: "varchar(128)", nullable: true),
                    TransactionNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    AccountHeadName = table.Column<string>(type: "varchar(128)", nullable: true),
                    AccountHeadId = table.Column<string>(type: "varchar(128)", nullable: true),
                    AccountInfoId = table.Column<string>(type: "varchar(128)", nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AccountHeads_AccountHeadId",
                        column: x => x.AccountHeadId,
                        principalTable: "AccountHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_AccountInfoes_AccountInfoId",
                        column: x => x.AccountInfoId,
                        principalTable: "AccountInfoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(700)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(172)", nullable: true),
                    Thana = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Country = table.Column<string>(type: "varchar(64)", nullable: true),
                    SpecialNote = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CustomerId = table.Column<string>(type: "varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcId = table.Column<int>(nullable: false),
                    ProductGroupId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HookDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    HookName = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    SmsHookId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HookDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HookDetails_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HookDetails_SmsHooks_SmsHookId",
                        column: x => x.SmsHookId,
                        principalTable: "SmsHooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(128)", nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    SaleTargetAmount = table.Column<double>(nullable: false),
                    SaleAchivedAmount = table.Column<double>(nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInfoes_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInfoes_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    OrderNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    ShippingAmount = table.Column<double>(nullable: false),
                    ProductAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    DueAmount = table.Column<double>(nullable: false),
                    State = table.Column<string>(type: "varchar(128)", nullable: true),
                    ShippingProvider = table.Column<string>(type: "varchar(128)", nullable: true),
                    ShipmentTrackingNo = table.Column<string>(type: "varchar(128)", nullable: true),
                    SupplierId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderReferenceNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTransfers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    OrderNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderReferenceNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductAmount = table.Column<double>(nullable: false),
                    DeliveryTrackingNo = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanName = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    EstimatedDeliveryDate = table.Column<DateTime>(nullable: true),
                    SourceWarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DestinationWarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    TransferState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Warehouses_DestinationWarehouseId",
                        column: x => x.DestinationWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Warehouses_SourceWarehouseId",
                        column: x => x.SourceWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseZones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ZoneId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseZones_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseZones_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseZones_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    Model = table.Column<string>(type: "varchar(128)", nullable: true),
                    Year = table.Column<string>(type: "varchar(128)", nullable: true),
                    BarCode = table.Column<string>(type: "varchar(128)", nullable: true),
                    HasUniqueSerial = table.Column<bool>(nullable: false),
                    HasWarrenty = table.Column<bool>(nullable: false),
                    SalePrice = table.Column<double>(nullable: false),
                    CostPrice = table.Column<double>(nullable: false),
                    Type = table.Column<string>(type: "varchar(128)", nullable: true),
                    Color = table.Column<string>(type: "varchar(128)", nullable: true),
                    StartingInventory = table.Column<int>(nullable: false),
                    Purchased = table.Column<double>(nullable: false),
                    Sold = table.Column<double>(nullable: false),
                    OnHand = table.Column<double>(nullable: false),
                    MinimumStockToNotify = table.Column<int>(nullable: false),
                    WcId = table.Column<int>(nullable: false),
                    Permalink = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcType = table.Column<string>(type: "varchar(128)", nullable: true),
                    Description = table.Column<string>(type: "varchar(128)", nullable: true),
                    ShortDescription = table.Column<string>(type: "varchar(128)", nullable: true),
                    Tags = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcCategoryId = table.Column<int>(nullable: false),
                    RelatedIds = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcVariationPermalink = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcVariationId = table.Column<int>(nullable: false),
                    WcVariationOption = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductCategoryId = table.Column<string>(type: "varchar(128)", nullable: true),
                    BrandId = table.Column<string>(type: "varchar(128)", nullable: true),
                    HasExpiryDate = table.Column<bool>(nullable: false),
                    ExpireInDays = table.Column<int>(nullable: false),
                    DealerPrice = table.Column<double>(nullable: false),
                    ProductCode = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    OrderNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductAmount = table.Column<double>(nullable: false),
                    TaxAmount = table.Column<double>(nullable: false),
                    PaymentServiceChargeAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    PayableTotalAmount = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    DueAmount = table.Column<double>(nullable: false),
                    CostAmount = table.Column<double>(nullable: false),
                    ProfitAmount = table.Column<double>(nullable: false),
                    ProfitPercent = table.Column<double>(nullable: false),
                    CourierShopId = table.Column<string>(type: "varchar(128)", nullable: true),
                    CourierName = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliveryTrackingNo = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanName = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    EstimatedDeliveryDate = table.Column<DateTime>(nullable: true),
                    RequiredDeliveryDateByCustomer = table.Column<DateTime>(nullable: true),
                    RequiredDeliveryTimeByCustomer = table.Column<string>(type: "varchar(128)", nullable: true),
                    CustomerId = table.Column<string>(type: "varchar(128)", nullable: true),
                    AddressId = table.Column<string>(type: "varchar(128)", nullable: true),
                    CustomerArea = table.Column<string>(type: "varchar(128)", nullable: true),
                    CustomerName = table.Column<string>(type: "varchar(128)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    CustomerNote = table.Column<string>(type: "varchar(800)", nullable: true),
                    IsDealerSale = table.Column<bool>(nullable: false),
                    DealerId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(256)", nullable: true),
                    Version = table.Column<int>(nullable: false),
                    ParentSaleId = table.Column<string>(type: "varchar(128)", nullable: true),
                    SaleChannel = table.Column<int>(nullable: false),
                    SaleFrom = table.Column<int>(nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    WcId = table.Column<int>(nullable: true),
                    WcOrderKey = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcCartHash = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcOrderStatus = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliveryChargeAmount = table.Column<double>(nullable: false),
                    WcCustomerId = table.Column<int>(nullable: true),
                    OrderReferenceNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    EmployeeInfoId = table.Column<string>(type: "varchar(128)", nullable: true),
                    EmployeeInfoName = table.Column<string>(type: "varchar(128)", nullable: true),
                    PaidByCashAmount = table.Column<double>(nullable: false),
                    PaidByOtherAmount = table.Column<double>(nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsTaggedSale = table.Column<bool>(nullable: false),
                    SaleTag = table.Column<string>(type: "varchar(128)", nullable: true),
                    Guarantor1Id = table.Column<string>(type: "varchar(128)", nullable: true),
                    Guarantor2Id = table.Column<string>(type: "varchar(128)", nullable: true),
                    InstallmentId = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_EmployeeInfoes_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Installments_InstallmentId",
                        column: x => x.InstallmentId,
                        principalTable: "Installments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Damages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Damages_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damages_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damages_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealerProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Paid = table.Column<double>(nullable: false),
                    Due = table.Column<double>(nullable: false),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DealerId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerProducts_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealerProducts_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealerProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    WcId = table.Column<int>(nullable: false),
                    Src = table.Column<string>(type: "varchar(128)", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", nullable: true),
                    Alt = table.Column<string>(type: "varchar(128)", nullable: true),
                    Position = table.Column<int>(nullable: true),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    PurchaseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    CostPricePerUnit = table.Column<double>(nullable: false),
                    CostTotal = table.Column<double>(nullable: false),
                    Paid = table.Column<double>(nullable: false),
                    Payable = table.Column<double>(nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTransferDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    SalePricePerUnit = table.Column<double>(nullable: false),
                    PriceTotal = table.Column<double>(nullable: false),
                    StockTransferId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    SourceWarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DestinationWarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_Warehouses_DestinationWarehouseId",
                        column: x => x.DestinationWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_Warehouses_SourceWarehouseId",
                        column: x => x.SourceWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferDetails_StockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "StockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Paid = table.Column<double>(nullable: false),
                    Due = table.Column<double>(nullable: false),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    SupplierId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierProducts_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierProducts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    StartingInventory = table.Column<int>(nullable: false),
                    Purchased = table.Column<double>(nullable: false),
                    Sold = table.Column<double>(nullable: false),
                    TransferredIn = table.Column<double>(nullable: false),
                    TransferredOut = table.Column<double>(nullable: false),
                    OnHand = table.Column<double>(nullable: false),
                    MinimumStockToNotify = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    InstallmentId = table.Column<string>(type: "varchar(128)", nullable: true),
                    SaleId = table.Column<string>(type: "varchar(128)", nullable: true),
                    TansactionId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ScheduledAmount = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    DueAmount = table.Column<double>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentDetails_Installments_InstallmentId",
                        column: x => x.InstallmentId,
                        principalTable: "Installments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentDetails_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentDetails_Transactions_TansactionId",
                        column: x => x.TansactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    CostPricePerUnit = table.Column<double>(nullable: false),
                    CostTotal = table.Column<double>(nullable: false),
                    SalePricePerUnit = table.Column<double>(nullable: false),
                    PriceTotal = table.Column<double>(nullable: false),
                    DiscountTotal = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    ProductSerialNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsReturned = table.Column<bool>(nullable: false),
                    ReturnReason = table.Column<string>(type: "varchar(128)", nullable: true),
                    SaleId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    WcId = table.Column<int>(nullable: true),
                    WcProductId = table.Column<int>(nullable: true),
                    WcProductVariationId = table.Column<int>(nullable: true),
                    PaidAmount = table.Column<double>(nullable: false),
                    DueAmount = table.Column<double>(nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDetails_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleStates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    State = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(256)", nullable: true),
                    SaleId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleStates_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleStates_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealerProductTransactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TransactionId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DealerProductId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerProductTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerProductTransactions_DealerProducts_DealerProductId",
                        column: x => x.DealerProductId,
                        principalTable: "DealerProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealerProductTransactions_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealerProductTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSerials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    ProductDetailId = table.Column<string>(type: "varchar(128)", nullable: true),
                    PurchaseDetailId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSerials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSerials_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSerials_PurchaseDetails_PurchaseDetailId",
                        column: x => x.PurchaseDetailId,
                        principalTable: "PurchaseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSerials_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProductTransactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedFrom = table.Column<string>(type: "varchar(32)", nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShopId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TransactionId = table.Column<string>(type: "varchar(128)", nullable: true),
                    SupplierProductId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProductTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierProductTransactions_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierProductTransactions_SupplierProducts_SupplierProductId",
                        column: x => x.SupplierProductId,
                        principalTable: "SupplierProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierProductTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeadType",
                table: "AccountHeads",
                column: "AccountHeadType");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "AccountHeads",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "AccountHeads",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeadName",
                table: "AccountHeads",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeadRemarks",
                table: "AccountHeads",
                column: "Remarks");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "AccountHeads",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfoType",
                table: "AccountInfoes",
                column: "AccountInfoType");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTitle",
                table: "AccountInfoes",
                column: "AccountTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "AccountInfoes",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "AccountInfoes",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "AccountInfoes",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Addresses",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Addresses",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Addresses",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Brands",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Brands",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Brands",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Brands",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierShopId",
                table: "Couriers",
                column: "CourierShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Couriers",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Couriers",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Couriers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Customers",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "Customers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipCardNo",
                table: "Customers",
                column: "MembershipCardNo");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Customers",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Customers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_NationalId",
                table: "Customers",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCount",
                table: "Customers",
                column: "OrdersCount");

            migrationBuilder.CreateIndex(
                name: "IX_OtherAmount",
                table: "Customers",
                column: "OtherAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Phone",
                table: "Customers",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Point",
                table: "Customers",
                column: "Point");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAmount",
                table: "Customers",
                column: "ProductAmount");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Customers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmount",
                table: "Customers",
                column: "TotalAmount");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDiscount",
                table: "Customers",
                column: "TotalDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDue",
                table: "Customers",
                column: "TotalDue");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPaid",
                table: "Customers",
                column: "TotalPaid");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Damages",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Damages",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "Damages",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Damages",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "Damages",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "DealerProducts",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_DealerId",
                table: "DealerProducts",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "DealerProducts",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "DealerProducts",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "DealerProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "DealerProductTransactions",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_DealerProductId",
                table: "DealerProductTransactions",
                column: "DealerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "DealerProductTransactions",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "DealerProductTransactions",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionId",
                table: "DealerProductTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Dealers",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Dealers",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Dealers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCount",
                table: "Dealers",
                column: "OrdersCount");

            migrationBuilder.CreateIndex(
                name: "IX_OtherAmount",
                table: "Dealers",
                column: "OtherAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Phone",
                table: "Dealers",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAmount",
                table: "Dealers",
                column: "ProductAmount");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Dealers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmount",
                table: "Dealers",
                column: "TotalAmount");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDiscount",
                table: "Dealers",
                column: "TotalDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDue",
                table: "Dealers",
                column: "TotalDue");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPaid",
                table: "Dealers",
                column: "TotalPaid");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Districts",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Districts",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "EmployeeInfoes",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "EmployeeInfoes",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "EmployeeInfoes",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "EmployeeInfoes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Phone",
                table: "EmployeeInfoes",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "EmployeeInfoes",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "EmployeeInfoes",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "HookDetails",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_HookName",
                table: "HookDetails",
                column: "HookName");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "HookDetails",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "HookDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsHookId",
                table: "HookDetails",
                column: "SmsHookId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "InstallmentDetails",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentId",
                table: "InstallmentDetails",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "InstallmentDetails",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_SaleId",
                table: "InstallmentDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "InstallmentDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_TansactionId",
                table: "InstallmentDetails",
                column: "TansactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Installments",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Installments",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Installments",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "ProductCategories",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "ProductCategories",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ProductCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupId",
                table: "ProductCategories",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "ProductCategories",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WcId",
                table: "ProductCategories",
                column: "WcId");

            migrationBuilder.CreateIndex(
                name: "IX_BarCode",
                table: "ProductDetails",
                column: "BarCode");

            migrationBuilder.CreateIndex(
                name: "IX_BrandId",
                table: "ProductDetails",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "ProductDetails",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "ProductDetails",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ProductDetails",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryId",
                table: "ProductDetails",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCode",
                table: "ProductDetails",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "ProductDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WcCategoryId",
                table: "ProductDetails",
                column: "WcCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WcId",
                table: "ProductDetails",
                column: "WcId");

            migrationBuilder.CreateIndex(
                name: "IX_WcVariationId",
                table: "ProductDetails",
                column: "WcVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "ProductGroups",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "ProductGroups",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ProductGroups",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "ProductGroups",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "ProductImages",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "ProductImages",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "ProductImages",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "ProductImages",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "ProductSerials",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "ProductSerials",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "ProductSerials",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailId",
                table: "ProductSerials",
                column: "PurchaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumber",
                table: "ProductSerials",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "ProductSerials",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "PurchaseDetails",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "PurchaseDetails",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "PurchaseDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "PurchaseDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "PurchaseDetails",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Purchases",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Purchases",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNumber",
                table: "Purchases",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Purchases",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "Purchases",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "SaleDetails",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "SaleDetails",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "SaleDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "SaleDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "SaleDetails",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WcId",
                table: "SaleDetails",
                column: "WcId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressId",
                table: "Sales",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierShopId",
                table: "Sales",
                column: "CourierShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Sales",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerId",
                table: "Sales",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfoId",
                table: "Sales",
                column: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentId",
                table: "Sales",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Sales",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNumber",
                table: "Sales",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderState",
                table: "Sales",
                column: "OrderState");

            migrationBuilder.CreateIndex(
                name: "IX_SaleChannel",
                table: "Sales",
                column: "SaleChannel");

            migrationBuilder.CreateIndex(
                name: "IX_SaleFrom",
                table: "Sales",
                column: "SaleFrom");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Sales",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "Sales",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WcCustomerId",
                table: "Sales",
                column: "WcCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WcId",
                table: "Sales",
                column: "WcId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "SaleStates",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "SaleStates",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_SaleId",
                table: "SaleStates",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "SaleStates",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_State",
                table: "SaleStates",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonDesignation",
                table: "Shops",
                column: "ContactPersonDesignation");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonName",
                table: "Shops",
                column: "ContactPersonName");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonPhone",
                table: "Shops",
                column: "ContactPersonPhone");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Shops",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "Shops",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Facebook",
                table: "Shops",
                column: "Facebook");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Shops",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopName",
                table: "Shops",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShopPhone",
                table: "Shops",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_WcKey",
                table: "Shops",
                column: "WcKey");

            migrationBuilder.CreateIndex(
                name: "IX_WcSecret",
                table: "Shops",
                column: "WcSecret");

            migrationBuilder.CreateIndex(
                name: "IX_WcUrl",
                table: "Shops",
                column: "WcUrl");

            migrationBuilder.CreateIndex(
                name: "IX_WcWebhookSource",
                table: "Shops",
                column: "WcWebhookSource");

            migrationBuilder.CreateIndex(
                name: "IX_Website",
                table: "Shops",
                column: "Website");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Sms",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Sms",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonId",
                table: "Sms",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonType",
                table: "Sms",
                column: "ReasonType");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverId",
                table: "Sms",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverNumber",
                table: "Sms",
                column: "ReceiverNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Sms",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "SmsHistories",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "SmsHistories",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "SmsHistories",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "SmsHooks",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "SmsHooks",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "SmsHooks",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "StockTransferDetails",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationWarehouseId",
                table: "StockTransferDetails",
                column: "DestinationWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "StockTransferDetails",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "StockTransferDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "StockTransferDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceWarehouseId",
                table: "StockTransferDetails",
                column: "SourceWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferId",
                table: "StockTransferDetails",
                column: "StockTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "StockTransfers",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationWarehouseId",
                table: "StockTransfers",
                column: "DestinationWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "StockTransfers",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNumber",
                table: "StockTransfers",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "StockTransfers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceWarehouseId",
                table: "StockTransfers",
                column: "SourceWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "SupplierProducts",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "SupplierProducts",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "SupplierProducts",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "SupplierProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierId",
                table: "SupplierProducts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "SupplierProductTransactions",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "SupplierProductTransactions",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "SupplierProductTransactions",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductId",
                table: "SupplierProductTransactions",
                column: "SupplierProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionId",
                table: "SupplierProductTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Suppliers",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Suppliers",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Suppliers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCount",
                table: "Suppliers",
                column: "OrdersCount");

            migrationBuilder.CreateIndex(
                name: "IX_OtherAmount",
                table: "Suppliers",
                column: "OtherAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Phone",
                table: "Suppliers",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAmount",
                table: "Suppliers",
                column: "ProductAmount");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Suppliers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "Suppliers",
                column: "ShopId1");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierShopId",
                table: "Suppliers",
                column: "SupplierShopId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmount",
                table: "Suppliers",
                column: "TotalAmount");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDiscount",
                table: "Suppliers",
                column: "TotalDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_TotalDue",
                table: "Suppliers",
                column: "TotalDue");

            migrationBuilder.CreateIndex(
                name: "IX_TotalPaid",
                table: "Suppliers",
                column: "TotalPaid");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeadId",
                table: "Transactions",
                column: "AccountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeadName",
                table: "Transactions",
                column: "AccountHeadName");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfoId",
                table: "Transactions",
                column: "AccountInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Amount",
                table: "Transactions",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Transactions",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Transactions",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_OrderId",
                table: "Transactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNumber",
                table: "Transactions",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ParentId",
                table: "Transactions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentName",
                table: "Transactions",
                column: "ParentName");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGatewayService",
                table: "Transactions",
                column: "PaymentGatewayService");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGatewayServiceName",
                table: "Transactions",
                column: "PaymentGatewayServiceName");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Transactions",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFlowType",
                table: "Transactions",
                column: "TransactionFlowType");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFor",
                table: "Transactions",
                column: "TransactionFor");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMedium",
                table: "Transactions",
                column: "TransactionMedium");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMediumName",
                table: "Transactions",
                column: "TransactionMediumName");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNumber",
                table: "Transactions",
                column: "TransactionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionWith",
                table: "Transactions",
                column: "TransactionWith");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "WarehouseProducts",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "WarehouseProducts",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailId",
                table: "WarehouseProducts",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "WarehouseProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "WarehouseProducts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Warehouses",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Warehouses",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "Warehouses",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "WarehouseZones",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "WarehouseZones",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "WarehouseZones",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseId",
                table: "WarehouseZones",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneId",
                table: "WarehouseZones",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "Zones",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictId",
                table: "Zones",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Modified",
                table: "Zones",
                column: "Modified");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ShopId",
                table: "Zones",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropTable(
                name: "Damages");

            migrationBuilder.DropTable(
                name: "DealerProductTransactions");

            migrationBuilder.DropTable(
                name: "HookDetails");

            migrationBuilder.DropTable(
                name: "InstallmentDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSerials");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "SaleStates");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "SmsHistories");

            migrationBuilder.DropTable(
                name: "StockTransferDetails");

            migrationBuilder.DropTable(
                name: "SupplierProductTransactions");

            migrationBuilder.DropTable(
                name: "WarehouseProducts");

            migrationBuilder.DropTable(
                name: "WarehouseZones");

            migrationBuilder.DropTable(
                name: "DealerProducts");

            migrationBuilder.DropTable(
                name: "SmsHooks");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "StockTransfers");

            migrationBuilder.DropTable(
                name: "SupplierProducts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "EmployeeInfoes");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "AccountHeads");

            migrationBuilder.DropTable(
                name: "AccountInfoes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
