namespace OnlineStore.Web.Models.ForumModels
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; } = null!;

        [Required]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int PostedAtId { get; set; }

        [Required]
        public virtual Post PostedAt { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}