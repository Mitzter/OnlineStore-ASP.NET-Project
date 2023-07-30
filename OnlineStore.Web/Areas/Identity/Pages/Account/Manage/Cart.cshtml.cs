using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Web.Data;
using OnlineStore.Web.Infrastructure;
using OnlineStore.Web.Models.StoreModels;

namespace OnlineStore.Web.Areas.Identity.Pages.Account.Manage
{
    public class CartModel : PageModel
    {
        private readonly OnlineStoreDbContext _dbContext; 

        public CartModel(OnlineStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Item> UserCollectionItems { get; set; }

        public async Task OnGet()
        {
           
            string userId = this.User.GetId()!;

            var user = await _dbContext.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.BoughtItems)
                .FirstOrDefaultAsync();

            UserCollectionItems = user!.BoughtItems;
        }
    }
}
