namespace OnlineStore.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Services.Data.StoreServices;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.ViewModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using System;
    using System.ComponentModel;
    using System.Xml.Linq;
    using static DataBaseSeeder;
    public class ItemServiceAndItemCategoryServiceTests
    {

        private DbContextOptions<OnlineStoreDbContext> dbOptions;
        private OnlineStoreDbContext dbContext;

        private IItemService itemService;
        private IItemCategoryService itemCategoryService;

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

            this.itemService = new ItemService(this.dbContext);
            this.itemCategoryService = new ItemCategoryService(this.dbContext);

            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task TopItemAsyncShouldReturnTheFirstItemWithTheMostRecentCreatedTime()
        {
            IEnumerable<IndexViewModel> vm = await this.itemService.TopItemAsync();

            List<IndexViewModel> listVm = new List<IndexViewModel>();

            foreach (var itemx in vm)
            {
                listVm.Add(itemx);
            }

            IndexViewModel singleModel = listVm[0];
            Item? actualItem = await this.dbContext
                .Items
                .FirstOrDefaultAsync(i => i.Id.ToString() == singleModel.Id);

            Item expectedItem = itemTwo;

            Assert.That(expectedItem, Is.EqualTo(actualItem));


        }
        [Test]
        public async Task CategoryExistsShouldReturnTrueIfCategoryExists()
        {
            bool actualResult = await this.itemService.CategoryExists(categoryOne.Id);

            Assert.IsTrue(actualResult);

        }

        [Test]
        public async Task CreateItemMethodShouldCreateAnItemAndAddItToTheDataBaseAndReturnTheNewItemStringId()
        {
            ItemFormModel formModel = new ItemFormModel()
            {
                Name = "NewItem",
                Description = "Description",
                Price = 5m,
                BulkPrice = 2m,
                ImageUrl = "ImageUrl",
                CategoryId = 1,
                IsActive = true,

            };

            string result = await this.itemService.CreateAsync(formModel);
            int expectedCount = 3;
            int actualCount = await this.dbContext.Items.CountAsync();

            Assert.IsNotEmpty(result);
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public async Task EditItemShouldCorrectlyChangeTheItem()
        {
            ItemFormModel formModel = new ItemFormModel()
            {
                Name = "ItemThree",
                Description = "DescriptionTwo",
                Price = 100m,
                BulkPrice = 50m,
                ImageUrl = "imgUrlTwo",
                IsActive = true,
            };

            await this.itemService.EditItemById(itemTwo.Id.ToString(), formModel);

            string expectedName = "ItemThree";
            string actualName = itemTwo.Name;

            Assert.That(expectedName, Is.EqualTo(actualName));
        }
        [Test]
        public async Task GetItemForEditShouldReturnTheCorrectItem()
        {
            ItemFormModel formModel = new ItemFormModel()
            {
                Name = "ItemTwo",
                Description = "DescriptionTwo",
                Price = 100m,
                BulkPrice = 50m,
                ImageUrl = "imgUrlTwo",
                IsActive = true,
            };

            ItemFormModel actualModel = await this.itemService.GetItemForEditByIdAsync(itemTwo.Id.ToString());

            string expectedItemName = formModel.Name;
            string actualItemName = actualModel.Name;

            Assert.That(expectedItemName, Is.EqualTo(actualItemName));
        }

        [Test]
        public async Task ChangeStatusShouldCorrectlyChangeTheIsActiveProperty()
        {
            await this.itemService.ChangeItemStatusAsync(itemOne.Id.ToString(), 1);

            bool status = itemOne.IsActive;

            Assert.IsFalse(status);
        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategoriesInTheDataBase()
        {
            IEnumerable<ItemSelectCategoryFormModel> allCategories = await this.itemCategoryService.AllCategoriesAsync();

            int expectedResult = 2;
            int actualResult = allCategories.Count();

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
        [Test]
        public async Task AllCategoryNamesMethodShouldReturnCollectionWithAllCategoryNames()
        {
            IEnumerable<string> allNames = await this.itemCategoryService.AllCategoryNamesAsync();
            int expectedCount = 2;
            int actualCount = allNames.Count();

            Assert.IsNotNull(allNames);
            Assert.That(expectedCount, Is.EqualTo(actualCount));

        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueIfCategoryExists()
        {
            bool result = await this.itemCategoryService.ExistsById(1);

            Assert.IsTrue(result);
        }
    }
}
