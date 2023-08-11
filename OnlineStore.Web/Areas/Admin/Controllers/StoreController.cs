namespace OnlineStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Services.Data.StoreServices;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;

    public class StoreController : BaseAdminController
    {
        private readonly IItemCategoryService itemCategoryService;
        private readonly IItemService itemService;
        private readonly IStoreService storeService;

        public StoreController(IItemCategoryService itemCategoryService, IItemService itemService, IStoreService storeService)
        {
            this.itemCategoryService = itemCategoryService;    
            this.itemService = itemService;
            this.storeService = storeService;
        }
        public async Task<IActionResult> Products([FromQuery] AllItemsQueryModel queryModel)
        {
            FilteredAndPagedItemsServiceModel serviceModel = await
                this.storeService.AllAdminViewAsync(queryModel);

            queryModel.Items = serviceModel.Items;
            queryModel.TotalItems = serviceModel.TotalItemsCount;
            queryModel.Categories = await this.itemCategoryService.AllCategoryNamesAsync();

            return View(queryModel);
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

                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured when trying to add new product. Please try again later or contact an administrator!");
                model.Categories = await this.itemCategoryService
                    .AllCategoriesAsync();

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ItemFormModel formModel = await this.itemService
                .GetItemForEditByIdAsync(id);

            formModel.Categories = await this.itemCategoryService.AllCategoriesAsync();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ItemFormModel formModel)
        {
            await this.itemService.EditItemById(id, formModel);

            return RedirectToAction("Products", "Store");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(string id, int status)
        {
            await this.itemService.ChangeItemStatusAsync(id, status);

            return RedirectToAction("Products", "Store");
        }
    }
}
