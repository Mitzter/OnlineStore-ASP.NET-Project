namespace OnlineStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.StoreModels;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateItems());
        }

        private Item[] GenerateItems()
        {
            ICollection<Item> items = new HashSet<Item>();

            Item item;

            item = new Item()
            {
                Id = Guid.Parse("8f1bcccd-5a33-460c-ac2b-11b79f12ba37"),
                Name = "DL-60 Multifunctional Spray",
                Description = "General purpose spray for loosening screws and bolts covered in rust and prevents rust from building up. Can also function as a lubricant for moving parts",
                ImageUrl = "https://tpetrov.com/thumbs/3/spr-dl60-4.jpg",
                Price = 5m,
                BulkPrice = 3.50m,
                CreatedOn = DateTime.UtcNow,
                CategoryId = 1,
                IsActive = true,
            };

            items.Add(item);

            item = new Item()
            {
                Id = Guid.Parse("75efbb9b-0c10-4527-9479-8f31c2502d52"),
                Name = "DL-600 Universal Lithium Grease",
                Description = "Easy to use lubricant spray for moving parts and machinery. The lithium grease in an aerosolized form prevents you from having to get your hands dirty with using conventional grease",
                ImageUrl = "https://markita.net/sites/default/files/styles/markita_products_4_colons_157_x_130_/public/2021-02/%D0%93%D0%A0%D0%95%D0%A1%20%D0%9B%D0%98%D0%A2%D0%98%D0%95%D0%92%D0%90%20%D0%A1%D0%9F%D0%A0%D0%95%D0%99%20400%D0%BC%D0%BB%20DL600%20%D0%A3%D0%9D%D0%98%D0%92%D0%95%D0%A0%D0%A1%D0%90%D0%9B%D0%9D%D0%90.JPG",
                Price = 8m,
                BulkPrice = 4.50m,
                CreatedOn = DateTime.UtcNow,
                CategoryId = 1,
                IsActive = true,
            };

            items.Add(item);

            item = new Item()
            {
                Id = Guid.Parse("fb0dd29f-3432-401d-8af9-b2d699f3a54c"),
                Name = "Paint Spray - RED",
                Description = "Universal aerosolized paint with a quick-drying agent formula",
                ImageUrl = "https://www.sentryair.com/blog/wp-content/uploads/2013/04/FH17JUN_579_07_034.jpg",
                Price = 5m,
                BulkPrice = 3.00m,
                CreatedOn = DateTime.UtcNow,
                CategoryId = 1,
                IsActive = true,
            };

            items.Add(item);

            item = new Item()
            {
                Id = Guid.Parse("6a0c2eca-1915-4853-82c3-b921edb5383d"),
                Name = "Black and Red Alluminum Sports rims",
                Description = "Stylish sports rims made of the highest quality Polish Alluminum. Extremely durable and won't bend as easily as regular alluminum 'summer' rims. Country of manufacture: Poland",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUyBauHMYH3D89DHPOUPsGeTZ8cNlwt2fi740hn5nT9B4g9pVc3Xo3KdczDUGknfokPEE&usqp=CAU",
                Price = 150m,
                BulkPrice = 75m,
                CreatedOn = DateTime.UtcNow,
                CategoryId = 5,
                IsActive = true,
            };

            items.Add(item);

            item = new Item()
            {
                Id = Guid.Parse("b2eb8a5c-5f08-46db-8462-eb63f616150d"),
                Name = "Husky Liners - Front & Rear Mud Guards | 2009 - 2023 Ram 1500/Ram 1500 Classic, 2010 - 2018 Ram",
                Description = "FITMENT — 2009-2023 Ram 1500/Ram 1500 Classic, 2010-2018 Ram 2500/3500 w/Single Rear Wheels & w/out OEM Fender Flares\r\nFITS LIKE FACTORY — Built specifically for your make and model providing that perfectly tailored fit. Available in full-tread coverage for single- or dually-factory tire width.\r\nIMPACT RESISTANT CONSTRUCTION — Built to stand up to a lifetime of abuse thanks to its nail-tough, impact-resistant thermoplastic construction. With proprietary Husky Shield Film for an invisible layer of protection.\r\nEASY TO INSTALL — A few screws and a few minutes are all it takes to mount Mud Guards for a perfect match to your vehicle every time.\r\nUPGRADED LOOKS — An instant improvement for your vehicle’s appearance with sleek style that looks like it came from the factory, with some added custom flair.\r\nLIFETIME GUARANTEE — Proudly made in the USA. When we say it’s “guaranteed for life” that is exactly what we mean. No hassles, no guff. If you have a problem with this or any Husky product, we’ll replace it.",
                ImageUrl = "https://m.media-amazon.com/images/I/61pbiH9b13L._AC_SL1500_.jpg",
                Price = 60m,
                BulkPrice = 35m,
                CreatedOn = DateTime.UtcNow,
                CategoryId = 4,
                IsActive = true,
            };

            items.Add(item);

            item = new Item()
            {
                Id = Guid.Parse("927c618e-4b91-4556-9418-93d3cbed707e"),
                Name = "Jack Boss Floor Jack 3 Ton Capacity Fast Lift Service Jack Steel Heavy Duty Hydraulic Car Jack",
                Description = "Specifications:Hydraulic trolley jack features a 3 ton (6,600 lbs) capacity with lifting height from 5.1\" to 18.3\".Floor Jack saddle Diameter: 4 inch.With quick lift function.Its the best tool for car repairing and auto emergency treatment in garage,shop",
                ImageUrl = "https://m.media-amazon.com/images/I/71dhyZ89JkL.jpg",
                Price = 200m,
                BulkPrice = 100m,
                CreatedOn = DateTime.UtcNow,
                CategoryId = 6,
                IsActive = true,
            };

            items.Add(item);
            return items.ToArray();
        }

        
            
    }
}