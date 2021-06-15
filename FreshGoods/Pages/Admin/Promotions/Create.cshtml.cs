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

namespace FreshGoods.Pages.Admin.Promotions
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;

        public CreateModel(FreshGoods.Data.FreshGoodsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Promotion Promotion { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Promotions.Add(Promotion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
