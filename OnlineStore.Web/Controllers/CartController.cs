using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
using OnlineStore.Web.Data;
using OnlineStore.Web.Infrastructure;
using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.Models.UserModels;
using OnlineStore.Web.ViewModels.FormModels.StoreFormModels;
using OnlineStore.Web.ViewModels.ViewModels.StoreViewModels;
using System.Net.Http.Headers;

namespace OnlineStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly OnlineStoreDbContext dbContext;
        private readonly IStoreService storeService;

        public CartController(OnlineStoreDbContext dbContext, IStoreService storeService)
        {
            this.dbContext = dbContext;
            this.storeService = storeService;
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

            
            ShoppingCartViewModel viewModel = new()
            {
                CartItems = cart,
                GrantTotal = grandTotal,
                IsUserCompanyRegistered = isUserCompanyRegistered,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Add(Guid id)
        {
            Item? item = await dbContext.Items.FindAsync(id);


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem? cartItem = cart.Where(c => c.ProductId == id.ToString()).FirstOrDefault();

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

        public async Task<IActionResult> Decrease(Guid id)
        {


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem? cartItem = cart.Where(c => c.ProductId == id.ToString()).FirstOrDefault();

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

            TempData["Success"] = "The product has been added";

            return Redirect("Index");
        }

        public async Task<IActionResult> Remove(Guid id)
        {


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            cart.RemoveAll(x => x.ProductId == id.ToString());




            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }



            TempData["Success"] = "The product has been added";

            return Redirect("Index");
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

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderFormModel order)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            try
            {
                var userId = this.User.GetId();
                string orderId = await this.storeService.CreateOrderAsync(order, userId!, cart);
                HttpContext.Session.Remove("Cart");
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
