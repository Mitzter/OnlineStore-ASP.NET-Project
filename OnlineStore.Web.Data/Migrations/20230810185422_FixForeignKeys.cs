using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class FixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3331878-e000-4205-8451-cbfc91a94df7", "AQAAAAEAACcQAAAAEIP1C1uUyYGOxH50BM9OsBd3uaXsyyRxUzJ2ghhZ3ASufZsl75i2Hhg2hm93K7GCUA==", "2159813f-2ca6-4f10-a3ea-c9ce160bac96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcec6777-125c-4279-ac10-5bb6895a357f", "AQAAAAEAACcQAAAAEFoAqR2AT0ICngxO9HeOtjKbofeEmiWCrjpb/EXCJ37TLZQH0Bb4TTjqk/BHNJ+SvQ==", "44277449-0150-4207-bc42-92be03f749ab" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 252, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 252, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 252, DateTimeKind.Utc).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 252, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 251, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 251, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 251, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("927c618e-4b91-4556-9418-93d3cbed707e"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 251, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 251, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 18, 54, 22, 251, DateTimeKind.Utc).AddTicks(6756));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a00583b-d67a-488c-a50c-612fb21162d9", "AQAAAAEAACcQAAAAEHxzLq1VpCZILxN5G2axJ8kpdnFX+aKnL1sypG8KO9m+F03uEdy+SaPRRQ1Wtc3jIw==", "63e624c9-5995-47e7-a04d-ff9e595d106f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34b276ff-ae61-4f75-8194-118220411933", "AQAAAAEAACcQAAAAEHmRcTQeDTspxab2aZcMm7ibyECS2ZgStAlOt+yil8dK6erzlmFOKWO6mweY6GwLrQ==", "d3fdaa59-fc3d-477f-ba37-1c0ff30d9989" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 618, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 618, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("927c618e-4b91-4556-9418-93d3cbed707e"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(787));
        }
    }
}
