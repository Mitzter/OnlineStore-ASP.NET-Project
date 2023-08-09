using OnlineStore.Web.Data;
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.ViewModels.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Data._0_Interfaces.OrderInterfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<AllOrdersViewModel>> GetAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(string id);

        Task<OrderViewModel> GetOrderViewAsync(string id);

        Task ChangeOrderStatusAsync(string id, int statusNum);
    }
}
