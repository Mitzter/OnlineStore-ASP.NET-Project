namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;

    [Authorize]
    public class ForumController
    {
        private readonly IForumCategoryService categoryService;
        private readonly IForumService forumService;

        public ForumController(IForumCategoryService categoryService, IForumService forumService)
        {
            this.categoryService = categoryService;
            this.forumService = forumService;
        }

        public async Task<IActionResult> ForumMain()
        {
            return null;
        }
    }
}
