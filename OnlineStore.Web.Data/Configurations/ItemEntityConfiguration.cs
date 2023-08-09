namespace OnlineStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.StoreModels;

    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(i => i.Order) 
            //    .WithMany(o => o.OrderedItems)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}