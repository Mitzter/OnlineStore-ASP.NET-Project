
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
using OnlineStore.Web.ViewModels.ViewModels.OrderViewModels;


namespace OnlineStore.Services.Data._0_Interfaces.OrderInterfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<AllOrdersViewModel>> GetAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(string id);

        Task<OrderViewModel> GetOrderViewAsync(string id);

        Task ChangeOrderStatusAsync(string id, int statusNum);

        Task<string> CreateOrderAsync(OrderFormModel formModel, string userId, List<CartItem> sessionItems);
    }
}
