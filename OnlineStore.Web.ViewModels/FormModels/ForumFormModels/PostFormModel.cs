namespace OnlineStore.Web.ViewModels.FormModels.ForumFormModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.ForumModels;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Contracts;

    public class PostFormModel
    {
        public PostFormModel()
        {
            this.Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string PosterId { get; set; } 
        public IdentityUser Poster { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<Reply> Replies { get; set; }

        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

    }
}
