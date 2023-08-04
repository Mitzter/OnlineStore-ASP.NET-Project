using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class SeedUsersWithSecurityStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
