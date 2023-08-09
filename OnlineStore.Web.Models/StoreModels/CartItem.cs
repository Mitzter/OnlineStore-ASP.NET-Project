using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Web.Models.StoreModels
{
    public class CartItem
    {
        
        public Guid Id { get; set; }
        public string ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal BulkPrice { get; set; }

        public string Image { get; set; }

        public CartItem()
        {
            Id = Guid.NewGuid();
        }

        public CartItem(Item item)
        {
            ProductId = item.Id.ToString();
            ProductName = item.Name;
            Quantity = 1;
            Price = item.Price;
            BulkPrice = item.BulkPrice;
            Image = item.ImageUrl;
        }
    }
}
