using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankDataBaseImplement.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Credits_CreditId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_CreditId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "DateImplement",
                table: "Deals");

            migrationBuilder.AddColumn<string>(
                name: "CreditName",
                table: "Deals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DealName",
                table: "Deals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DealCredits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealId = table.Column<int>(nullable: false),
                    CreditId = table.Column<int>(nullable: false),
                    dateImplement = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealCredits_Credits_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealCredits_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealCredits_CreditId",
                table: "DealCredits",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_DealCredits_DealId",
                table: "DealCredits",
                column: "DealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealCredits");

            migrationBuilder.DropColumn(
                name: "CreditName",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "DealName",
                table: "Deals");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Deals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateImplement",
                table: "Deals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CreditId",
                table: "Deals",
                column: "CreditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Credits_CreditId",
                table: "Deals",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
