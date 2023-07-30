namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    using OnlineStore.Web.Models.StoreModels;

    public class ItemDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal BulkPrice { get; set; }

        public virtual ItemCategory Category { get; set; } = null!;
    }
}
