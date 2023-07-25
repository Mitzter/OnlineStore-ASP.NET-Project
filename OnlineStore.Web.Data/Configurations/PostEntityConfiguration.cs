namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.ForumModels;

    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
