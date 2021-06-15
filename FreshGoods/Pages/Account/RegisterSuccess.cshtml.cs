using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshGoods.Pages.Account
{
    public class RegisterSuccessModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string Email { get; set; }
        public void OnGet()
        {
        }
    }
}
