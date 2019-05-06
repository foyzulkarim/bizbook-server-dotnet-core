using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WcVersion",
                table: "Shops",
                type: "varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WcVersion",
                table: "Shops");
        }
    }
}
