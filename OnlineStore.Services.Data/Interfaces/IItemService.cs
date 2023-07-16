namespace OnlineStore.Services.Data.Interfaces
{
    using OnlineStore.Web.ViewModels;

    public interface IItemService
    {
        Task<IEnumerable<IndexViewModel>> TopItemAsync();

    }
}