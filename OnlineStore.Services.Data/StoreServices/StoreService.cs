namespace OnlineStore.Services.Data.StoreServices
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.StoreModels.Enums;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
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
                    BulkPrice = i.BulkPrice,
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
                BulkPrice = item.BulkPrice,
                Category = item.Category
            };
            
            
        }

       

       
        public async Task<FilteredAndPagedItemsServiceModel> AllAdminViewAsync(AllItemsQueryModel queryModel)
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
                .Skip((queryModel.CurrentPage - 1) * queryModel.ItemsPerPage)
                .Take(queryModel.ItemsPerPage)
                .Select(i => new AllItemsViewModel
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price,
                    BulkPrice = i.BulkPrice,
                    IsActive = i.IsActive,

                })
                .ToArrayAsync();

            int totalItems = itemQuery.Count();

            return new FilteredAndPagedItemsServiceModel()
            {
                TotalItemsCount = totalItems,
                Items = allItems
            };
        }
    }
}
