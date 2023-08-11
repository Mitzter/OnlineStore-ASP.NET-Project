namespace OnlineStore.Web.ViewModels.ViewModels.UserViewModels
{
    using AutoMapper;
    using OnlineStore.Services.Mapping;
    using OnlineStore.Web.Models.UserModels;

    public class UserViewModel : IMapFrom<BulkBuyer> 
    {
        public string Id { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? VATNumber { get; set; }

        public string? CompanyName { get; set; }

        public string? FinancialManager { get; set; }

     
    }
}
