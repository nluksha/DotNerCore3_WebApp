using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private DataContext context;

        public IEnumerable<Product> Products { get; set; }

        public IndexModel(DataContext context)
        {
            this.context = context;

        }
        public async Task OnGetAsync()
        {
            Products = context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier);
        }
    }
}
