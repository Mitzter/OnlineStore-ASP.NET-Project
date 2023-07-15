namespace OnlineStore.Services.Data
{
    using OnlineStore.Services.Data.Interfaces;
    using OnlineStore.Web.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService : IHouseService
    {
        public Task<IEnumerable<IndexViewModel>> TopItemAsync()
        {
            throw new NotImplementedException();
        }
    }
}
