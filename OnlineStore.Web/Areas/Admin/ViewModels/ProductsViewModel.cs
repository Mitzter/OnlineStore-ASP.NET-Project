namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;

    public class ProductsViewModel
    {
        public IEnumerable<AllItemsViewModel> Products { get; set; } = null!;
    }
}
