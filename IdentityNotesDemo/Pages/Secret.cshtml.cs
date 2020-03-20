using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityNotesDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityNotesDemo
{
    [Authorize]
    public class SecretModel : PageModel
    {
        private readonly ApplicationDbContext Db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        [BindProperty]
        public List<Note> Notes { get; set; }
        public SecretModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            Db = db;
        }
        public void OnGet()
        {
            Notes = new List<Note>();
            if (Notes.Count == 0)
            {
                foreach (Note var in Db.Notes.Where(x => x.Owner.UserName == _signinManager.Context.User.Identity.Name))
                {
                    Notes.Add(var);
                }
            }

        }
    }
}