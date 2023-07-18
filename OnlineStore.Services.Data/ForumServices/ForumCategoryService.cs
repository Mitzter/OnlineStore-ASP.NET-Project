namespace OnlineStore.Services.Data.ForumServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.FormModels;
    using OnlineStore.Web.Models.ForumModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly OnlineStoreDbContext dbContext;

        public ForumCategoryService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<ForumCategory>> AllCategoriesAsync()
        {
            return null;
        }

        public Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
