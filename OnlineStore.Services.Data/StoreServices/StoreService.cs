namespace OnlineStore.Services.Data.StoreServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels.Enums;
    using System.Threading.Tasks;

    public class StoreService : IStoreService
    {
        private readonly OnlineStoreDbContext dbContext;

        public StoreService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FilteredAndPagedItemsServiceModel> AllAsync(AllItemsQueryModel queryModel)
        {
            IQueryable<Item> itemQuery = dbContext
                .Items
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                itemQuery = itemQuery
                    .Where(i => i.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                itemQuery = itemQuery
                    .Where(i => EF.Functions.Like(i.Name, wildCard));

            }

            itemQuery = queryModel.ItemSorting switch
            {
                ItemSort.Newest => itemQuery
                .OrderByDescending(i => i.CreatedOn),
                ItemSort.Oldest => itemQuery
                .OrderBy(i => i.CreatedOn),
                ItemSort.PriceAscending => itemQuery
                .OrderBy(i => i.Price),
                ItemSort.PriceDescending => itemQuery
                .OrderByDescending(i => i.Price),
                ItemSort.Category => itemQuery
                .OrderBy(i => i.Category),
            };

            IEnumerable<AllItemsViewModel> allItems = await itemQuery
                .Where(i => i.IsActive == true)
                .Skip((queryModel.CurrentPage - 1) * queryModel.ItemsPerPage)
                .Take(queryModel.ItemsPerPage)
                .Select(i => new AllItemsViewModel
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price,
                    BulkPrice = i.Price,
                    IsActive = true,
                })
                .ToArrayAsync();

            int totalItems = itemQuery.Count();

            return new FilteredAndPagedItemsServiceModel()
            {
                TotalItemsCount = totalItems,
                Items = allItems
            };
        }

        public async Task BuyItemAsync(string itemId, string userId, int quantity)
        {
            ApplicationUser user = await this.dbContext
                .Users
                .Include(u => u.BoughtItems)
                .FirstAsync(i => i.Id.ToString() == userId);

            Item item = await this.dbContext
                .Items
                .FirstAsync(i => i.Id.ToString() == itemId);

            item.QuantityBought += quantity;
            user.BoughtItems.Add(item);
            await this.dbContext.SaveChangesAsync();
        }
        
        public async Task<bool> ExistsByIdAsync(string itemId)
        {
            bool result = await this.dbContext
                .Items
                .Where(i => i.IsActive)
                .AnyAsync(i => i.Id.ToString() == itemId);

            return result;
        }

        public async Task<ItemDetailsViewModel> GetDetailsByIdAsync(string itemId)
        {
            Item item = await this.dbContext
                .Items
                .Include(i => i.Category)
                .Where(i => i.IsActive)
                .FirstAsync(i => i.Id.ToString() == itemId);

            return new ItemDetailsViewModel()
            {
                Id = item.Id.ToString(),
                Name = item.Name,
                Description = item.Description,
                ImageUrl = item.ImageUrl,
                Price = item.Price,
                BulkPrice = item.Price,
                Category = item.Category
            };
        }
    }
}
