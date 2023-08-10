
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using OnlineStore.Services.Data._0_Interfaces.MailInterfaces;
using OnlineStore.Web.Models.UserModels;

namespace OnlineStore.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailService mailService;

        public ResendEmailConfirmationModel(UserManager<ApplicationUser> userManager, IMailService mailService)
        {
            _userManager = userManager;
            this.mailService = mailService;
        }

 
        [BindProperty]
        public InputModel Input { get; set; }

 
        public class InputModel
        {

            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "The provided e-mail is not tied to a registered user");
                return Page();
            }

            if (user.EmailConfirmed == true)
            {
                ModelState.AddModelError(string.Empty, "This account has already been confirmed");
                return Page();
            }
            else
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = userId, code = code },
                    protocol: Request.Scheme);
                await this.mailService.SendEmailAsync(
                    Input.Email,
                    "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
                return Page();
            }

            
        }
    }
}
