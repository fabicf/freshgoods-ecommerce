using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FreshGoods.Data;
using FreshGoods.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Logging;
using FreshGoods.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FreshGoods.Pages.Admin.Items
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;
        [Obsolete]
        private IHostingEnvironment _environment;
        private readonly ILogger<CreateModel> logger;

        [Obsolete]
        public CreateModel(FreshGoods.Data.FreshGoodsDbContext context, IHostingEnvironment environment, ILogger<CreateModel> logger)
        {
            _context = context;
            _environment = environment;
            this.logger = logger;
        }
        public ItemCategory category { get; set; }
        public string imageExist;
        public IActionResult OnGet()
        {
            
            return Page();
        }
        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Item Item { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        [Obsolete]
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            if(Upload== null){
                logger.LogInformation("Hello");
                imageExist="You must upload an image.";
                return Page();
            }
                logger.LogInformation("Hello");
                string fileExtension = Path.GetExtension(Upload.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".gif", ".png" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError(string.Empty, "Only image files (jpg, jpeg, gif, png) are allowed");
                    return Page();
                }
                var newFileName = Utils.RandomString();
                newFileName+= fileExtension;
                var destPath = Path.Combine(_environment.ContentRootPath, "wwwroot", "images", newFileName);
                Item.ImagePath = newFileName;
                // FIXME: handle IO errors when copying the file
                try
                {
                    using (var fileStream = new FileStream(destPath, FileMode.Create))
                    {
                        Upload.CopyTo(fileStream);
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is SystemException)
                {
                    logger.LogInformation($"Error Uploading photo.");
                    
                    ModelState.AddModelError(string.Empty, "Internal error saving the uploaded file");
                    return Page();
                }
            category = await _context.ItemCategories.FirstOrDefaultAsync(m=>m.Id==Item.CategoryId);
            Item.Category = category;

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();
            logger.LogInformation($"Admin added {Item.Id} to items.");

            return RedirectToPage("./Index");
        }

    }
}
