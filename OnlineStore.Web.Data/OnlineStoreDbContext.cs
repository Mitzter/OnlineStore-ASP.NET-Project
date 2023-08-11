namespace OnlineStore.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Data.Configurations;
    using OnlineStore.Web.Data.Configurations;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;
    using System.Reflection;

    public class OnlineStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options, bool seedDb = true) 
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<ItemCategory> ItemCategories { get; set; } = null!;

        public DbSet<BulkBuyer> BulkBuyers { get; set; } = null!;

        public DbSet<ForumCategory> ForumCategories { get; set; } = null!;

        public DbSet<Post> ForumPosts { get; set; } = null!;

        public DbSet<Reply> ForumReplies { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Assembly configAssembly = Assembly.GetAssembly(typeof(OnlineStoreDbContext)) ??
            //                          Assembly.GetExecutingAssembly();

            //builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.ApplyConfiguration(new OrderEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new UserEntityConfiguration());
                builder.ApplyConfiguration(new ItemEntityConfiguration());
                builder.ApplyConfiguration(new PostEntityConfiguration());
                builder.ApplyConfiguration(new ReplyEntityConfiguration());
                builder.ApplyConfiguration(new CategoryEntityConfiguration());
                builder.ApplyConfiguration(new ForumEntityConfiguration());
            }

            base.OnModelCreating(builder);


        }
 
    }
}