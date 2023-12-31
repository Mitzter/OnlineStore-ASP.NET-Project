﻿namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.ForumViewModels;
    using static OnlineStore.Web.Infrastructure.GetPrincipalExtension;
    using static OnlineStore.Common.NotificationMessagesConstants;

    [Authorize]
    public class ForumController : Controller
    {
        private readonly IForumCategoryService categoryService;
        private readonly IForumService forumService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ForumController(IForumCategoryService categoryService, IForumService forumService, UserManager<ApplicationUser> _userManager)
        {
            this.categoryService = categoryService;
            this.forumService = forumService;
            this._userManager = _userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> ForumMain()
        {
            IEnumerable<ForumCategoryFormModel> categories = await this.categoryService
                .AllCategoriesAsync();

            
            try
            {
                var latestPosts = await this.forumService.GetLatestForumPostsAsync();


                var viewModel = new ForumMainViewModel
                {
                    Categories = categories,
                    LatestPosts = latestPosts
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            
        }

        [AllowAnonymous]
        public async Task<IActionResult> Category(int categoryId)
        {
            
            try
            {
                ForumCategoryViewModel viewModel = await this.forumService
                .GetSelectedCategoryViewAsync(categoryId.ToString());

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> CreatePost(int categoryId)
        {
            var user = HttpContext.User;
            var currentUser = await _userManager.GetUserAsync(user);

            try
            {
                PostFormModel post = new PostFormModel()
                {
                    PosterId = currentUser.Id,
                    Poster = currentUser,
                    CategoryId = categoryId,
                };

                return View(post);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

           
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostFormModel formModel)
        {
            var userId = this.User.GetId()!.ToString();
            try
            {
                string postId = await this.forumService.CreatePostAsync(formModel, userId);
                return this.RedirectToAction("ForumMain", "Forum");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            

        }

        [HttpGet]
        public async Task<IActionResult> ViewPost(string id)
        {
            try
            {
                PostViewModel viewModel = await forumService
                .ViewPostAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            

        }

        [HttpGet]
        public async Task<IActionResult> CreateReply(int postId)
        {
            var user = this.User.GetId()!;
            var currentUser = await
                this._userManager.Users
                .FirstOrDefaultAsync(u => u.Id == Guid.Parse(user));
            try
            {
                ReplyFormModel reply = new ReplyFormModel()
                {
                    PosterId = currentUser!.Id,
                    User = currentUser,
                    PostedAtId = postId
                };


                return View(reply);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply(ReplyFormModel reply)
        {
            var userId = this.User.GetId()!.ToString();
            try
            {
                string replyId = await this.forumService.CreateReplyAsync(reply, userId);
                return this.RedirectToAction("ViewPost", "Forum", new { id = reply.PostedAtId });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact an administrator!";

            return this.RedirectToAction("ForumMain", "Forum");
        }
    }
}
