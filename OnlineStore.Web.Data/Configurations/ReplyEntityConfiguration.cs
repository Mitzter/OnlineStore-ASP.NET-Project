namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.ForumModels;

    public class ReplyEntityConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder
                .Property(r => r.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(r => r.PostedAt)
                .WithMany(p => p.Replies)
                .HasForeignKey(r => r.PostedAtId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
