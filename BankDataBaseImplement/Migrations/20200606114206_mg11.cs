using Microsoft.EntityFrameworkCore.Migrations;

namespace BankDataBaseImplement.Migrations
{
    public partial class mg11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageMoney_Storages_StorageId",
                table: "StorageMoney");

            migrationBuilder.DropIndex(
                name: "IX_StorageMoney_StorageId",
                table: "StorageMoney");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "StorageMoney");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "StorageMoney",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StorageMoney_StorageId",
                table: "StorageMoney",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageMoney_Storages_StorageId",
                table: "StorageMoney",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
