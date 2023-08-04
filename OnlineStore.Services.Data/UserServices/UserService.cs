namespace OnlineStore.Services.Data.UserServices
{
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.UserInterfaces;
    using OnlineStore.Services.Mapping;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.UserModels;
    using OnlineStore.Web.ViewModels.FormModels.UserFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.UserViewModels;
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

        public async Task<IEnumerable<UserViewModel>> AllUsersAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    DisplayName = u.DisplayName!
                })
                .ToListAsync();

            foreach (UserViewModel user in allUsers)
            {
                BulkBuyer? bulkBuyer = this.dbContext
                    .BulkBuyers
                    .FirstOrDefault(u => u.UserId.ToString() == user.Id);

                if (bulkBuyer != null)
                {
                    user.PhoneNumber = bulkBuyer.PhoneNumber;
                    user.VATNumber = bulkBuyer.VATNumber;
                    user.CompanyName = bulkBuyer.CompanyName;
                    user.FinancialManager = bulkBuyer.FinancialManager;
                }
                else
                {

                    user.PhoneNumber = string.Empty;
                    user.VATNumber = string.Empty;
                    user.CompanyName = string.Empty;
                    user.FinancialManager = string.Empty;
                }
            }

            return allUsers;


            //IEnumerable<UserViewModel> bulkBuyers = await this.dbContext
            //    .BulkBuyers
            //    .Include(a => a.User)
            //    .To<UserViewModel>()
            //    .ToArrayAsync();

            //allUsers.AddRange(bulkBuyers);
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

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            return user;
        }

        public async Task<string> GetUserNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return String.Empty;
            }

            return $"{user.UserName}";
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
