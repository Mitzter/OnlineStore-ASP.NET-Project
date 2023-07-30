﻿namespace OnlineStore.Services.Data._0_Interfaces.UserInterfaces
{
    using OnlineStore.Web.ViewModels.FormModels.UserFormModels;

    public interface IUserService
    {
        Task<bool> IsUserBulkClientAsync(string userId);

        Task CreateBulkClient(string userId, BecomeBulkClientFormModel formModel);

        Task<bool> IsPhoneNumberTakenAsync(string phoneNumber);

        Task<bool> IsCompanyNameTakenAsync(string companyName);

        Task<bool> IsCompanyRegisteredWithSameVAT(string vatNumber);
    }
}
