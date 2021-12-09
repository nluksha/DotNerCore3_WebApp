using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class FormHandlerModel : PageModel
    {
        private DataContext context;

        [BindProperty]
        public Product Product { get; set; }

        public FormHandlerModel(DataContext context)
        {
            this.context = context;
        }

        public async Task OnGetAsync(long id = 1)
        {
            Product = await context.Products.FindAsync(id);
        }

        public IActionResult OnPost()
        {
            TempData["Product"] = JsonSerializer.Serialize(Product);

            return RedirectToPage("FormResults");
        }
    }
}
