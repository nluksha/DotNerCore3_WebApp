using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class DetailsModel : EditorPageModel
    {
        public DetailsModel(DataContext context)
            : base(context) { }

        public async Task OnGetAsync(long id)
        {
            Product p = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            ViewModel = ViewModelFactory.Details(p);
        }
    }
}
