namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.Models.FormModels;

    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
