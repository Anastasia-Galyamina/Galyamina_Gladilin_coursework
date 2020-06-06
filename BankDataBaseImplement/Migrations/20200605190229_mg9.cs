using Microsoft.EntityFrameworkCore.Migrations;

namespace BankDataBaseImplement.Migrations
{
    public partial class mg9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "reserved",
                table: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "Credits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reserved",
                table: "Money");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "Credits");
        }
    }
}
