using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Shops_SupplierShopId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_SupplierShopId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierShopId",
                table: "Suppliers");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_Id",
                table: "Suppliers",
                newName: "IX_Suppliers_ShopId1");

            migrationBuilder.AddColumn<string>(
                name: "ShopId2",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ShopId2",
                table: "Suppliers",
                column: "ShopId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Shops_ShopId2",
                table: "Suppliers",
                column: "ShopId2",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Shops_ShopId2",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ShopId2",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ShopId2",
                table: "Suppliers");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_ShopId1",
                table: "Suppliers",
                newName: "IX_Shop_Id");

            migrationBuilder.AddColumn<string>(
                name: "SupplierShopId",
                table: "Suppliers",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierShopId",
                table: "Suppliers",
                column: "SupplierShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Shops_SupplierShopId",
                table: "Suppliers",
                column: "SupplierShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
