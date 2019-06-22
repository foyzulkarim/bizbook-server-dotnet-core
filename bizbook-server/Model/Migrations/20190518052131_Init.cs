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
                    WcVersion = table.Column<string>(type: "varchar(10)", nullable: true),
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
                    Name = table.Column<string>(type: "varchar(64)", nullable: true),
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
                    Name = table.Column<string>(type: "varchar(128)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(128)", nullable: false),
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
                name: "Employees",
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
                    UserId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    SaleTargetAmount = table.Column<double>(nullable: false),
                    SaleAchivedAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Shops_ShopId",
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
                    Name = table.Column<string>(type: "varchar(128)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
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
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 100, nullable: true),
                    BankName = table.Column<string>(maxLength: 50, nullable: true),
                    CardNumber = table.Column<string>(maxLength: 20, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    StartingBalance = table.Column<double>(nullable: false),
                    WalletType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Shops_ShopId",
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
                    AddressName = table.Column<string>(type: "varchar(64)", nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    ContactName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(700)", nullable: true),
                    Area = table.Column<string>(type: "varchar(172)", nullable: true),
                    Thana = table.Column<string>(type: "varchar(64)", nullable: true),
                    PostCode = table.Column<string>(type: "varchar(64)", nullable: true),
                    District = table.Column<string>(type: "varchar(64)", nullable: true),
                    Country = table.Column<string>(type: "varchar(64)", nullable: true),
                    SpecialNote = table.Column<string>(type: "varchar(256)", nullable: true),
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
                    TransactionFor = table.Column<int>(nullable: false),
                    TransactionWith = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(type: "varchar(128)", nullable: true),
                    ParentName = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    OrderId = table.Column<string>(type: "varchar(128)", nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    TransactionNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(128)", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "varchar(128)", nullable: true),
                    AccountHeadId = table.Column<string>(type: "varchar(128)", nullable: true),
                    WalletId = table.Column<string>(type: "varchar(128)", nullable: true),
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
                        name: "FK_Transactions_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
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
                    OrderNumber = table.Column<string>(type: "varchar(50)", nullable: true),
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
                    CourierName = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeliveryTrackingNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeliverymanId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DeliverymanName = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeliverymanPhone = table.Column<string>(type: "varchar(32)", nullable: true),
                    RequiredDeliveryDate = table.Column<DateTime>(nullable: true),
                    RequiredDeliveryTime = table.Column<string>(type: "varchar(128)", nullable: true),
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
                    DeliveryChargeAmount = table.Column<double>(nullable: false),
                    WcCustomerId = table.Column<int>(nullable: true),
                    OrderReferenceNumber = table.Column<string>(type: "varchar(128)", nullable: true),
                    EmployeeId = table.Column<string>(type: "varchar(128)", nullable: true),
                    EmployeeName = table.Column<string>(type: "varchar(128)", nullable: true),
                    IsTaggedSale = table.Column<bool>(nullable: false),
                    SaleTag = table.Column<string>(type: "varchar(128)", nullable: true)
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
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
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
                    BarCode = table.Column<string>(type: "varchar(128)", nullable: true),
                    HasUniqueSerial = table.Column<bool>(nullable: false),
                    HasWarrenty = table.Column<bool>(nullable: false),
                    SalePrice = table.Column<double>(nullable: false),
                    CostPrice = table.Column<double>(nullable: false),
                    StartingInventory = table.Column<int>(nullable: false),
                    Purchased = table.Column<double>(nullable: false),
                    Sold = table.Column<double>(nullable: false),
                    OnHand = table.Column<double>(nullable: false),
                    MinimumStockToNotify = table.Column<int>(nullable: false),
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
                    Payable = table.Column<double>(nullable: false)
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
                    PaidAmount = table.Column<double>(nullable: false),
                    DueAmount = table.Column<double>(nullable: false),
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeads_ShopId",
                table: "AccountHeads",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ShopId",
                table: "Addresses",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ShopId",
                table: "Brands",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShopId",
                table: "Customers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_ShopId",
                table: "Dealers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShopId",
                table: "Employees",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductGroupId",
                table: "ProductCategories",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ShopId",
                table: "ProductCategories",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_BrandId",
                table: "ProductDetails",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductCategoryId",
                table: "ProductDetails",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ShopId",
                table: "ProductDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_ShopId",
                table: "ProductGroups",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_ProductDetailId",
                table: "PurchaseDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_ShopId",
                table: "PurchaseDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ShopId",
                table: "Purchases",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_ProductDetailId",
                table: "SaleDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_ShopId",
                table: "SaleDetails",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AddressId",
                table: "Sales",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DealerId",
                table: "Sales",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ShopId",
                table: "Sales",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleStates_SaleId",
                table: "SaleStates",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleStates_ShopId",
                table: "SaleStates",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ShopId",
                table: "Suppliers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountHeadId",
                table: "Transactions",
                column: "AccountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ShopId",
                table: "Transactions",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_ShopId",
                table: "Wallets",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "SaleStates");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "AccountHeads");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
