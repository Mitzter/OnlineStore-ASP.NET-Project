using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("48364a71-d862-4bbf-b681-ab0315245633"), 0, "d3b0bd37-01c5-403a-a672-cf4f73556f74", null, "test@test.com", false, false, null, "test@test.com", "test@test.com", "AQAAAAEAACcQAAAAEB1hMWiXuEFq6wNITU37vkEXMNgEnchB9ctZ33Iyn3vlLnUbXpTo+RsI+Bq9rz5/sw==", null, false, null, false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a7e5a5ed-bc76-4bfe-ba05-7d32352168eb"), 0, "831f7c4a-ce52-43c5-af88-8bfefa9a4df4", "Admin", "admin@admin.com", false, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEOkKZEBQ4fDlFqbXYD4ZBN6tNm33aC2stlqLi4BzZw7VQbtn4suv+5PopSnPTmjAQA==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bbe94000-7672-4453-8ea7-3fc6901af69b"), 0, "9f077e21-5109-47c7-aed5-50279322c1e7", null, "bulk@bulk.com", false, false, null, "bulk@bulk.com", "bulk@bulk.com", "AQAAAAEAACcQAAAAEMHInDsO0adaoPfu8iCBk9A07utYVuO/JV9URMfVbc3mQ5WDyC6Zo72iYyMZmTXUdQ==", null, false, null, false, "bulk@bulk.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48364a71-d862-4bbf-b681-ab0315245633"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a7e5a5ed-bc76-4bfe-ba05-7d32352168eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbe94000-7672-4453-8ea7-3fc6901af69b"));

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");
        }
    }
}
