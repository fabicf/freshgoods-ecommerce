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
    public class CategoryModel : PageModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();

        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }

        public String CategoryName { get; set; }
        private readonly FreshGoodsDbContext db;
        private readonly ILogger<IndexModel> _logger;
        public CategoryModel(FreshGoodsDbContext db, ILogger<IndexModel> logger)
        {
            this.db = db;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            ItemCategories = await db.ItemCategories.ToListAsync();

            Items = await db.Items.ToListAsync();

            if (Slug != null) {
                ItemCategory selectedCategory = ItemCategories.FirstOrDefault(p => p.Slug == Slug);
                Items = Items.Where(item => item.CategoryId == selectedCategory.Id).ToList();
            }
        }
    }
}
