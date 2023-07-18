namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.ViewModels.StoreModels;

    public interface IStoreService
    {
        Task<FilteredAndPagedItemsServiceModel> AllAsync(AllItemsQueryModel queryModel);
    }
}
