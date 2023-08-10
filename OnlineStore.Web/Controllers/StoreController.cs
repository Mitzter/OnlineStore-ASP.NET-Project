namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Web.Infrastructure;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;
    using static OnlineStore.Common.NotificationMessagesConstants;

    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        private readonly IItemCategoryService itemCategoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public StoreController(IStoreService storeService, IItemCategoryService itemCategoryService, UserManager<ApplicationUser> userManager)
        {
            this.storeService = storeService;
            this.itemCategoryService = itemCategoryService;
            this.userManager = userManager;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool itemExists = await this.storeService
                .ExistsByIdAsync(id);

            try
            {
                if (!itemExists)
                {
                    this.TempData[ErrorMessage] = "Item does not exist";

                    return this.RedirectToAction("Store", "Store");
                }

                ItemDetailsViewModel viewModel = await this.storeService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Buy(string itemId, int quantity)
        {
            bool itemExists = await this.storeService.ExistsByIdAsync(itemId);
            if (!itemExists)
            {
                this.TempData[ErrorMessage] = "Item with the provided ID does not exist";

                return this.RedirectToAction("Store", "Store");
            }

            try
            {
               await this.storeService.BuyItemAsync(itemId, this.User.GetId()!, quantity);
               return Ok(new { message = "Item purchased successfully!" });
            }
            catch (Exception)
            {

                return this.GeneralError();
            }
        }


       

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact an administrator!";

            return this.RedirectToAction("Store", "Store");
        }
    }
}
