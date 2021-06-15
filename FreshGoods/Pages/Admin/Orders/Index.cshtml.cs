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

namespace FreshGoods.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin,Worker")]
    public class IndexModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;

        public IndexModel(FreshGoods.Data.FreshGoodsDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders.Where(m=>m.perpared==false).ToListAsync();
        }
    }
}
