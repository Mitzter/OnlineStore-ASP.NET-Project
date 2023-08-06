namespace OnlineStore.Web.Models.StoreModels
{
    using OnlineStore.Web.Models.UserModels;

    public class Order
    {

        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderedItems = new HashSet<Item>();
        }
        public Guid Id { get; set; }

        public Guid UserId { get; set; } 
        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public IEnumerable<Item> OrderedItems { get; set; }


        
    }
}
