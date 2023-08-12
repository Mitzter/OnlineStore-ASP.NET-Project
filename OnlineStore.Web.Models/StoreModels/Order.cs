namespace OnlineStore.Web.Models.StoreModels
{
    using OnlineStore.Web.Models.StoreModels.Enums;
    using OnlineStore.Web.Models.UserModels;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Order;
    public class Order
    {

        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderedItems = new List<CartItem>();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

       
        public string PostalCode { get; set; }

        public string AdditionalInformation { get; set; } 

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public List<CartItem> OrderedItems { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsUserCompanyRegistered { get; set; }

    }
}
