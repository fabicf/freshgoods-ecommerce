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
    public class IndexModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;

        public IndexModel(FreshGoods.Data.FreshGoodsDbContext context)
        {
            _context = context;
        }

        public IList<Promotion> Promotion { get;set; }

        public async Task OnGetAsync()
        {
            Promotion = await _context.Promotions.ToListAsync();
        }
    }
}
