namespace OnlineStore.Services.Tests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.UserModels;

    public static class DataBaseSeeder
    {
        public static ApplicationUser AppUser;
        public static ApplicationUser BulkBuyerUser;
        public static BulkBuyer BulkBuyer;

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

            dbContext.Users.Add(AppUser);
            dbContext.Users.Add(BulkBuyerUser);
            dbContext.BulkBuyers.Add(BulkBuyer);

            dbContext.SaveChanges();


        }


    }
}
