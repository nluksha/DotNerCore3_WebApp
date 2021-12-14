using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages
{
    public class IndexModel2 : PageModel
    {
        private DataContext context;

        public Product Product { get; set; }

        public IndexModel2(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(long id = 1)
        {
            Product = await context.Products.FindAsync(id);

            return Page();
        }
    }
}
