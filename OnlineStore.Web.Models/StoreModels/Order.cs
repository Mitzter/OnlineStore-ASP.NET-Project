namespace OnlineStore.Web.Models.StoreModels
{
    using OnlineStore.Web.Models.StoreModels.Enums;
    using OnlineStore.Web.Models.UserModels;

    public class Order
    {

        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderedItems = new List<CartItem>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public string City { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string AdditionalInformation { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public List<CartItem> OrderedItems { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsUserCompanyRegistered { get; set; }

    }
}
