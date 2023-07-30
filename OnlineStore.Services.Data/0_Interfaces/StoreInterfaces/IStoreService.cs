namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;

    public interface IStoreService
    {
        Task<FilteredAndPagedItemsServiceModel> AllAsync(AllItemsQueryModel queryModel);

        Task<ItemDetailsViewModel> GetDetailsByIdAsync(string itemId);

        Task<bool> ExistsByIdAsync(string itemId);

        Task BuyItemAsync(string itemId, string userId, int quantity);
    }
}
