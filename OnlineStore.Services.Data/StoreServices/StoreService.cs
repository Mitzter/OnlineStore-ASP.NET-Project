namespace OnlineStore.Services.Data.StoreServices
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
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

            try
            {
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
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Item ID is null.");
            }
        }

       

        public async Task<string> CreateOrderAsync(OrderFormModel formModel, string userId, List<CartItem> sessionItems)
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            var orderedItems = sessionItems;
            bool isUserCompanyRegistered = false;

            var bulkBuyer = await this.dbContext
                .BulkBuyers
                .FirstOrDefaultAsync(u => u.UserId.ToString() == userId);
            if (bulkBuyer?.UserId == user!.Id)
            {
                isUserCompanyRegistered = true;
            }

            Order order = new Order()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
                City = formModel.City,
                Address = formModel.Address,
                AdditionalInformation = formModel.AdditionalInformation,
                PhoneNumber = formModel.PhoneNumber,
                PostalCode = formModel.PostalCode,
                UserId = user!.Id,
                User = user,
                OrderTime = DateTime.UtcNow,
                OrderedItems = orderedItems,
                Status = OrderStatus.Pending,
                IsUserCompanyRegistered = isUserCompanyRegistered,
            };
             
            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();

            
            return order.Id.ToString();
        }

        public Task<ShoppingCartViewModel> GetShoppingCartByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
