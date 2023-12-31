namespace OnlineStore.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.UserInterfaces;
    using OnlineStore.Services.Data.UserServices;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.UserFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.UserViewModels;
    using static DataBaseSeeder;

    public class UserServiceTests
    {
        private DbContextOptions<OnlineStoreDbContext> dbOptions;
        private OnlineStoreDbContext dbContext;

        private IUserService userService;

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

            this.userService = new UserService(this.dbContext);

            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
        }
        
        [Test]
        public async Task GetUserNameByIdAsyncShouldReturnTheCorrectUserNameById()
        {
            string existingUserId = AppUser.Id.ToString();
            string expectedResult = "test@test.com";
            string result = await this.userService.GetUserNameByIdAsync(existingUserId);

            //Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task IsUserBulkClientAsyncShouldReturnTrueWhenItExists()
        {
            string existingUserId = BulkBuyerUser.Id.ToString();
            bool result = await this.userService.IsUserBulkClientAsync(existingUserId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task IsUserBulkClientAsyncShouldReturnFalseWhenItDoesntExist()
        {
            string existingUserId = AppUser.Id.ToString();
            bool result = await this.userService.IsUserBulkClientAsync(existingUserId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task IsPhoneNumberTakenAsyncShouldReturnTRUEWhenPhoneNumberIsTakenByADifferentUser()
        {
            string existingPhoneNumber = "+35988888888";
            bool result = await this.userService.IsPhoneNumberTakenAsync(existingPhoneNumber);

            Assert.IsTrue(result);

        }
        [Test]
        public async Task IsPhoneNumberTakenAsyncShouldReturnFALSEWhenPhoneNumberIsTakenByADifferentUser()
        {
            string existingPhoneNumber = "+35988888889";
            bool result = await this.userService.IsPhoneNumberTakenAsync(existingPhoneNumber);

            Assert.IsFalse(result);

        }

        [Test]
        public async Task IsCompanyRegisteredWithSameVatNumberShouldReturnTrueIfVATNumberIsTaken()
        {
            string VatNumber = "123456789";
            bool result = await this.userService.IsCompanyRegisteredWithSameVAT(VatNumber);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task IsCompanyRegisteredWithSameVatNumberShouldReturnFalseIfVATNumberIsTaken()
        {
            string VatNumber = "123456999";
            bool result = await this.userService.IsCompanyRegisteredWithSameVAT(VatNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsCompanyNameTakenShouldReturnTrueIfCompanyNameIsAlreadyTaken()
        {
            string companyName = "Comp Ltd.";
            bool result = await this.userService.IsCompanyNameTakenAsync(companyName);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsCompanyNameTakenShouldReturnFalseIfCompanyNameIsAlreadyTaken()
        {
            string companyName = "New Company";
            bool result = await this.userService.IsCompanyNameTakenAsync(companyName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreateBulkClientMethodShouldAddANewBuilkClientToTheDataBase()
        {
            string userId = AppUser.Id.ToString();

            BecomeBulkClientFormModel formModel = new BecomeBulkClientFormModel()
            {
                CompanyName = "New Company",
                FinancialManager = "Testman Testguy",
                PhoneNumber = "1234567891",
                VATNumber = "987654321",
            };

            await this.userService.CreateBulkClient(userId, formModel);

            var users = this.dbContext.BulkBuyers.ToList();
            BulkBuyer expectedResult = this.dbContext.BulkBuyers.FirstOrDefault(u => u.UserId.ToString() == userId);

            Assert.Contains(expectedResult, users);

        }

        [Test]
        public async Task AllUsersAsyncShouldReturnAllUsersInTheDatabase()
        {
            IEnumerable<UserViewModel> allUsers = await this.userService.AllUsersAsync();

            int expectedUserCount = 2;
            int actualUserCount = allUsers.Count();

            Assert.That(expectedUserCount, Is.EqualTo(actualUserCount));
        }

        [Test]
        public async Task GetUserByIdAsyncShouldReturnTheCorrectUser()
        {
            ApplicationUser expectedUser = AppUser;
            ApplicationUser actualUser = await this.userService.GetUserByIdAsync(AppUser.Id.ToString());

            Assert.That(expectedUser, Is.EqualTo(actualUser));

        }
    }
}