using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.Models.StoreModels.Enums;
using OnlineStore.Web.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Web.ViewModels.ViewModels.OrderViewModels
{
    public class AllOrdersViewModel
    {
        public AllOrdersViewModel()
        {
            this.CartItems = new List<CartItem>();
        }
        public string Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsUserCompanyRegistered { get; set; }

        public ApplicationUser User { get; set; }   
        public List<CartItem> CartItems { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public decimal Total { get; set; }

        public OrderStatus Status { get; set; }


    }
}
