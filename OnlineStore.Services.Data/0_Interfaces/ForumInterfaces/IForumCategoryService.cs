namespace OnlineStore.Services.Data._0_Interfaces.ForumInterfaces
{
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.ForumViewModels;

    public interface IForumCategoryService
    {
        Task<IEnumerable<ForumCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
