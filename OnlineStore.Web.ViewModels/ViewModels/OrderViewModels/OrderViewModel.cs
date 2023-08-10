using OnlineStore.Web.Models.StoreModels;
using OnlineStore.Web.Models.StoreModels.Enums;
using OnlineStore.Web.Models.UserModels;
using System.Xml.Schema;

namespace OnlineStore.Web.ViewModels.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; } = null!;
            public string FirstName { get; set; } = null!;

            public string LastName { get; set; } = null!;

            public string PhoneNumber { get; set; } = null!;

            public string City { get; set; } = null!;

            public string Address { get; set; } = null!;

            public string PostalCode { get; set; } = null!;

            public string AdditionalInformation { get; set; } = null!;

            public Guid UserId { get; set; }

            public ApplicationUser User { get; set; } = null!;

            public DateTime OrderTime { get; set; }

            public List<CartItem> OrderedItems { get; set; } = null!;

            public OrderStatus Status { get; set; }

            public bool IsUserCompanyRegistered { get; set; }

            public decimal Total
            {
                get
                {
                    decimal calculatedTotal = 0;

                    foreach (var cartItem in OrderedItems)
                    {
                        if (IsUserCompanyRegistered)
                        {
                            calculatedTotal += cartItem.BulkPrice * cartItem.Quantity;
                        }
                        else
                        {
                            calculatedTotal += cartItem.Price * cartItem.Quantity;
                        }
                    }

                    return calculatedTotal;
                }
            }


    }
}

