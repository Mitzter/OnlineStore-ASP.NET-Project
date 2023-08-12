namespace OnlineStore.Services.Tests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;

    public static class DataBaseSeeder
    {
        public static ApplicationUser AppUser;
        public static ApplicationUser BulkBuyerUser;
        public static BulkBuyer BulkBuyer;
        public static Item itemOne;
        public static Item itemTwo;
        public static ItemCategory categoryOne;
        public static ItemCategory categoryTwo;
        public static Order orderOne;
        public static Order orderTwo;
        public static CartItem cartItemOne;
        public static CartItem cartItemTwo;
        public static List<CartItem> orderedItemsOne;
        public static List<CartItem> orderedItemsTwo;

        public static void SeedDatabase(OnlineStoreDbContext dbContext)
        {
           

            AppUser = new ApplicationUser()
            {
                Id = new Guid("F1E6CEAE-0595-404B-BD12-51DDAF35655B"),
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                DisplayName = "Tester",
                EmailConfirmed = true,
                PasswordHash = "9bba5c53a0545e0c80184b946153c9f58387e3bd1d4ee35740f29ac2e718b019",
                SecurityStamp = "c157c0dc-812f-46d7-81dc-f86e8269ef05",
                TwoFactorEnabled = false,
                ConcurrencyStamp = "c588ce99-a4da-4b80-81ff-869bfc5516dc"
            };

            BulkBuyerUser = new ApplicationUser()
            {
                Id = new Guid("90CD4C54-0258-4E14-BB5B-EE50B0809BF4"),
                UserName = "Bulk@bulk.com",
                NormalizedUserName = "BULK@BULK.COM",
                Email = "bulk@bulk.com",
                NormalizedEmail = "BULK@BULK.COM",
                DisplayName = "Bulktest",
                EmailConfirmed = true,
                PasswordHash = "0fe0a2a6c59fea688098d5ac69122200f3e6a40058216dc04f6b513611d55757",
                SecurityStamp = "c157c0dc-812f-46d7-81dc-f86e8269ef05",
                TwoFactorEnabled = false,
                ConcurrencyStamp = "189c0074-b1f1-4148-abb5-49aca1375563",
            };

            BulkBuyer = new BulkBuyer()
            {
                Id = new Guid("4de32247-a809-4bf7-a1f3-14e08f9afcb0"),
                User = BulkBuyerUser,
                CompanyName = "Comp Ltd.",
                PhoneNumber = "+35988888888",
                FinancialManager = "Tester Testov",
                VATNumber = "123456789",
            };

            categoryOne = new ItemCategory()
            {
                Id = 1,
                Name = "Spray"
            };

            categoryTwo = new ItemCategory()
            {
                Id = 2,
                Name = "Part"
            };

            itemOne = new Item()
            {
                Id = new Guid("18c3b14a-48bb-4883-86fd-31666fe34636"),
                Name = "ItemOne",
                Description = "DescriptionOne",
                Price = 5m,
                BulkPrice = 3.5m,
                Category = categoryOne,
                ImageUrl = "imgUrl",
                CreatedOn = DateTime.MinValue,
                IsActive = true,
            };

            itemTwo = new Item()
            {
                Id = new Guid("725a27ad-5b11-4f2e-bd56-d11027de85b4"),
                Name = "ItemTwo",
                Description = "DescriptionTwo",
                Price = 100m,
                BulkPrice = 50m,
                Category = categoryTwo,
                ImageUrl = "imgUrlTwo",
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
            };
            cartItemOne = new CartItem(itemOne)
            {
                Id = new Guid("c2410efe-6625-4aea-b4ae-38d71e55e94a"),
                Quantity = 2,
            };
            cartItemTwo = new CartItem(itemTwo)
            {
                Id = new Guid("4b70f93e-c1b6-4050-b9ec-3b43174f7a60"),
            };

            orderedItemsOne = new List<CartItem>();
            orderedItemsOne.Add(cartItemOne);
            orderedItemsTwo = new List<CartItem>();
            orderedItemsTwo.Add(cartItemOne);
            orderedItemsTwo.Add(cartItemTwo);

            orderOne = new Order()
            {
                Id = new Guid("1b354479-00fb-4189-a34a-af2cb8d1e8cd"),
                FirstName = "Test",
                LastName = "Testov",
                PhoneNumber = "+3598883454",
                OrderedItems = orderedItemsOne,
                City = "Sofia",
                Address = "Address Information",
                OrderTime = DateTime.UtcNow,
                IsUserCompanyRegistered = false,
                Status = 0,
                PostalCode = "1000",
                User = AppUser,
                AdditionalInformation = "Nothing",

            };

            orderTwo = new Order()
            {
                Id = new Guid("b4a738bb-2142-4416-bf2c-035c33af1b66"),
                FirstName = "Tset",
                LastName = "Votstet",
                PhoneNumber = "+359232131",
                OrderedItems = orderedItemsTwo,
                City = "TestCity",
                Address = "The Moon",
                OrderTime = DateTime.UtcNow,
                IsUserCompanyRegistered = true,
                Status = 0,
                PostalCode = "0000",
                User = BulkBuyerUser,
                AdditionalInformation = "Something",
            };
            
            dbContext.Users.Add(AppUser);
            dbContext.Users.Add(BulkBuyerUser);
            dbContext.BulkBuyers.Add(BulkBuyer);
            dbContext.ItemCategories.Add(categoryOne);
            dbContext.ItemCategories.Add(categoryTwo);
            dbContext.Items.Add(itemOne);
            dbContext.Items.Add(itemTwo);
            dbContext.Orders.Add(orderOne);
            dbContext.Orders.Add(orderTwo);

            dbContext.SaveChanges();


        }


    }
}
