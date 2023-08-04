namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data._0_Interfaces.UserInterfaces;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.UserFormModels;
    using static Common.NotificationMessagesConstants;
    using static OnlineStore.Web.Infrastructure.GetPrincipalExtension;

    [Authorize]
    public class BulkBuyerController : Controller
    {
        private readonly IUserService userService;

        public BulkBuyerController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterCompany()
        {
            var userId = this.User.GetId();
            bool isBulkBuyerAlready = await this.userService.IsUserBulkClientAsync(userId!);
            ApplicationUser user = await this.userService.GetUserByIdAsync(userId!);


            if(user.BoughtItems != null)
            {
                decimal shoppingCartTotal = user.BoughtItems.Sum(i => i.Price);

                if (shoppingCartTotal < 1000)
                {
                    this.TempData[ErrorMessage] = "You do not have access to this page.";

                    return this.RedirectToAction("Index", "Home");
                }
            }
            else if (user.BoughtItems == null)
            {
                this.TempData[ErrorMessage] = "You do not have access to this page.";

                return this.RedirectToAction("Index", "Home");
            }

            

            if (isBulkBuyerAlready)
            {
                this.TempData[ErrorMessage] = "You have already registered your company for your bulk discounts!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(BecomeBulkClientFormModel model)
        {
            var userId = this.User.GetId();
            bool isBulkBuyerAlready = await this.userService.IsUserBulkClientAsync(userId);

            if (isBulkBuyerAlready)
            {
                this.TempData[ErrorMessage] = "You have already registered your company for your bulk discounts!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isCompanyNameTaken =
                await this.userService.IsCompanyNameTakenAsync(model.CompanyName);

            if (isCompanyNameTaken)
            {
                this.ModelState.AddModelError(nameof(model.CompanyName), "Company with such a name already exists!");
            }

            bool isPhoneNumberTaken =
                await this.userService.IsPhoneNumberTakenAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "The phone number has already been registered to a different company!");
            }

            bool isVatNumberTaken =
                await this.userService.IsCompanyRegisteredWithSameVAT(model.VATNumber);

            if (isVatNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.VATNumber), "The VAT number is already in use by another company!");
            }


            try
            {
                await this.userService.CreateBulkClient(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured when registering as a bulk client. Please contact an administrator or try again later!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Cart", "Store");
        }
    }
}
