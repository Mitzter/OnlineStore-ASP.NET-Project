using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class RemoveUnnecesasryPropertyFromBulkBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulkBuyers_AspNetUsers_UserId1",
                table: "BulkBuyers");

            migrationBuilder.DropIndex(
                name: "IX_BulkBuyers_UserId1",
                table: "BulkBuyers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BulkBuyers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "BulkBuyers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "BulkBuyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinancialManager",
                table: "BulkBuyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VATNumber",
                table: "BulkBuyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BulkBuyers_UserId",
                table: "BulkBuyers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BulkBuyers_AspNetUsers_UserId",
                table: "BulkBuyers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulkBuyers_AspNetUsers_UserId",
                table: "BulkBuyers");

            migrationBuilder.DropIndex(
                name: "IX_BulkBuyers_UserId",
                table: "BulkBuyers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "BulkBuyers");

            migrationBuilder.DropColumn(
                name: "FinancialManager",
                table: "BulkBuyers");

            migrationBuilder.DropColumn(
                name: "VATNumber",
                table: "BulkBuyers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BulkBuyers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "BulkBuyers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BulkBuyers_UserId1",
                table: "BulkBuyers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BulkBuyers_AspNetUsers_UserId1",
                table: "BulkBuyers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
