namespace OnlineStore.Services.Data.Interfaces
{
    using OnlineStore.Web.ViewModels.StoreModels;

    public interface IStoreService
    {
        Task<FilteredAndPagedItemsServiceModel> AllAsync(AllItemsQueryModel queryModel);
    }
}
