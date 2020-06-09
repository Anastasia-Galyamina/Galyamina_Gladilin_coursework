using Microsoft.EntityFrameworkCore.Migrations;

namespace BankDataBaseImplement.Migrations
{
    public partial class mgFinal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResesvedMoney_Clients_ClientId",
                table: "ResesvedMoney");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ResesvedMoney",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResesvedMoney_Clients_ClientId",
                table: "ResesvedMoney",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResesvedMoney_Clients_ClientId",
                table: "ResesvedMoney");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ResesvedMoney",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ResesvedMoney_Clients_ClientId",
                table: "ResesvedMoney",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
