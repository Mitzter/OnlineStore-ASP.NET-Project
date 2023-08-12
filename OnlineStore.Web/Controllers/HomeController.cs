namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.Models;
    using OnlineStore.Web.ViewModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using System.Diagnostics;

    using static Common.GeneralApplicationConstants;


    public class HomeController : Controller
    {
        private readonly IItemService itemService;
        private readonly IItemCategoryService itemCategoryService;
        private readonly IForumService forumService;

        public HomeController(IItemService itemService, IItemCategoryService itemCategoryService, IForumService forumService)
        {
            this.itemService = itemService;
            this.itemCategoryService = itemCategoryService;
            this.forumService = forumService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            IEnumerable<IndexViewModel> viewModel =
                await this.itemService.TopItemAsync();

            return View(viewModel);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            return View();
        }

        
    }
}