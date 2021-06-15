using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FreshGoods.Data;
using FreshGoods.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FreshGoods.Pages.Admin.User
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<CreateModel> _logger;
        public CreateModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<CreateModel> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
        }
        [BindProperty]
        public bool isUser { get; set; }
        [BindProperty]
        public bool isWorker { get; set; }
        [BindProperty]
        public bool isAdmin { get; set; }
        public string PasswordWrong;
        public string PasswordMatch;
        [BindProperty]
        public string Password1{ get; set; }
        [BindProperty]
        public string Password2 { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        private Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$");

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            PasswordWrong = "";
            PasswordMatch = "";
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!rgx.IsMatch(Password1))
            {
                PasswordWrong = "Your password must be; minimum six characters; at least one uppercase letter; one lowercase letter; one number and one special character";
                return Page();
            }
            if (!string.Equals(Password1, Password2))
            {
                PasswordMatch = "Both Entries of your password must match.";
                return Page();
            }
            var user = new ApplicationUser
            {
                UserName = ApplicationUser.Email,
                Email = ApplicationUser.Email,
                Address1 = ApplicationUser.Address1,
                Address2 = ApplicationUser.Address2,
                City = ApplicationUser.City,
                Province = ApplicationUser.Province,
                ZipCode = ApplicationUser.ZipCode
            };
            var result = await _userManager.CreateAsync(user, Password1);
            if (result.Succeeded)
            {
                if (isUser)
                {
                    var result2 = await _userManager.AddToRoleAsync(user, "User");
                    if (result2.Succeeded)
                    {
                        _logger.LogInformation($"Admin create new account for {ApplicationUser.Email} with User Privelage");
                    }
                }
                if (isAdmin)
                {
                    var result2 = await _userManager.AddToRoleAsync(user, "Admin");
                    if (result2.Succeeded)
                    {
                        _logger.LogInformation($"Admin create new account for {ApplicationUser.Email} with Admin Privelage");
                    }
                }
                if (isWorker)
                {
                    var result2 = await _userManager.AddToRoleAsync(user, "Worker");
                    if (result2.Succeeded)
                    {
                        _logger.LogInformation($"Admin create new account for {ApplicationUser.Email} with Worker Privelage");
                    }
                }


                return RedirectToPage("./Index");
            }
            else
            {
                //FIXME if fail make it do something
                return RedirectToPage("./Index");
            }
        }
    }
}
