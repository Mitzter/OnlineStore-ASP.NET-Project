﻿namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data.Interfaces;
    using OnlineStore.Web.Models;
    using OnlineStore.Web.Models.FormModels;
    using System.Diagnostics;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IItemService itemService;
        private readonly IItemCategoryService itemCategoryService;

        public HomeController(IItemService itemService, IItemCategoryService itemCategoryService)
        {
            this.itemService = itemService;
            this.itemCategoryService = itemCategoryService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ItemFormModel formModel = new ItemFormModel()
            {
                Categories = await this.itemCategoryService.AllCategoriesAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ItemFormModel model)
        {
            bool categoryExists = await this.itemCategoryService
                .ExistsById(model.CategoryId);

            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId),
                    "Selected category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.itemCategoryService
                    .AllCategoriesAsync();

                return this.View(model);
            }

            try
            {
                string itemId = await this.itemService.CreateAsync(model);

                return this.RedirectToAction("All", "Home");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured when trying to add new product. Please try again later or contact an administrator!");
                model.Categories = await this.itemCategoryService
                    .AllCategoriesAsync();

                return this.View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}