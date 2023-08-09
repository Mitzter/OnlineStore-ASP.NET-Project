using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Web.Infrastructure.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel viewModel;

            if(cart == null || cart.Count == 0)
            {
                viewModel = null;
            }
            else
            {
                viewModel = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price)

                };
            }

            return View(viewModel);
        }
    }
}
