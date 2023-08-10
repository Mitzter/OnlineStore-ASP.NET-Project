
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
            builder.HasData(this.GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();
            var hasher= new PasswordHasher<ApplicationUser>();

            
            

            ApplicationUser regularUser = new ApplicationUser()
            {
                Id = Guid.Parse("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                DisplayName = "Tester"
            };
            regularUser.EmailConfirmed = true;
            string regularUserPassword = "tester";
            regularUser.PasswordHash = hasher.HashPassword(regularUser, regularUserPassword);
            regularUser.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(regularUser);

            //This user is to be used to register as a BulkBuyer.
            //The prompt to register as a Bulk Buyer pops up at the shopping cart after exceeding 1000 leva of purchased goods in the user's shopping cart.

            ApplicationUser bulkBuyer = new ApplicationUser()
            {
                Id = Guid.Parse("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                UserName = "bulk@bulk.com",
                NormalizedUserName = "BULK@BULK.COM",
                Email = "bulk@bulk.com",
                NormalizedEmail = "BULK@BULK.COM",
                DisplayName = "BulkClient"
            };
            bulkBuyer.EmailConfirmed = true;
            string bulkBuyerPassword = "bulktest";
            bulkBuyer.PasswordHash = hasher.HashPassword(bulkBuyer, bulkBuyerPassword);
            bulkBuyer.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(bulkBuyer);

            return users.ToArray();
        }
    }
}
