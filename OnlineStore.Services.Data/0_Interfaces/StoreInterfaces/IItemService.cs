namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.Models.FormModels;
    using OnlineStore.Web.ViewModels;

    public interface IItemService
    {
        Task<IEnumerable<IndexViewModel>> TopItemAsync();

        Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<string> CreateAsync(ItemFormModel model);

    }
}