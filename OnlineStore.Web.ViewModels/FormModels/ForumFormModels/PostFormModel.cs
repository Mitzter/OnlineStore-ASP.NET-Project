namespace OnlineStore.Web.ViewModels.FormModels.ForumFormModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Contracts;
    using static Common.EntityValidationConstants.Post;

    public class PostFormModel
    {
        public PostFormModel()
        {
            this.Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength)]
        public string Text { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public Guid PosterId { get; set; }

        public ApplicationUser Poster { get; set; } = null!;
        [Required]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<Reply> Replies { get; set; }

        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

    }
}
