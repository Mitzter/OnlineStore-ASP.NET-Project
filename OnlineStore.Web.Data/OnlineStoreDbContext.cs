namespace OnlineStore.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Web.Models;
    using System.Reflection;

    public class OnlineStoreDbContext : IdentityDbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<ItemCategory> ItemCategories { get; set; } = null!;

        public DbSet<BulkBuyer> bulkBuyers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(OnlineStoreDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);


        }
    }
}