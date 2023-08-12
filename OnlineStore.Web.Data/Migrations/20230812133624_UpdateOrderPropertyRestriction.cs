using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class UpdateOrderPropertyRestriction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "399e932a-1a70-4702-a850-99ffa7e38ffd", "AQAAAAEAACcQAAAAEHq9maqa+1JKABejM+JBnSws/Ab0g3Fv3c8PqKrLGuL7xq/tortDdLcX+uTnFpphKg==", "bbc77096-3e4f-47bd-8221-7d4b1cbab77b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308ac852-d55b-4451-90f5-6bc7c062cf72", "AQAAAAEAACcQAAAAEALwRz+f12wC7MS1FraiM1wSdWdTb55O7CT8yAhFhzL9zp5H3Q/JjyjIiOL1gVcaMg==", "4b5ebcae-b1f6-4448-b01a-7217715e385d" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(944));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("927c618e-4b91-4556-9418-93d3cbed707e"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 36, 23, 564, DateTimeKind.Utc).AddTicks(971));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "208b91fd-a9dc-488f-bc47-34ed75d5b88a", "AQAAAAEAACcQAAAAEANFLVdsxy8iOf6mqirLB//W1GFlwneD7V4LUUM36A3Diaux2w7Jv9WvP64VJ05p7A==", "bb0c6877-eb94-4d5d-82c1-cd43b39b7ee4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f6858d8-5a50-4008-a9e5-9a1a2f228a5b", "AQAAAAEAACcQAAAAEIoLAzSDSjQ07PsZoV9vPof8oYk2RzK/H6dBb6pHbxCD2DtDUvvUEjzC5pCLeGM1lg==", "d09bc939-4575-41b0-84a7-38e9753433e2" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 980, DateTimeKind.Utc).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 980, DateTimeKind.Utc).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("927c618e-4b91-4556-9418-93d3cbed707e"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7553));
        }
    }
}
