using Microsoft.EntityFrameworkCore.Migrations;

namespace BankDataBaseImplement.Migrations
{
    public partial class mg10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reserved",
                table: "Money");

            migrationBuilder.AddColumn<decimal>(
                name: "Reserved",
                table: "StorageMoney",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "reserved",
                table: "Deals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "StorageMoney");

            migrationBuilder.DropColumn(
                name: "reserved",
                table: "Deals");

            migrationBuilder.AddColumn<decimal>(
                name: "reserved",
                table: "Money",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
