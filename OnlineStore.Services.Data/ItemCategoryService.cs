namespace OnlineStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.FormModels;
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
            IEnumerable<ItemSelectCategoryFormModel> allCategories = await this.dbContext
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
            IEnumerable<string> allNames = await this.dbContext
                .ItemCategories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsById(int id)
        {
            bool result = await this.dbContext
                .ItemCategories
                .AnyAsync(c =>c.Id == id);

            return result;
        }
    }
}
