using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class FixItemSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items");

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

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ApplicationUserId", "BulkPrice", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"), null, 75m, 5, new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7558), "Stylish sports rims made of the highest quality Polish Alluminum. Extremely durable and won't bend as easily as regular alluminum 'summer' rims. Country of manufacture: Poland", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUyBauHMYH3D89DHPOUPsGeTZ8cNlwt2fi740hn5nT9B4g9pVc3Xo3KdczDUGknfokPEE&usqp=CAU", true, "Black and Red Alluminum Sports rims", 150m },
                    { new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"), null, 4.50m, 1, new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7545), "Easy to use lubricant spray for moving parts and machinery. The lithium grease in an aerosolized form prevents you from having to get your hands dirty with using conventional grease", "https://markita.net/sites/default/files/styles/markita_products_4_colons_157_x_130_/public/2021-02/%D0%93%D0%A0%D0%95%D0%A1%20%D0%9B%D0%98%D0%A2%D0%98%D0%95%D0%92%D0%90%20%D0%A1%D0%9F%D0%A0%D0%95%D0%99%20400%D0%BC%D0%BB%20DL600%20%D0%A3%D0%9D%D0%98%D0%92%D0%95%D0%A0%D0%A1%D0%90%D0%9B%D0%9D%D0%90.JPG", true, "DL-600 Universal Lithium Grease", 8m },
                    { new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"), null, 3.50m, 1, new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7528), "General purpose spray for loosening screws and bolts covered in rust and prevents rust from building up. Can also function as a lubricant for moving parts", "https://tpetrov.com/thumbs/3/spr-dl60-4.jpg", true, "DL-60 Multifunctional Spray", 5m },
                    { new Guid("927c618e-4b91-4556-9418-93d3cbed707e"), null, 100m, 6, new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7574), "Specifications:Hydraulic trolley jack features a 3 ton (6,600 lbs) capacity with lifting height from 5.1\" to 18.3\".Floor Jack saddle Diameter: 4 inch.With quick lift function.Its the best tool for car repairing and auto emergency treatment in garage,shop", "https://m.media-amazon.com/images/I/71dhyZ89JkL.jpg", true, "Jack Boss Floor Jack 3 Ton Capacity Fast Lift Service Jack Steel Heavy Duty Hydraulic Car Jack", 200m },
                    { new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"), null, 35m, 4, new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7569), "FITMENT — 2009-2023 Ram 1500/Ram 1500 Classic, 2010-2018 Ram 2500/3500 w/Single Rear Wheels & w/out OEM Fender Flares\r\nFITS LIKE FACTORY — Built specifically for your make and model providing that perfectly tailored fit. Available in full-tread coverage for single- or dually-factory tire width.\r\nIMPACT RESISTANT CONSTRUCTION — Built to stand up to a lifetime of abuse thanks to its nail-tough, impact-resistant thermoplastic construction. With proprietary Husky Shield Film for an invisible layer of protection.\r\nEASY TO INSTALL — A few screws and a few minutes are all it takes to mount Mud Guards for a perfect match to your vehicle every time.\r\nUPGRADED LOOKS — An instant improvement for your vehicle’s appearance with sleek style that looks like it came from the factory, with some added custom flair.\r\nLIFETIME GUARANTEE — Proudly made in the USA. When we say it’s “guaranteed for life” that is exactly what we mean. No hassles, no guff. If you have a problem with this or any Husky product, we’ll replace it.", "https://m.media-amazon.com/images/I/61pbiH9b13L._AC_SL1500_.jpg", true, "Husky Liners - Front & Rear Mud Guards | 2009 - 2023 Ram 1500/Ram 1500 Classic, 2010 - 2018 Ram", 60m },
                    { new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"), null, 3.00m, 1, new DateTime(2023, 8, 11, 15, 25, 22, 979, DateTimeKind.Utc).AddTicks(7553), "Universal aerosolized paint with a quick-drying agent formula", "https://www.sentryair.com/blog/wp-content/uploads/2013/04/FH17JUN_579_07_034.jpg", true, "Paint Spray - RED", 5m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("927c618e-4b91-4556-9418-93d3cbed707e"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf48bbdb-213f-4dcc-80b2-9a7c6159a653", "AQAAAAEAACcQAAAAEEkvfjgiASidS7E3TpdL08qp4A5xFduZXjT/4qd4d73fOo/eF2l7imbbgOdEuLJEaA==", "00ae90ee-493c-4851-8c41-6feb1f756998" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47a624cf-246f-4143-afa2-f37e8a6101e0", "AQAAAAEAACcQAAAAEFhpIn9+M/PTrrTG39FLeUZOrPYEdbnayHUDhOrZMCcoxOXP/T9zIuuX6QzNTMdURA==", "3cd40ab8-49c1-4e8a-8176-23fa3b20ec04" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 22, 39, 657, DateTimeKind.Utc).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 22, 39, 657, DateTimeKind.Utc).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 22, 39, 658, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 15, 22, 39, 658, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
