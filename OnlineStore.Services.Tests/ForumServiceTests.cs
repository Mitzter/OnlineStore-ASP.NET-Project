namespace OnlineStore.Services.Tests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Services.Data.ForumServices;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;
    using System.ComponentModel.DataAnnotations;
    using static DataBaseSeeder;

    public class ForumServiceTests
    {

        private DbContextOptions<OnlineStoreDbContext> dbOptions;
        private OnlineStoreDbContext dbContext;

        private IForumService forumService;
        private IForumCategoryService forumCategoryService;

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

            this.forumService = new ForumService(this.dbContext);
            this.forumCategoryService = new ForumCategoryService(this.dbContext);

            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task ChangePostStatusAsyncShouldCorrectlyChangeThePostActiveStatus()
        {
            await this.forumService.ChangePostStatusAsync(postOne.Id.ToString(), 1);
            bool result = postOne.IsActive;

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreatePostAsyncShouldCorrectlyAddPostToDBAndToCorrectUser()
        {
            
            PostFormModel formModel = new PostFormModel()
            {
                Id = 3,
                Title = "SomeTitle",
                Text = "SomeText",
                ImageUrl = "SomeImage",
                Poster = AppUser,
                CreatedOn = DateTime.UtcNow,
                Category = forumCategoryOne,
            };

            await this.forumService.CreatePostAsync(formModel, AppUser.Id.ToString());

            int expectedUserPostCount = 2;
            int actualUserPostCount = AppUser.Posts.Count();

            Assert.That(expectedUserPostCount, Is.EqualTo(actualUserPostCount));

            int expectedForumPostsCountInDb = 3;
            int actualPostCountInDb = this.dbContext.ForumPosts.Count();

            Assert.That(expectedForumPostsCountInDb, Is.EqualTo(actualPostCountInDb));


        }

        [Test]
        public async Task CreateReplyAsyncShouldCorrectlyAddReplyToCorrectPostAndDB()
        {
            ReplyFormModel formModel = new ReplyFormModel()
            {
                Id = 3,
                Message = "SomeMessage",
                User = BulkBuyerUser,
                PostedAtId = postOne.Id,
                PostedAt = postOne,
                CreatedOn = DateTime.UtcNow,
            };

            await this.forumService.CreateReplyAsync(formModel, BulkBuyerUser.Id.ToString());

            int expectedReplyCount = 2;
            int actualReplyCount = postOne.RepliesCount;

            Assert.That(expectedReplyCount, Is.EqualTo(actualReplyCount));

            int expectedReplyCountInDb = 3;
            int actualReplyCountInDb = this.dbContext.ForumReplies.Count();

            Assert.That(expectedReplyCountInDb, Is.EqualTo(actualReplyCountInDb));
        }
        [Test]
        public async Task FindPostByIdShouldReturnTheCorrectPost()
        {
            var expectedPost = postOne;
            var actualPost = await this.forumService.FindPostById(1);

            Assert.That(expectedPost, Is.EqualTo(actualPost));
        }

        [Test]
        public async Task GetPostRepliesShouldReturnThePostReplies()
        {
            IEnumerable<ReplyFormModel> replies = await this.forumService.GetPostRepliesAsync(1.ToString());

            int expectedCount = 1;
            int actualCount = replies.Count();

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueIfCategoryExists()
        {
            bool result = await this.forumCategoryService.ExistsById(1);

            Assert.IsTrue(result);
        }

    }
}
