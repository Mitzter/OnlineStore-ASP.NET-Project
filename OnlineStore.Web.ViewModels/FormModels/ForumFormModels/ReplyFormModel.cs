﻿namespace OnlineStore.Web.ViewModels.FormModels.ForumFormModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Reply;

    public class ReplyFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MessageMaxLength, MinimumLength = MessageMinLength)]
        public string Message { get; set; } = null!;

        public Guid PosterId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public int PostedAtId { get; set; }

        [Required]
        public virtual Post PostedAt { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
