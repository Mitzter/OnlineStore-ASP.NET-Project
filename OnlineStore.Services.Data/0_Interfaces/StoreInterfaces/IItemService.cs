namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.ViewModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;

    public interface IItemService
    {
        Task<IEnumerable<IndexViewModel>> TopItemAsync();

        Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<string> CreateAsync(ItemFormModel model);

        Task EditItemById(string itemId, ItemFormModel formModel);

        Task<ItemFormModel> GetItemForEditByIdAsync(string Id);

        Task ChangeItemStatusAsync(string id, int status);

    }
}