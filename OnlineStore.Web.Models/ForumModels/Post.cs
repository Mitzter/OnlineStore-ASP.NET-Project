namespace OnlineStore.Web.Models.ForumModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Post;

    public class Post
    {
        public Post()
        {
            this.Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(Poster))]
        public Guid PosterId { get; set; }

        public virtual ApplicationUser Poster { get; set; } 
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int RepliesCount => Replies.Count;
        [Required]
        public int Views { get; set; }

        public ICollection<Reply> Replies { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual ForumCategory Category { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; } 
    }
}
