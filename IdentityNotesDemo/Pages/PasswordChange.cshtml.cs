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
    public class PasswordChangeModel : PageModel
    {
        public PasswordChangeModel(UserManager<ApplicationUser> usermanager)
        {
            Input = new ChangeModel();
            _userManager = usermanager;
        }
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public bool Succedeed { get; set; }
        [BindProperty]
        public ChangeModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            if(ModelState.IsValid && Input.Password == Input.ConfirmPassword)
            {

            }
        }
    }
    public class ChangeModel
    {
        [Required]
        [BindProperty]
        public string Password { get; set; }
        [Required]
        [BindProperty]
        public string ConfirmPassword { get; set; }

    }
}