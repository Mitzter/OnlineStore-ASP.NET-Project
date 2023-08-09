using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Web.ViewModels.ViewModels.StoreViewModels
{
    public class SmallCartViewModel
    {
        public int NumberOfItems { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
