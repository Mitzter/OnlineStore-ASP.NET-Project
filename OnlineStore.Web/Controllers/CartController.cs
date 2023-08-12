
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Services.Data._0_Interfaces.OrderInterfaces;
using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
using OnlineStore.Web.Data;
using OnlineStore.Web.Infrastructure;
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;
using static OnlineStore.Common.NotificationMessagesConstants;

namespace OnlineStore.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly OnlineStoreDbContext dbContext;
        private readonly IOrderService orderService;

        public CartController(OnlineStoreDbContext dbContext, IOrderService orderService)
        {
            this.dbContext = dbContext;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.GetId()!;

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            bool isUserCompanyRegistered = false;
            decimal grandTotal = 0;

            var bulkBuyer = await this.dbContext
                .BulkBuyers
                .FirstOrDefaultAsync(u => u.UserId.ToString() == userId);

            if (bulkBuyer?.UserId == user!.Id)
            {
                isUserCompanyRegistered = true;
                grandTotal = cart.Sum(x => x.Quantity * x.BulkPrice);
            }
            else
            {
                grandTotal = cart.Sum(x => x.Quantity * x.Price);
            }


            try
            {
                ShoppingCartViewModel viewModel = new()
                {
                    CartItems = cart,
                    GrantTotal = grandTotal,
                    IsUserCompanyRegistered = isUserCompanyRegistered,
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            
        }
        public async Task<IActionResult> Add(Guid id)
        {
            Item? item = await dbContext.Items.FindAsync(id);


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem? cartItem = cart.Where(c => c.ProductId == id.ToString()).FirstOrDefault();

       
            try
            {
                if (cartItem == null)
                {
                    cart.Add(new CartItem(item));
                }
                else
                {
                    cartItem.Quantity += 1;
                }

                HttpContext.Session.SetJson("Cart", cart);

                TempData["Success"] = "The product has been added";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        public async Task<IActionResult> Decrease(Guid id)
        {


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem? cartItem = cart.Where(c => c.ProductId == id.ToString()).FirstOrDefault();


            try
            {
                if (cartItem.Quantity > 1)
                {
                    --cartItem.Quantity;
                }
                else
                {
                    cart.RemoveAll(x => x.ProductId == id.ToString());
                }

                if (cart.Count == 0)
                {
                    HttpContext.Session.Remove("Cart");
                }
                else
                {
                    HttpContext.Session.SetJson("Cart", cart);
                }

                HttpContext.Session.SetJson("Cart", cart);

                TempData["Success"] = "The product has been decreased";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            
        }

        public async Task<IActionResult> Remove(Guid id)
        {


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            try
            {
                cart.RemoveAll(x => x.ProductId == id.ToString());

                if (cart.Count == 0)
                {
                    HttpContext.Session.Remove("Cart");
                }
                else
                {
                    HttpContext.Session.SetJson("Cart", cart);
                }
                TempData["Success"] = "The product has been removed";

                return RedirectToAction("Index", "Cart");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            
        }

        public IActionResult Clear()
        {


            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout(int orderId)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            try
            {

                var userId = this.User.GetId();
                var currentUser = await this.dbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId!));
                OrderFormModel order = new OrderFormModel()
                {
                    UserId = currentUser!.Id,
                    User = currentUser,
                    OrderedItems = cart,
                };

                return View(order);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderFormModel order)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            try
            {
                var userId = this.User.GetId();
                string orderId = await this.orderService.CreateOrderAsync(order, userId!, cart);
                HttpContext.Session.Remove("Cart");
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception)
            {

                return this.GeneralError();
            }


        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("Index", "Home");
        }

    }
}
