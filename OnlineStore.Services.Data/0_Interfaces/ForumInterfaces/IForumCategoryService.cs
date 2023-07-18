namespace OnlineStore.Services.Data._0_Interfaces.ForumInterfaces
{
    using OnlineStore.Web.Models.ForumModels;

    public interface IForumCategoryService
    {
        Task<IEnumerable<ForumCategory>> AllCategoriesAsync();

        Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
