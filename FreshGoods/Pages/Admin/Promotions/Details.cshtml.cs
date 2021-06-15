using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FreshGoods.Data;
using FreshGoods.Models;
using Microsoft.AspNetCore.Authorization;

namespace FreshGoods.Pages.Admin.Promotions
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;

        public DetailsModel(FreshGoods.Data.FreshGoodsDbContext context)
        {
            _context = context;
        }

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
    }
}
