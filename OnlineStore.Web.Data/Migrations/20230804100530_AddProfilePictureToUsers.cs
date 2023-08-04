using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class AddProfilePictureToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f3574ce-6712-43ea-bdc6-cc9751fa2656"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("888b1f03-9841-4d1f-b821-72a273dd07f4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3130b76-852d-426b-a8c0-1bb8236e93f5"));

            migrationBuilder.AddColumn<byte[]>(
                name: "PictureSource",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureSource", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("596c1585-4ab6-4e3e-9126-57bd79bb36f1"), 0, "58ad26f7-1b84-4193-831c-7e1e3878936f", "Tester", "test@test.com", false, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEAp4Kkk3SX9RHp9wsPz9Xyx6EMUd2WPsQHNdVDgbFBnwCcxUrfoLNRGp/LcgSXmttg==", null, false, null, "5fa5c615-c76a-42de-898e-f67b6dbb4d7c", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureSource", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d23f5148-7cc3-4fd5-9a54-775e5a02cfad"), 0, "f6028217-7eee-4c69-a5a8-cc62050fb271", "BulkClient", "bulk@bulk.com", false, false, null, "BULK@BULK.COM", "BULK@BULK.COM", "AQAAAAEAACcQAAAAEOhgaQt9wGBX4uiix6HXHJ0VxtNewamFWpFIAZ3+JCjN0WXzjuEJFmHDUdFZpi448A==", null, false, null, "f78a3b20-032f-4734-9e60-142b20d9dca8", false, "bulk@bulk.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("596c1585-4ab6-4e3e-9126-57bd79bb36f1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23f5148-7cc3-4fd5-9a54-775e5a02cfad"));

            migrationBuilder.DropColumn(
                name: "PictureSource",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4f3574ce-6712-43ea-bdc6-cc9751fa2656"), 0, "d94f89ef-e50e-470c-8dad-9b427ad43562", null, "test@test.com", false, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAELZHvZlZvnCv8mIHXTWVoQidY9sASFgdzAo9ewui3s6ndaE7qI4Ts3bJhk/vqW+q0Q==", null, false, "027e3bcb-250a-4c62-aa9b-933588cb3cc4", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("888b1f03-9841-4d1f-b821-72a273dd07f4"), 0, "86082006-916c-48cc-b12f-9c9ce25c3db6", null, "bulk@bulk.com", false, false, null, "BULK@BULK.COM", "BULK@BULK.COM", "AQAAAAEAACcQAAAAEISAARWscWx7OvihAQWcH2/xn+ak2o6tIAe7hHl1HSqi9WPxGzpO4EO1N975itNN8w==", null, false, "4ec566c9-3498-42b7-9e2f-c6cf6c439d75", false, "bulk@bulk.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a3130b76-852d-426b-a8c0-1bb8236e93f5"), 0, "a0ee925b-0988-4863-9c2d-f14e80fcee0b", "Admin", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMNaBtkInhhPkKjzcy4CV+FLlU50pD/xik3sJRKdiyROo0/BchbW6CPIli9Hxzxgcg==", null, false, "37420118-df95-46cf-b6a9-ffb338b8b1c2", false, "admin@admin.com" });
        }
    }
}
