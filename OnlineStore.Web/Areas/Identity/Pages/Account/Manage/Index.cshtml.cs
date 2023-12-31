﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStore.Web.Data;
using OnlineStore.Web.Models.UserModels;

namespace OnlineStore.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly OnlineStoreDbContext dbContext;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            OnlineStoreDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.dbContext = dbContext;
        }

      
        [TempData]
        public string StatusMessage { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

 
        public class InputModel
        {
            [Display(Name = "Profile Picture")]
            public IFormFile PictureUser { get; set; }
            [Display(Name = "User Name")]   
            public string DisplayName { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public byte[]? CurrentPictureSource { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            Input = new InputModel
            {
                DisplayName = user.DisplayName,
                PhoneNumber = phoneNumber,
                CurrentPictureSource = user.PictureSource
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
               
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if(Input.PictureUser != null)
            {
                using (var memoryStream = new MemoryStream())
                {

                    await Input.PictureUser.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB  
                    if (memoryStream.Length < 2097152)
                    {
                        user.PictureSource = memoryStream.ToArray();
                        await this.dbContext.SaveChangesAsync();  
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
            }
            
            if (Input.DisplayName != user.DisplayName) 
            {
                user.DisplayName = Input.DisplayName; 
                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update display name.";
                    return RedirectToPage();
                }
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
