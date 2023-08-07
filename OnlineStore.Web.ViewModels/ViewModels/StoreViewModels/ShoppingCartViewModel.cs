namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;

    public class ShoppingCartViewModel
    {
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;

        public List<Item>? Items { get; set; }

        public bool isUserCompanyRegistered { get; set; }


    }
}
