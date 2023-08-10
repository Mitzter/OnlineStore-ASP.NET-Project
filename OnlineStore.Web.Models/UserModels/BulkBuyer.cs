namespace OnlineStore.Web.Models.UserModels
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.BulkBuyer;

    public class BulkBuyer
    {

        public BulkBuyer()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(VatNumberMaxLength)]
        public string VATNumber { get; set; } = null!;

        [Required]
        [MaxLength(CompanyNameMaxLength)]
        public string CompanyName { get; set; } = null!;

        [Required]
        [MaxLength(FinancialManagerNameMaxLength)]
        public string FinancialManager { get; set; } = null!;

        public Guid UserId { get; set; } 

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
