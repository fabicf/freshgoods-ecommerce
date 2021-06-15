using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FreshGoods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FreshGoods.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        public LoginModel(SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger)
        {
            this._signInManager = signInManager;
            this._logger = logger;
        }
        public string ReturnUrl { get; set; }
        [BindProperty]
        public InputModel Input{get;set;}
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(){
            if(ModelState.IsValid){
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password,false,true);
                if(result.Succeeded){
                    _logger.LogInformation($"User {Input.Email} logged in");
                    return RedirectToPage("LoginSuccess");
                }
                else{
                    ModelState.AddModelError(string.Empty,"Login failed (user does not exist ,password invalid)");
                }
            }
            return Page();
        }
    }
}
