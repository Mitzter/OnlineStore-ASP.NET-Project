namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

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

            builder.HasData(this.GenerateReplies());

        }

        private Reply[] GenerateReplies()
        {
            ICollection<Reply> replies = new HashSet<Reply>();

            Reply reply;

            reply = new Reply()
            {
                Id = 1,
                UserId = Guid.Parse("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                Message = "I don't know",
                PostedAtId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            replies.Add(reply);
            reply = new Reply()
            {
                Id = 2,
                UserId = Guid.Parse("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                Message = "How did you find me?",
                PostedAtId = 2,
                CreatedOn = DateTime.UtcNow,
            };
            replies.Add(reply);

            return replies.ToArray();
        }
    }
}
