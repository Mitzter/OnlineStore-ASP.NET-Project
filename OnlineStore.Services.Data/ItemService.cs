namespace OnlineStore.Services.Data
{
    using OnlineStore.Services.Data.Interfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemService : IItemService
    {


        public readonly OnlineStoreDbContext dbContext;

        public ItemService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<IndexViewModel>> TopItemAsync()
        {
            throw new NotImplementedException();
        }
    }
}
