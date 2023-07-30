namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    public class BuyItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal BulkPrice { get; set; }


    }
}
