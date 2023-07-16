namespace OnlineStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models;
    using OnlineStore.Web.Models.FormModels;
    using OnlineStore.Web.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemService : IItemService
    {


        public readonly OnlineStoreDbContext dbContext;

        public ItemService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        

        public Task<IEnumerable<IndexViewModel>> TopItemAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategories()
        {
            return await this.dbContext
                .ItemCategories
                .Select(c => new ItemSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await this.dbContext
                .ItemCategories
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<string> CreateAsync(ItemFormModel model)
        {
            Item item = new Item()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                BulkPrice =  model.BulkPrice,
                CategoryId = model.CategoryId
            };

            await this.dbContext.Items.AddAsync(item);
            await this.dbContext.SaveChangesAsync();

            return item.Id.ToString();
        }

        
    }
}
