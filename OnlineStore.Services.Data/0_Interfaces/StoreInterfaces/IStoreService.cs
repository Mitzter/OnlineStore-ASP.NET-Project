namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;

    public interface IStoreService
    {
        Task<FilteredAndPagedItemsServiceModel> AllAsync(AllItemsQueryModel queryModel);
    }
}
