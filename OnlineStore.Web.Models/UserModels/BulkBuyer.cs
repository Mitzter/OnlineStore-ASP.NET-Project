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
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string VATNumber { get; set; } = null!;

        

        [Required]
        public string CompanyName { get; set; } = null!;

        [Required]
        public string FinancialManager { get; set; } = null!;
        public Guid UserId { get; set; } 

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
