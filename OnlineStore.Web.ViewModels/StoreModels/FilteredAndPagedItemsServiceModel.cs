namespace OnlineStore.Web.ViewModels.StoreModels
{
    public class FilteredAndPagedItemsServiceModel
    {
        public FilteredAndPagedItemsServiceModel()
        {
            this.Items = new HashSet<AllItemsViewModel>();
        }

        public int TotalItemsCount { get; set; }

        public IEnumerable<AllItemsViewModel> Items { get; set; }
    }
}
