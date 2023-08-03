namespace OnlineStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineStore.Services.Data._0_Interfaces.UserInterfaces;
    using OnlineStore.Web.ViewModels.ViewModels.UserViewModels;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = await
                this.userService.AllUsersAsync();

            return View(viewModel);
        }
    }
}
