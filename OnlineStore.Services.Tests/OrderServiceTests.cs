namespace OnlineStore.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.OrderInterfaces;
    using OnlineStore.Services.Data.OrderServices;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Data.Migrations;
    using OnlineStore.Web.Models.StoreModels;
    using OnlineStore.Web.Models.StoreModels.Enums;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.OrderViewModels;
    using System;
    using static DataBaseSeeder;
    public class OrderServiceTests
    {

        private DbContextOptions<OnlineStoreDbContext> dbOptions;
        private OnlineStoreDbContext dbContext;

        private IOrderService orderService;

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

            this.orderService = new OrderService(this.dbContext);

            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task ChangeOrderStatusShouldChangeTheOrderStatus()
        {
            OrderStatus previousStatus = (OrderStatus)0;

            await this.orderService.ChangeOrderStatusAsync(orderOne.Id.ToString(), 2);

            OrderStatus newStatus = orderOne.Status;


            Assert.That(previousStatus, Is.Not.EqualTo(newStatus));
        }

        [Test]
        public async Task GetAllOrdersMethodShouldReturnTheCorrectOrderCount()
        {
            IEnumerable<AllOrdersViewModel> allOrders = await this.orderService.GetAllOrdersAsync();
            int expectedCount = 2;
            int actualCount = allOrders.Count();

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public async Task GetOrderByIdAsyncShouldReturnTheCorrectOrder()
        {
            Order expectedOrder = orderOne;

            Order actualOrder = await this.orderService.GetOrderByIdAsync(orderOne.Id.ToString());

            Assert.That(expectedOrder.Id.ToString(), Is.EqualTo(actualOrder.Id.ToString()));
        }

        [Test]
        public async Task CreateOrderMethodShouldCorrectlyAddANewOrderToTheDataBase()
        {
            int expectedOrderCount = 3;

            List<CartItem> orderedItems = orderedItemsOne;

            OrderFormModel formModel = new OrderFormModel()
            {
                FirstName = "TheFirst",
                LastName = "Order",
                City = "Jakuu",
                Address = "Under the Planet",
                OrderTime = DateTime.UtcNow,
                PhoneNumber = "+0987654321",
                PostalCode = "1005",
                AdditionalInformation = "Secret"
            };

            await this.orderService.CreateOrderAsync(formModel, AppUser.Id.ToString(), orderedItems);


            IEnumerable<AllOrdersViewModel> allOrders = await this.orderService.GetAllOrdersAsync();

            int actualOrderCount = allOrders.Count();

            Assert.That(expectedOrderCount, Is.EqualTo(actualOrderCount));

        }
        
    }
}
