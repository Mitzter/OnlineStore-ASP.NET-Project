﻿using Microsoft.AspNetCore.Mvc;
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
    }
}