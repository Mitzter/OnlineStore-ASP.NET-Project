namespace OnlineStore.Services.Tests
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Services.Data.StoreServices;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels.Enums;
    using static DataBaseSeeder;


    public class StoreServiceTests
    {
        private DbContextOptions<OnlineStoreDbContext> dbOptions;
        private OnlineStoreDbContext dbContext;

        private IStoreService storeService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<OnlineStoreDbContext>()
               .UseInMemoryDatabase("OnlineStoreInMemory" + Guid.NewGuid().ToString())
               .Options;
        }
        [SetUp]
        public void SetUp()

        {
            this.dbContext = new OnlineStoreDbContext(this.dbOptions, false);

            this.storeService = new StoreService(this.dbContext);

            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task AllAsyncShouldReturnAllItemsInTheDataBase()
        {

            ICollection<Item> items = await this.dbContext.Items.ToListAsync();
            

            AllItemsViewModel viewModelOne = new AllItemsViewModel()
            {
                Id = itemOne.Id.ToString(),
                Name = itemOne.Name,
                Description = itemOne.Description,
                ImageUrl = itemOne.ImageUrl,
                BulkPrice = itemOne.BulkPrice,
                Price = itemOne.Price,
                IsActive = itemOne.IsActive,
            };

            AllItemsViewModel viewModelTwo = new AllItemsViewModel()
            {
                Id = itemTwo.Id.ToString(),
                Name = itemTwo.Name,
                Description = itemTwo.Description,
                ImageUrl = itemTwo.ImageUrl,
                BulkPrice = itemTwo.BulkPrice,
                Price = itemTwo.Price,
                IsActive = itemTwo.IsActive,
            };

            ICollection<string> categories = new HashSet<string>();

            List<ItemCategory> categoriesFromDb = await this.dbContext.ItemCategories.ToListAsync();

            foreach (var category in categoriesFromDb)
            {
                categories.Add(category.Name);
            }

            HashSet<AllItemsViewModel> viewModels = new HashSet<AllItemsViewModel>();
            viewModels.Add(viewModelOne);
            viewModels.Add(viewModelTwo);

            AllItemsQueryModel queryModel = new AllItemsQueryModel()
            {
                Items = viewModels,
                Categories = categories,
            };

            FilteredAndPagedItemsServiceModel serviceModel = await
                this.storeService.AllAsync(queryModel);


            int expectedItemsCount = 2;
            int actualItemsCount = serviceModel.TotalItemsCount;

            Assert.That(expectedItemsCount, Is.EqualTo(actualItemsCount));
            

        }
        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueIfItemExists()
        {
            Item item = itemOne;

            bool result = await this.storeService.ExistsByIdAsync(item.Id.ToString());

            Assert.IsTrue(result);
        }
    }
}
