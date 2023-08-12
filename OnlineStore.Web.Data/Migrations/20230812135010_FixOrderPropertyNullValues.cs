using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class FixOrderPropertyNullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12f4db5e-f93a-47dc-aa23-1e3fe794a741", "AQAAAAEAACcQAAAAEHeGMgseVhc6YWvQ0JkKCXIOZEK9NnszDQYMGnO2C1L9VdeU4wVrvBpttvoUnXMXgA==", "3fad4594-1288-4ad2-af34-a434351ff76e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdb62b6c-6563-4f22-b4c1-b700e0e364e0", "AQAAAAEAACcQAAAAEI4R18ivn7FOzdor3SIYP+QAPk3vjoK69sPZhIDS4JW/wVbdBhToMfBrq5dXaiaW+A==", "d9bbea92-f4dd-4d1e-bb51-046ecba4578b" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("927c618e-4b91-4556-9418-93d3cbed707e"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"),
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 13, 50, 9, 891, DateTimeKind.Utc).AddTicks(4023));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
