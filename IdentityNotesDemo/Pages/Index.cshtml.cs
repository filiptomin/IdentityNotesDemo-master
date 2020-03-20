using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityNotesDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IdentityNotesDemo.Pages
{
    public class IndexModel : PageModel
    {
        ////private readonly ILogger<IndexModel> _logger;

        //public IndexModel(/*ILogger<IndexModel> logger*/)
        //{
        //    //_logger = logger;
        //}
        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _roleManager = roleManager;
        }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public bool SignedIn { get; set; }
        public void OnGet()
        {
            SignedIn = _signinManager.Context.User.Identity.Name != null;
        }
        public IActionResult OnGetRedirect()
        {
            if (_signinManager.Context.User.IsInRole("Administrátor"))
            {
                return RedirectToPage("Admin");
            }
            else
            {

                return RedirectToPage("Secret");
            }
        }
    }
}
