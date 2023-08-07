namespace OnlineStore.Web.ViewModels.FormModels.StoreFormModels
{
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;

    public class OrderFormModel
    {
        public OrderFormModel() 
        {
            this.OrderedItems = new List<Item>();
        }
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

        public List<Item> OrderedItems { get; set; }
    }
}
