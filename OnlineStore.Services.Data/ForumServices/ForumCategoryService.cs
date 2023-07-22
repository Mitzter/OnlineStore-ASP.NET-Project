namespace OnlineStore.Services.Data.ForumServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.ForumViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly OnlineStoreDbContext dbContext;

        public ForumCategoryService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                .ForumCategories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsById(int id)
        {
            bool result = await dbContext
                .ForumCategories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<ForumCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<ForumCategoryFormModel> categories = await this.dbContext
                .ForumCategories
                .AsNoTracking()
                .Select(fc => new ForumCategoryFormModel
                {
                    Id = fc.Id,
                    Name = fc.Name,
                })
                .ToArrayAsync();

            return categories;
        }

        
    }
}
