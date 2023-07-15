namespace OnlineStore.Services.Data.Interfaces
{
    using OnlineStore.Web.ViewModels;

    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> TopItemAsync();
    }
}