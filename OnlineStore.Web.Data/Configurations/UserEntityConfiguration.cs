
namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.UserModels;
    using System;

    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private ApplicationUser[] GenerateCategories()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();
            var hasher= new PasswordHasher<ApplicationUser>();

            
            

            ApplicationUser regularUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                DisplayName = "Tester"
            };

            string regularUserPassword = "tester";
            regularUser.PasswordHash = hasher.HashPassword(regularUser, regularUserPassword);
            regularUser.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(regularUser);

            //This user is to be used to register as a BulkBuyer.
            //The prompt to register as a Bulk Buyer pops up at the shopping cart after exceeding 1000 leva of purchased goods in the user's shopping cart.
            ApplicationUser bulkBuyer = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "bulk@bulk.com",
                NormalizedUserName = "BULK@BULK.COM",
                Email = "bulk@bulk.com",
                NormalizedEmail = "BULK@BULK.COM",
                DisplayName = "BulkClient"
            };

            string bulkBuyerPassword = "bulktest";
            bulkBuyer.PasswordHash = hasher.HashPassword(bulkBuyer, bulkBuyerPassword);
            bulkBuyer.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(bulkBuyer);

            return users.ToArray();
        }
    }
}
