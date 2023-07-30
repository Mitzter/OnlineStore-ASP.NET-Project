namespace OnlineStore.Web.ViewModels.FormModels.UserFormModels
{
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;

    public  class BecomeBulkClientFormModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; } = null!;
        [Required]
        [MinLength(7)]
        [MaxLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "VAT Number")]
        public string VATNumber { get; set; } = null!;


        [Required]
        [Display(Name = "Financial Manager")]
        public string FinancialManager { get; set; } = null!;

    }
}
