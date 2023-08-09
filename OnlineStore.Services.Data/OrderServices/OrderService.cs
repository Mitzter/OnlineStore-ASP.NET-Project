using Microsoft.EntityFrameworkCore;
using OnlineStore.Services.Data._0_Interfaces.OrderInterfaces;
using OnlineStore.Web.Data;
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.Models.StoreModels.Enums;
using OnlineStore.Web.Models.UserModels;
using OnlineStore.Web.ViewModels.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Data.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly OnlineStoreDbContext dbContext;

        public OrderService(OnlineStoreDbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        public async Task ChangeOrderStatusAsync(string id, int statusNum)
        {
            Order order = await GetOrderByIdAsync(id);

            order.Status = (OrderStatus)statusNum;

            this.dbContext.SaveChanges();
        }

        public async Task<IEnumerable<AllOrdersViewModel>> GetAllOrdersAsync()
        {
            IEnumerable<AllOrdersViewModel> allOrders = await this.dbContext
                .Orders
                .Include(o => o.OrderedItems)
                .Select(o => new AllOrdersViewModel
                {
                    Id = o.Id.ToString(),
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    PhoneNumber = o.PhoneNumber,
                    User = o.User,
                    CartItems = o.OrderedItems,
                    OrderTime = o.OrderTime,
                    Status = o.Status,
                    Total = o.OrderedItems.Sum(x => x.Quantity * x.Price),
                    IsUserCompanyRegistered = o.IsUserCompanyRegistered,
                })
                .ToListAsync();

            return allOrders;

        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {

            Order? order = await this.dbContext
                .Orders
                .Include(o => o.OrderedItems)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id.ToString() == id);

            return order;
        }

        public async Task<OrderViewModel> GetOrderViewAsync(string id)
        {
            Order order = await GetOrderByIdAsync(id);

            OrderViewModel viewModel = new OrderViewModel()
            {
                Id = order.Id.ToString(),
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                UserId = order.User.Id,
                User = order.User,
                PostalCode = order.PostalCode,
                City = order.City,
                Address = order.Address,
                AdditionalInformation = order.AdditionalInformation,
                OrderedItems = order.OrderedItems,
                OrderTime = order.OrderTime,
                Status = order.Status,
            };

            return viewModel;
        }
    }
}
