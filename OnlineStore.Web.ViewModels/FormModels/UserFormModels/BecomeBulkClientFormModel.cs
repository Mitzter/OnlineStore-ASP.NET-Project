namespace OnlineStore.Web.ViewModels.FormModels.UserFormModels
{
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.BulkBuyer;
    public  class BecomeBulkClientFormModel
    {
        [Required]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(VatNumberMaxLength, MinimumLength = VATNumberMinLength)]
        [Display(Name = "VAT Number")]
        public string VATNumber { get; set; } = null!;


        [Required]
        [StringLength(FinancialManagerNameMaxLength, MinimumLength = FinancialManagerNameMinLength)]
        [Display(Name = "Financial Manager")]
        public string FinancialManager { get; set; } = null!;

    }
}
