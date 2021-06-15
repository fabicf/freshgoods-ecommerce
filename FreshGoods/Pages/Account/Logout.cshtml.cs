using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshGoods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FreshGoods.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;
        public LogoutModel(SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            this._signInManager = signInManager;
            this._logger = logger;
        }
        public async Task<IActionResult> OnGetAsync()
        {
        // TODO: log user information if user was logged in
            if (_signInManager.IsSignedIn(User)) {
                _logger.LogInformation($"User {User.Identity.Name} logged out");
            }            
            await _signInManager.SignOutAsync();
            return Page();            
        }
        //public async Task<IActionResult> OnPostAsync(string ReturnUrl=null)
        public void OnPost()
        {
           
        }

    }
}
