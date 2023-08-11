namespace OnlineStore.Services.Data.StoreServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.ViewModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemService : IItemService
    {


        public readonly OnlineStoreDbContext dbContext;

        public ItemService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<IEnumerable<IndexViewModel>> TopItemAsync()
        {

            ICollection<Post> posts = await this.dbContext
                .ForumPosts
                .OrderByDescending(post => post.CreatedOn)
                .Take(8)
                .ToListAsync();

            IEnumerable<IndexViewModel> topItems = await dbContext
                .Items
                .Where(i => i.IsActive == true)
                .OrderByDescending(i => i.CreatedOn)
                .Take(10)
                .Select(i => new IndexViewModel()
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    ImageUrl = i.ImageUrl,
                })
                .ToArrayAsync();

            return topItems;
        }

        public async Task<IEnumerable<ItemSelectCategoryFormModel>> AllCategories()
        {
            return await dbContext
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
            return await dbContext
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
                BulkPrice = model.BulkPrice,
                CategoryId = model.CategoryId,
                IsActive = true,
            };

            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return item.Id.ToString();
        }

        public async Task EditItemById(string itemId, ItemFormModel formModel)
        {
            Item item = await this.dbContext
                .Items
                .Include(i => i.Category)
                .FirstAsync(i => i.Id.ToString() == itemId);

            ItemCategory category = await this.dbContext
                .ItemCategories
                .FirstOrDefaultAsync(ic => ic.Id == formModel.CategoryId);
            
            item.Name = formModel.Name;
            item.Description = formModel.Description;
            item.CategoryId = formModel.CategoryId;
            item.Category = category;
            item.BulkPrice = formModel.BulkPrice;
            item.Price = formModel.Price;
            item.IsActive = formModel.IsActive;
            item.ImageUrl = formModel.ImageUrl;



            await this.dbContext.SaveChangesAsync();

        }

        public async Task<ItemFormModel> GetItemForEditByIdAsync(string id)
        {
            Item? item = await this.dbContext
                .Items
                .Include(i => i.Category)
                .FirstOrDefaultAsync(i => i.Id.ToString() == id);

            

            return new ItemFormModel()
            {
                Name = item.Name,
                Description = item.Description,
                CategoryId = item.CategoryId,
                BulkPrice = item.BulkPrice,
                Price = item.Price,
                IsActive = item.IsActive,
                ImageUrl = item.ImageUrl,

            };
        }

        public async Task ChangeItemStatusAsync(string id, int status)
        {
            Item? item = await this.dbContext
                .Items
                .FirstOrDefaultAsync(i => i.Id.ToString() == id);

            bool changeStatus = true;
            if (status != 0)
            {
                changeStatus = false;
            }

            item.IsActive = changeStatus;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
