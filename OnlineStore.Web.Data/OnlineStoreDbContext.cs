namespace OnlineStore.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.StoreModels;
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

        public DbSet<ForumCategory> ForumCategories { get; set; } = null!;

        public DbSet<Post> ForumPosts { get; set; } = null!;

        public DbSet<Reply> ForumReplies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(OnlineStoreDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);


        }
    }
}