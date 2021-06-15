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
using System.IO;
using FreshGoods.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace FreshGoods.Pages.Admin.Items
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;
        [Obsolete]
        private IHostingEnvironment _environment;
        private readonly ILogger<EditModel> logger;

        [Obsolete]
        public EditModel(FreshGoods.Data.FreshGoodsDbContext context, IHostingEnvironment environment, ILogger<EditModel> logger)
        {
            _context = context;
            _environment = environment;
            this.logger = logger;
        }
        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        [Obsolete]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Upload != null)
            {
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
                    logger.LogInformation($"{ex.Message}");
                    ModelState.AddModelError(string.Empty, "Internal error saving the uploaded file");
                    return Page();
                }
            }

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            logger.LogInformation($"Admin edited this Item: {Item.Id}");
            return RedirectToPage("./Index");
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
