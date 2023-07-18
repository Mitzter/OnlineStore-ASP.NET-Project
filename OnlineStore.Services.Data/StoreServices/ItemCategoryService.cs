namespace OnlineStore.Services.Data.StoreServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemCategoryService : IItemCategoryService
    {
        private readonly OnlineStoreDbContext dbContext;

        public ItemCategoryService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<ItemSelectCategoryFormModel> allCategories = await dbContext
                .ItemCategories
                .AsNoTracking()
                .Select(c => new ItemSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                .ItemCategories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsById(int id)
        {
            bool result = await dbContext
                .ItemCategories
                .AnyAsync(c => c.Id == id);

            return result;
        }
    }
}
