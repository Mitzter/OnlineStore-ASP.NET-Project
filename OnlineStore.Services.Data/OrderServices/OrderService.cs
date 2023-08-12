using Microsoft.EntityFrameworkCore;
using OnlineStore.Services.Data._0_Interfaces.OrderInterfaces;
using OnlineStore.Web.Data;
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.Models.StoreModels.Enums;
using OnlineStore.Web.Models.UserModels;
using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
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
                    IsUserCompanyRegistered = o.IsUserCompanyRegistered,
                })
                .ToListAsync();

            return allOrders;

        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {


            Order order = await this.dbContext
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
                IsUserCompanyRegistered = order.IsUserCompanyRegistered,

            };

            return viewModel;
        }

        public async Task<string> CreateOrderAsync(OrderFormModel formModel, string userId, List<CartItem> sessionItems)
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            var orderedItems = sessionItems;
            bool isUserCompanyRegistered = false;

            var bulkBuyer = await this.dbContext
                .BulkBuyers
                .FirstOrDefaultAsync(u => u.UserId.ToString() == userId);
            if (bulkBuyer?.UserId == user!.Id)
            {
                isUserCompanyRegistered = true;
            }

            Order order = new Order()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
                City = formModel.City,
                Address = formModel.Address,
                AdditionalInformation = formModel.AdditionalInformation,
                PhoneNumber = formModel.PhoneNumber,
                PostalCode = formModel.PostalCode,
                UserId = user!.Id,
                User = user,
                OrderTime = DateTime.UtcNow,
                OrderedItems = orderedItems,
                Status = OrderStatus.Pending,
                IsUserCompanyRegistered = isUserCompanyRegistered,
            };

            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();


            return order.Id.ToString();
        }

    }
}
