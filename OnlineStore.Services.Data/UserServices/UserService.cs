namespace OnlineStore.Services.Data.UserServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.UserInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.UserFormModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly OnlineStoreDbContext dbContext;

        public UserService(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateBulkClient(string userId, BecomeBulkClientFormModel formModel)
        {
            BulkBuyer client = new BulkBuyer()
            {
                CompanyName = formModel.CompanyName,
                PhoneNumber = formModel.PhoneNumber,
                VATNumber = formModel.VATNumber,
                FinancialManager = formModel.FinancialManager,
                UserId = Guid.Parse(userId),
            };

            await this.dbContext.BulkBuyers.AddAsync(client);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsCompanyNameTakenAsync(string companyName)
        {
            bool result = await this.dbContext
                .BulkBuyers
                .AnyAsync(c => c.CompanyName == companyName);

            return result;
        }

        public async Task<bool> IsCompanyRegisteredWithSameVAT(string vatNumber)
        {
            bool result = await this.dbContext
                .BulkBuyers
                .AnyAsync(c => c.VATNumber == vatNumber);

            return result;
        }

        public async Task<bool> IsPhoneNumberTakenAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                .BulkBuyers
                .AnyAsync(c => c.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> IsUserBulkClientAsync(string userId)
        {
            bool result = await this.dbContext
                .BulkBuyers
                .AnyAsync(u => u.UserId.ToString() == userId);

            return result;
        }
    }
}
