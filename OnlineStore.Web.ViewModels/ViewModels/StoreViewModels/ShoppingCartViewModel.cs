namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;

    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal GrantTotal { get; set; }

        public bool IsUserCompanyRegistered { get; set; }

    }
}
