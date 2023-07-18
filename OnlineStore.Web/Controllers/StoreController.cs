namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.ViewModels.StoreModels;

    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        private readonly IItemCategoryService itemCategoryService;

        public StoreController(IStoreService storeService, IItemCategoryService itemCategoryService)
        {
            this.storeService = storeService;
            this.itemCategoryService = itemCategoryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Store([FromQuery]AllItemsQueryModel queryModel)
        {
            FilteredAndPagedItemsServiceModel serviceModel = await
                this.storeService.AllAsync(queryModel);

            queryModel.Items = serviceModel.Items;
            queryModel.TotalItems = serviceModel.TotalItemsCount;
            queryModel.Categories = await this.itemCategoryService.AllCategoryNamesAsync();

            return View(queryModel);
        }
    }
}
