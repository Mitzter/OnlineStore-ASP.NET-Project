namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.StoreModels;

    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.HasKey(o => o.Id);

            //builder.Property(p => p.OrderTime)
            //       .HasDefaultValueSql("GETDATE()");

            //builder.HasOne(o => o.User)
            //       .WithMany(u => u.Orders) 
            //       .OnDelete(DeleteBehavior.Restrict); 
            
            //builder.HasMany(o => o.OrderedItems)
            //       .WithOne()
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
