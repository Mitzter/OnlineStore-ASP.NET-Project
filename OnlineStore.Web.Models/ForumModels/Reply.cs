namespace OnlineStore.Web.Models.ForumModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Reply;

    public class Reply
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Message { get; set; } = null!;

        public Guid UserId { get;set; }
        
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public int PostedAtId { get; set; }

        [Required]
        public virtual Post PostedAt { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}