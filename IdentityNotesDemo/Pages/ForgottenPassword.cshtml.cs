using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityNotesDemo.Models;
using IdentityNotesDemo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityNotesDemo.Pages
{
    public class ForgottenPasswordModel : PageModel
    {
        public ForgottenPasswordModel(UserManager<ApplicationUser> userManager, EmailSender emailsender)
        {
            _emailSender = emailsender;
            Input = new PasswordInputModel();
            _userManager = userManager;
        }
        private readonly EmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public PasswordInputModel Input { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if(ModelState.IsValid)
            {
                var result = await _userManager.GeneratePasswordResetTokenAsync(await _userManager.FindByEmailAsync(Input.EMail));
                SuccessMessage = "Token pro resetování hesla byl odeslán";
                await _emailSender.SendEmailAsync(Input.EMail, "Password Recovery", "Enter this code in the password recovery site\n" + result);
                return RedirectToPage("PasswordRecovery", new { email = Input.EMail });
            }
            return Page();
        }
        public string ReturnUrl { get; set; }
    }
    public class PasswordInputModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

    }
}