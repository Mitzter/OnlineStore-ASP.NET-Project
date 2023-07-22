namespace OnlineStore.Web.ViewModels.FormModels.ForumFormModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.ForumModels;
    using System.ComponentModel.DataAnnotations;

    public class ReplyFormModel
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
