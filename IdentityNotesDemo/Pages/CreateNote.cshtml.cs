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
    public class CreateNoteModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly ApplicationDbContext Db;

        public CreateNoteModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            Db = db;
        }
        public CreateModel Input { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                Db.Notes.Add(new Note { Owner = await _userManager.FindByNameAsync(_signinManager.Context.User.Identity.Name), OwnerId = (await _userManager.FindByNameAsync(_signinManager.Context.User.Identity.Name)).Id, Text = Input.Text, Title = Input.Title });
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
    public class CreateModel
    {
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Titul")]
        public string Title { get; set; }
    }
}