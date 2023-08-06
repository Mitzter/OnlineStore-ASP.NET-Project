using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class OrderEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("596c1585-4ab6-4e3e-9126-57bd79bb36f1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23f5148-7cc3-4fd5-9a54-775e5a02cfad"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId1",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureSource", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2b2c52d8-7453-43d1-bd7c-e2c424aa4aa8"), 0, "8bb4ceff-73af-4782-a8cc-1b67aab21ed5", "BulkClient", "bulk@bulk.com", false, false, null, "BULK@BULK.COM", "BULK@BULK.COM", "AQAAAAEAACcQAAAAEH28I9jtlNar4JjAOPj5p455ahLbYil42RBpMyuP1JDK193Xa0jtRwBcAW4yvi3KXA==", null, false, null, "38e72bdd-8691-44d3-ae7a-1cc1da0b6b09", false, "bulk@bulk.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureSource", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9df1908d-9958-4d58-9797-5290dbca9408"), 0, "566e1e13-8bf8-40bd-8149-702037600051", "Tester", "test@test.com", false, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEE1OgABWxhdm7DKUkn02ywIzXGQyNvEo+AT4T2Ki+R7X9fZQR6wmXRn90P1fwiM/BA==", null, false, null, "76224606-911d-468a-83e7-26fb03f760fe", false, "test@test.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId1",
                table: "Items",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Order_OrderId",
                table: "Items",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Order_OrderId1",
                table: "Items",
                column: "OrderId1",
                principalTable: "Order",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Order_OrderId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Order_OrderId1",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderId1",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b2c52d8-7453-43d1-bd7c-e2c424aa4aa8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9df1908d-9958-4d58-9797-5290dbca9408"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Items");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureSource", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("596c1585-4ab6-4e3e-9126-57bd79bb36f1"), 0, "58ad26f7-1b84-4193-831c-7e1e3878936f", "Tester", "test@test.com", false, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEAp4Kkk3SX9RHp9wsPz9Xyx6EMUd2WPsQHNdVDgbFBnwCcxUrfoLNRGp/LcgSXmttg==", null, false, null, "5fa5c615-c76a-42de-898e-f67b6dbb4d7c", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureSource", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d23f5148-7cc3-4fd5-9a54-775e5a02cfad"), 0, "f6028217-7eee-4c69-a5a8-cc62050fb271", "BulkClient", "bulk@bulk.com", false, false, null, "BULK@BULK.COM", "BULK@BULK.COM", "AQAAAAEAACcQAAAAEOhgaQt9wGBX4uiix6HXHJ0VxtNewamFWpFIAZ3+JCjN0WXzjuEJFmHDUdFZpi448A==", null, false, null, "f78a3b20-032f-4734-9e60-142b20d9dca8", false, "bulk@bulk.com" });
        }
    }
}
