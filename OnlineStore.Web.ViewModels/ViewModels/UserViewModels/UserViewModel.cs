namespace OnlineStore.Web.ViewModels.ViewModels.UserViewModels
{
    using AutoMapper;
    using OnlineStore.Services.Mapping;
    using OnlineStore.Web.Models.UserModels;

    public class UserViewModel : IMapFrom<BulkBuyer> //IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? VATNumber { get; set; }

        public string? CompanyName { get; set; }

        public string? FinancialManager { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration
        //        .CreateMap<BulkBuyer, UserViewModel>()
        //        .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
        //        .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName))
        //}
    }
}
