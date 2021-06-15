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

namespace FreshGoods.Pages.Admin.Promotions
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;

        public EditModel(FreshGoods.Data.FreshGoodsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Promotion Promotion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Promotion = await _context.Promotions.FirstOrDefaultAsync(m => m.Id == id);

            if (Promotion == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Promotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(Promotion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}
