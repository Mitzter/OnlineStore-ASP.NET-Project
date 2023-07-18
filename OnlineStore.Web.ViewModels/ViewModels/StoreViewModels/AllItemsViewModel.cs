namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AllItemsViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Image link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Bulk Price")]
        public decimal BulkPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
