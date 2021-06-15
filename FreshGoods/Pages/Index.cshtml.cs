using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FreshGoods.Data;
using FreshGoods.Models;

namespace FreshGoods.Pages
{
    public class IndexModel : PageModel
    {
        public List<Item> Items { get; set; } = new List<Item>();

        private readonly FreshGoodsDbContext db;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(FreshGoodsDbContext db, ILogger<IndexModel> logger)
                {
                    this.db = db;
                    _logger = logger;
                }

        public async Task OnGetAsync()
        {
            Items = await db.Items.Take(4).ToListAsync(); // take only the 4 first items of db
        }
    }
}
