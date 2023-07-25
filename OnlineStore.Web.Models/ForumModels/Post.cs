namespace OnlineStore.Web.Models.ForumModels
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public Post()
        {
            this.Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string PosterId { get; set; }
        public IdentityUser Poster { get; set; } 
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int RepliesCount { get; set; }
        [Required]
        public int Views { get; set; }

        public IEnumerable<Reply> Replies { get; set; }
        
        public int CategoryId { get; set; }

        [Required]
        public virtual ForumCategory Category { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; } 
    }
}
