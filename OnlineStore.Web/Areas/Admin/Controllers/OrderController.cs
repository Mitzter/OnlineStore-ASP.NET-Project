using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Data._0_Interfaces.OrderInterfaces;
using OnlineStore.Web.ViewModels.ViewModels.OrderViewModels;

namespace OnlineStore.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseAdminController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
                this.orderService = orderService;
        }

        public async Task<IActionResult> AllOrders()
        {
            IEnumerable<AllOrdersViewModel> viewModel = await this.orderService
                .GetAllOrdersAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            OrderViewModel viewModel = await this.orderService.GetOrderViewAsync(id);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(string id, int status)
        {
            await this.orderService.ChangeOrderStatusAsync(id, status);

            return RedirectToAction("AllOrders", "Order");
        }
    }
}
