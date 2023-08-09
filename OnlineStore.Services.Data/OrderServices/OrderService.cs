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
    }
}
