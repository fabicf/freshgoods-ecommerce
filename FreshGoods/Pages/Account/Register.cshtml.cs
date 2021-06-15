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
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(50)]
            [Display(Name = "Address 1")]
            public string Address1 { get; set; }

            [StringLength(50)]
            [Display(Name = "Address 2")]
            public string Address2 { get; set; }

            [Required]
            [StringLength(30)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [StringLength(30)]
            [Display(Name = "Province")]
            public string Province { get; set; }

            [Required]
            [StringLength(7)]
            [Display(Name = "ZipCode")]
            public string ZipCode { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(){
            if(ModelState.IsValid){
                //using(var BlogDbContext = Context.Database.BeginTransaction()){}
                var user = new ApplicationUser{
                    UserName = Input.Email,
                    Email = Input.Email,
                    Address1 = Input.Address1,
                    Address2 = Input.Address2,
                    City = Input.City,
                    Province = Input.Province,
                    ZipCode = Input.ZipCode
                };
                var result = await _userManager.CreateAsync(user,Input.Password);
                if(result.Succeeded){
                    var result2 = await _userManager.AddToRoleAsync(user, "User");
                    if (result2.Succeeded) {
                        _logger.LogInformation($"User {Input.Email} create new account with password");
                        return RedirectToPage("RegisterSuccess",new {email = Input.Email});
                    }else{
                        //fix me

                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            //var result= await UserManager.CreateAsnc(user, model.Password);

            }
            return Page();
        }

    }
}
