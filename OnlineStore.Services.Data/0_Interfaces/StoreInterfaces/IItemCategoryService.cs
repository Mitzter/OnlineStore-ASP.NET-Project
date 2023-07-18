namespace OnlineStore.Services.Data.Interfaces.StoreInterfaces
{
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;

    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
