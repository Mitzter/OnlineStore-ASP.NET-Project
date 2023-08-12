namespace OnlineStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data._0_Interfaces.UserInterfaces;
    using OnlineStore.Web.Infrastructure;
    using OnlineStore.Web.Models.StoreModels;
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
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            var userId = this.User.GetId();


            try
            {
                bool isBulkBuyerAlready = await this.userService.IsUserBulkClientAsync(userId!);
                ApplicationUser user = await this.userService.GetUserByIdAsync(userId!);

                if (cart != null)
                {
                    decimal shoppingCartTotal = 0;

                    foreach (var item in cart)
                    {
                        shoppingCartTotal += item.Price * item.Quantity;
                    }

                    if (shoppingCartTotal < 1000)
                    {
                        this.TempData[ErrorMessage] = "You do not have access to this page.";

                        return this.RedirectToAction("Index", "Home");
                    }
                }
                else if (cart == null)
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
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Was unable to register as a company. An unexpected error occured";
                return this.RedirectToAction("Index", "Home");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(BecomeBulkClientFormModel model)
        {
            var userId = this.User.GetId();
            bool isBulkBuyerAlready = await this.userService.IsUserBulkClientAsync(userId);

            
            try
            {
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

                await this.userService.CreateBulkClient(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured when registering as a bulk client. Please contact an administrator or try again later!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index", "Cart");
        }
    }
}
