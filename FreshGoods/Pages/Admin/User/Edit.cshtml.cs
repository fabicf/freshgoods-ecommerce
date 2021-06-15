using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreshGoods.Data;
using FreshGoods.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace FreshGoods.Pages.Admin.User
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<EditModel> _logger;
        public EditModel(UserManager<ApplicationUser> userManager,
            ILogger<EditModel> logger, FreshGoods.Data.FreshGoodsDbContext context)
        {
            this._userManager = userManager;
            this._logger = logger;
            this._context = context;
        }
        [BindProperty]
        public bool isUser { get; set; }
        [BindProperty]
        public bool isWorker { get; set; }
        [BindProperty]
        public bool isAdmin { get; set; }
        public string PasswordWrong;

        [StringLength(100, ErrorMessage = "Your password must be; minimum six characters; at least one uppercase letter; one lowercase letter; one number and one special character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password1;
        public string Password2;
        public IList<string> roleList;
        public string PasswordMatch;
        private Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$");

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }
        private ApplicationUser editUser;
        public string userId;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            userId = id;

            roleList = await _userManager.GetRolesAsync(ApplicationUser);
            if (roleList. Contains("Worker"))
            {
                isWorker = true;
            }
            if (roleList.Contains("Admin"))
            {
                isAdmin = true;
            }
            if (roleList.Contains("User"))
            {
                isUser = true;
            }


            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            userId = ApplicationUser.Id;

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == userId);
            editUser = ApplicationUser;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!(Password1 == null || rgx.IsMatch(Password1)))
            {
                PasswordWrong = "Your password must be; minimum six characters; at least one uppercase letter; one lowercase letter; one number and one special character";
                return Page();
            }
            if (!(Password1 == null || !string.Equals(Password1, Password2)))
            {
                PasswordMatch = "Both Entries of your password must match.";
                return Page();
            }
            if (Password1 != null)
            {
                var result = await _userManager.ChangePasswordAsync(editUser, ApplicationUser.Email, "1");
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Admin changed account {ApplicationUser.Id} Password.");
                }

            }
            _logger.LogInformation($"{isAdmin},{isUser},{isWorker}");
            await _userManager.RemoveFromRoleAsync(editUser, "User");
            await _userManager.RemoveFromRoleAsync(editUser, "Worker");
            await _userManager.RemoveFromRoleAsync(editUser, "Admin");

            if (isUser)
            {
                var result2 = await _userManager.AddToRoleAsync(ApplicationUser, "User");
                if (result2.Succeeded)
                {
                    _logger.LogInformation($"Admin editted account for {ApplicationUser.Email} with User Privelage");
                }
            }
            if (isAdmin)
            {
                var result2 = await _userManager.AddToRoleAsync(ApplicationUser, "Admin");
                if (result2.Succeeded)
                {
                    _logger.LogInformation($"Admin editted account for {ApplicationUser.Email} with Admin Privelage");
                }
            }
            if (isWorker)
            {
                var result2 = await _userManager.AddToRoleAsync(ApplicationUser, "Worker");
                if (result2.Succeeded)
                {
                    _logger.LogInformation($"Admin editted account for {ApplicationUser.Email} with Worker Privelage");
                }
            }
            editUser.Address1 = ApplicationUser.Address1;
            editUser.Address2 = ApplicationUser.Address2;
            editUser.City = ApplicationUser.City;
            editUser.Province = ApplicationUser.Province;
            editUser.ZipCode = ApplicationUser.ZipCode;

            _context.Attach(editUser).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(editUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogInformation($"Admin editted account for {ApplicationUser.Email}.");
            return RedirectToPage("./Index");

        }

        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
