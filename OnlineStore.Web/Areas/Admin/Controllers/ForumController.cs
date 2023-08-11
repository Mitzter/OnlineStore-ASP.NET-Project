namespace OnlineStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Web.ViewModels.ViewModels.ForumViewModels;

    public class ForumController : BaseAdminController
    {
        private readonly IForumService forumService;

        public ForumController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        public async Task<IActionResult> AllPosts()
        {
            AllPostsViewModel viewModel = await this.forumService
                .GetAllPostsAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> ChangeStatus(string id, int status)
        {
            await this.forumService.ChangePostStatusAsync(id, status);

            return RedirectToAction("AllPosts", "Forum");
        }
    }
}
