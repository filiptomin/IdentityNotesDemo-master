using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityNotesDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityNotesDemo.Pages
{
    public class PasswordRecoveryModel : PageModel
    {
        public PasswordRecoveryModel(UserManager<ApplicationUser> usermanager)
        {
            Input = new RecoveryModel();
            _userManager = usermanager;
        }
        public string ReturnUrl { get; set; }
        [BindProperty]
        public RecoveryModel Input { get; set; }
        [BindProperty]
        public string Email { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            if(ModelState.IsValid && Input.Password == Input.ConfirmPassword)
            {
                await _userManager.ResetPasswordAsync(await _userManager.FindByEmailAsync(Email), Input.Code, Input.Password);
                return RedirectToPage("Index", Email);
            }
            return Page();
        }
    }
    public class RecoveryModel
    {
        [Required]
        [Display(Name = "Kód")]
        public string Code { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Heslo")]
        public string Password { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Potvrezní Hesla")]
        public string ConfirmPassword { get; set; }
    }
}