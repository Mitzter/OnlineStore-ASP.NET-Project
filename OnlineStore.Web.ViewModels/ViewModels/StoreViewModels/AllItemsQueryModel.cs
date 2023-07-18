namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AllItemsQueryModel
    {
        public AllItemsQueryModel()
        {
            CurrentPage = 1;
            ItemsPerPage = 20;

            Categories = new HashSet<string>();
            Items = new HashSet<AllItemsViewModel>();
        }
        public string? Category { get; set; }

        [Display(Name = "Search by keyword")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort by criteria")]
        public ItemSort ItemSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Number of items per page")]
        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AllItemsViewModel> Items { get; set; }
    }
}
