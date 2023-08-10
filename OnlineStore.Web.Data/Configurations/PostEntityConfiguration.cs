namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;
    using System;
    using System.ComponentModel.DataAnnotations;

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
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(this.GeneratePosts());

        }

        private Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post post;

            post = new Post()
            {
                Id = 1,
                Title = "Help",
                Text = "How do I use this website? I'm new I just bought a computer for the first time.",
                PosterId = Guid.Parse("f1e6ceae-0595-404b-bd12-51ddaf35655b"),
                CreatedOn = DateTime.UtcNow,
                CategoryId = 3,
                IsActive = true,
            };

            posts.Add(post);

            post = new Post()
            {
                Id = 2,
                Title = "Hello",
                Text = "We've Been Trying To Reach You About Your Car's Extended Warranty",
                PosterId = Guid.Parse("90cd4c54-0258-4e14-bb5b-ee50b0809bf4"),
                CreatedOn = DateTime.UtcNow,
                CategoryId = 1,
                IsActive = true,
            };

            posts.Add(post);

            return posts.ToArray();
            //    public int Id { get; set; }

            //[Required]
            //[MaxLength(TitleMaxLength)]
            //public string Title { get; set; } = null!;

            //[Required]
            //[MaxLength(TextMaxLength)]
            //public string Text { get; set; } = null!;

            //[MaxLength(ImageUrlMaxLength)]
            //public string? ImageUrl { get; set; }
            //public Guid PosterId { get; set; }

            //public virtual ApplicationUser Poster { get; set; }
            //[Required]
            //public DateTime CreatedOn { get; set; }
            //[Required]
            //public int RepliesCount => Replies.Count;
            //[Required]
            //public int Views { get; set; }

            //public ICollection<Reply> Replies { get; set; }

            //public int CategoryId { get; set; }

            //[Required]
            //public virtual ForumCategory Category { get; set; } = null!;
            //[Required]
            //public bool IsActive { get; set; }
        }
    }
}
