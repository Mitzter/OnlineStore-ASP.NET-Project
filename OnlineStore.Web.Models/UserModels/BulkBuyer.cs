namespace OnlineStore.Web.Models.UserModels
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class BulkBuyer
    {

        public BulkBuyer()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public IdentityUser User { get; set; } = null!;
    }
}
