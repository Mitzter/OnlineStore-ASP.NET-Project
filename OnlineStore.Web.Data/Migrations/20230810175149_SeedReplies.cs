using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class SeedReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("05164368-915d-41b5-83c2-f97064fdb539"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("664dc48b-849d-4f1b-9437-99a5fb4d9360"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("68b08732-e091-4fc9-b623-9ca6e99d9707"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c9804edd-2f64-4e5e-83d6-ceddcd7aecb1"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cbaae768-7111-4709-81fb-e9516800cc3d"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cdaf00da-f579-40d6-9d16-f037f03bb8f0"));

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

            migrationBuilder.InsertData(
                table: "ForumReplies",
                columns: new[] { "Id", "CreatedOn", "Message", "PostedAtId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 10, 17, 51, 48, 618, DateTimeKind.Utc).AddTicks(1296), "I don't know", 1, new Guid("90cd4c54-0258-4e14-bb5b-ee50b0809bf4") },
                    { 2, new DateTime(2023, 8, 10, 17, 51, 48, 618, DateTimeKind.Utc).AddTicks(1311), "How did you find me?", 2, new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b") }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ApplicationUserId", "BulkPrice", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6a0c2eca-1915-4853-82c3-b921edb5383d"), null, 75m, 5, new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(794), "Stylish sports rims made of the highest quality Polish Alluminum. Extremely durable and won't bend as easily as regular alluminum 'summer' rims. Country of manufacture: Poland", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUyBauHMYH3D89DHPOUPsGeTZ8cNlwt2fi740hn5nT9B4g9pVc3Xo3KdczDUGknfokPEE&usqp=CAU", true, "Black and Red Alluminum Sports rims", 150m },
                    { new Guid("75efbb9b-0c10-4527-9479-8f31c2502d52"), null, 4.50m, 1, new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(777), "Easy to use lubricant spray for moving parts and machinery. The lithium grease in an aerosolized form prevents you from having to get your hands dirty with using conventional grease", "https://markita.net/sites/default/files/styles/markita_products_4_colons_157_x_130_/public/2021-02/%D0%93%D0%A0%D0%95%D0%A1%20%D0%9B%D0%98%D0%A2%D0%98%D0%95%D0%92%D0%90%20%D0%A1%D0%9F%D0%A0%D0%95%D0%99%20400%D0%BC%D0%BB%20DL600%20%D0%A3%D0%9D%D0%98%D0%92%D0%95%D0%A0%D0%A1%D0%90%D0%9B%D0%9D%D0%90.JPG", true, "DL-600 Universal Lithium Grease", 8m },
                    { new Guid("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"), null, 3.50m, 1, new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(728), "General purpose spray for loosening screws and bolts covered in rust and prevents rust from building up. Can also function as a lubricant for moving parts", "https://tpetrov.com/thumbs/3/spr-dl60-4.jpg", true, "DL-60 Multifunctional Spray", 5m },
                    { new Guid("927c618e-4b91-4556-9418-93d3cbed707e"), null, 100m, 6, new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(836), "Specifications:Hydraulic trolley jack features a 3 ton (6,600 lbs) capacity with lifting height from 5.1\" to 18.3\".Floor Jack saddle Diameter: 4 inch.With quick lift function.Its the best tool for car repairing and auto emergency treatment in garage,shop", "https://m.media-amazon.com/images/I/71dhyZ89JkL.jpg", true, "Jack Boss Floor Jack 3 Ton Capacity Fast Lift Service Jack Steel Heavy Duty Hydraulic Car Jack", 200m },
                    { new Guid("b2eb8a5c-5f08-46db-8462-eb63f616150d"), null, 35m, 4, new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(809), "FITMENT — 2009-2023 Ram 1500/Ram 1500 Classic, 2010-2018 Ram 2500/3500 w/Single Rear Wheels & w/out OEM Fender Flares\r\nFITS LIKE FACTORY — Built specifically for your make and model providing that perfectly tailored fit. Available in full-tread coverage for single- or dually-factory tire width.\r\nIMPACT RESISTANT CONSTRUCTION — Built to stand up to a lifetime of abuse thanks to its nail-tough, impact-resistant thermoplastic construction. With proprietary Husky Shield Film for an invisible layer of protection.\r\nEASY TO INSTALL — A few screws and a few minutes are all it takes to mount Mud Guards for a perfect match to your vehicle every time.\r\nUPGRADED LOOKS — An instant improvement for your vehicle’s appearance with sleek style that looks like it came from the factory, with some added custom flair.\r\nLIFETIME GUARANTEE — Proudly made in the USA. When we say it’s “guaranteed for life” that is exactly what we mean. No hassles, no guff. If you have a problem with this or any Husky product, we’ll replace it.", "https://m.media-amazon.com/images/I/61pbiH9b13L._AC_SL1500_.jpg", true, "Husky Liners - Front & Rear Mud Guards | 2009 - 2023 Ram 1500/Ram 1500 Classic, 2010 - 2018 Ram", 60m },
                    { new Guid("fb0dd29f-3432-401d-8af9-b2d699f3a54c"), null, 3.00m, 1, new DateTime(2023, 8, 10, 17, 51, 48, 617, DateTimeKind.Utc).AddTicks(787), "Universal aerosolized paint with a quick-drying agent formula", "https://www.sentryair.com/blog/wp-content/uploads/2013/04/FH17JUN_579_07_034.jpg", true, "Paint Spray - RED", 5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ForumReplies",
                keyColumn: "Id",
                keyValue: 2);

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
                values: new object[] { "7bc37476-af37-46fb-9f5c-8de74b0a3b79", "AQAAAAEAACcQAAAAEIvJOZB7nWOMfWRbGTbCx8JTg011ClPOiP1szteh/g4G+O5mywqO4uyBmMkQvxwzoA==", "6da5db89-63da-4453-8e1c-11377dafbf51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6490c114-e131-41fc-a4d6-1b2c5198ae54", "AQAAAAEAACcQAAAAEIznFNk9UnLuatDAdDyBsvwUSUc0Eqkq2GS+hMwCxuSRy5nDEZs1FCaIHbQlHO9NPg==", "cb0c8381-5a21-44c9-89c4-1ebc33a7f268" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 27, 59, 997, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 10, 17, 27, 59, 997, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ApplicationUserId", "BulkPrice", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("05164368-915d-41b5-83c2-f97064fdb539"), null, 3.50m, 1, new DateTime(2023, 8, 10, 17, 27, 59, 996, DateTimeKind.Utc).AddTicks(6975), "General purpose spray for loosening screws and bolts covered in rust and prevents rust from building up. Can also function as a lubricant for moving parts", "https://tpetrov.com/thumbs/3/spr-dl60-4.jpg", true, "DL-60 Multifunctional Spray", 5m },
                    { new Guid("664dc48b-849d-4f1b-9437-99a5fb4d9360"), null, 75m, 5, new DateTime(2023, 8, 10, 17, 27, 59, 996, DateTimeKind.Utc).AddTicks(7031), "Stylish sports rims made of the highest quality Polish Alluminum. Extremely durable and won't bend as easily as regular alluminum 'summer' rims. Country of manufacture: Poland", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUyBauHMYH3D89DHPOUPsGeTZ8cNlwt2fi740hn5nT9B4g9pVc3Xo3KdczDUGknfokPEE&usqp=CAU", true, "Black and Red Alluminum Sports rims", 150m },
                    { new Guid("68b08732-e091-4fc9-b623-9ca6e99d9707"), null, 3.00m, 1, new DateTime(2023, 8, 10, 17, 27, 59, 996, DateTimeKind.Utc).AddTicks(7027), "Universal aerosolized paint with a quick-drying agent formula", "https://www.sentryair.com/blog/wp-content/uploads/2013/04/FH17JUN_579_07_034.jpg", true, "Paint Spray - RED", 5m },
                    { new Guid("c9804edd-2f64-4e5e-83d6-ceddcd7aecb1"), null, 4.50m, 1, new DateTime(2023, 8, 10, 17, 27, 59, 996, DateTimeKind.Utc).AddTicks(7022), "Easy to use lubricant spray for moving parts and machinery. The lithium grease in an aerosolized form prevents you from having to get your hands dirty with using conventional grease", "https://markita.net/sites/default/files/styles/markita_products_4_colons_157_x_130_/public/2021-02/%D0%93%D0%A0%D0%95%D0%A1%20%D0%9B%D0%98%D0%A2%D0%98%D0%95%D0%92%D0%90%20%D0%A1%D0%9F%D0%A0%D0%95%D0%99%20400%D0%BC%D0%BB%20DL600%20%D0%A3%D0%9D%D0%98%D0%92%D0%95%D0%A0%D0%A1%D0%90%D0%9B%D0%9D%D0%90.JPG", true, "DL-600 Universal Lithium Grease", 8m },
                    { new Guid("cbaae768-7111-4709-81fb-e9516800cc3d"), null, 35m, 4, new DateTime(2023, 8, 10, 17, 27, 59, 996, DateTimeKind.Utc).AddTicks(7042), "FITMENT — 2009-2023 Ram 1500/Ram 1500 Classic, 2010-2018 Ram 2500/3500 w/Single Rear Wheels & w/out OEM Fender Flares\r\nFITS LIKE FACTORY — Built specifically for your make and model providing that perfectly tailored fit. Available in full-tread coverage for single- or dually-factory tire width.\r\nIMPACT RESISTANT CONSTRUCTION — Built to stand up to a lifetime of abuse thanks to its nail-tough, impact-resistant thermoplastic construction. With proprietary Husky Shield Film for an invisible layer of protection.\r\nEASY TO INSTALL — A few screws and a few minutes are all it takes to mount Mud Guards for a perfect match to your vehicle every time.\r\nUPGRADED LOOKS — An instant improvement for your vehicle’s appearance with sleek style that looks like it came from the factory, with some added custom flair.\r\nLIFETIME GUARANTEE — Proudly made in the USA. When we say it’s “guaranteed for life” that is exactly what we mean. No hassles, no guff. If you have a problem with this or any Husky product, we’ll replace it.", "https://m.media-amazon.com/images/I/61pbiH9b13L._AC_SL1500_.jpg", true, "Husky Liners - Front & Rear Mud Guards | 2009 - 2023 Ram 1500/Ram 1500 Classic, 2010 - 2018 Ram", 60m },
                    { new Guid("cdaf00da-f579-40d6-9d16-f037f03bb8f0"), null, 100m, 6, new DateTime(2023, 8, 10, 17, 27, 59, 996, DateTimeKind.Utc).AddTicks(7048), "Specifications:Hydraulic trolley jack features a 3 ton (6,600 lbs) capacity with lifting height from 5.1\" to 18.3\".Floor Jack saddle Diameter: 4 inch.With quick lift function.Its the best tool for car repairing and auto emergency treatment in garage,shop", "https://m.media-amazon.com/images/I/71dhyZ89JkL.jpg", true, "Jack Boss Floor Jack 3 Ton Capacity Fast Lift Service Jack Steel Heavy Duty Hydraulic Car Jack", 200m }
                });
        }
    }
}
