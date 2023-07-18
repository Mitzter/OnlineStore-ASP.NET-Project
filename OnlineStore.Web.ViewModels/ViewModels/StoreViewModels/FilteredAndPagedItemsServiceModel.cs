namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    public class FilteredAndPagedItemsServiceModel
    {
        public FilteredAndPagedItemsServiceModel()
        {
            Items = new HashSet<AllItemsViewModel>();
        }

        public int TotalItemsCount { get; set; }

        public IEnumerable<AllItemsViewModel> Items { get; set; }
    }
}
