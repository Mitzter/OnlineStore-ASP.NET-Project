namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;

    public interface IStoreService
    {
        Task<FilteredAndPagedItemsServiceModel> AllAsync(AllItemsQueryModel queryModel);

        Task<FilteredAndPagedItemsServiceModel> AllAdminViewAsync(AllItemsQueryModel queryModel);

        Task<ItemDetailsViewModel> GetDetailsByIdAsync(string itemId);

        Task<bool> ExistsByIdAsync(string itemId);

        Task<string> CreateOrderAsync(OrderFormModel formModel, string userId, List<CartItem> sessionItems);

        

    }
}
