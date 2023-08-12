namespace OnlineStore.Web.ViewModels.FormModels.StoreFormModels
{
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Order;

    public class OrderFormModel
    {
        public OrderFormModel() 
        {
            this.OrderedItems = new List<CartItem>();
        }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        public string PostalCode { get; set; }

        public string? AdditionalInformation { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderTime { get; set; } 

        public List<CartItem> OrderedItems { get; set; }
    }
}
