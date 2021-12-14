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
    public class DeleteModel : EditorPageModel
    {
        public DeleteModel(DataContext context)
            : base(context) { }

        public async Task OnGetAsync(long id)
        {
            Product p = await context.Products.FindAsync(id);
            ViewModel = ViewModelFactory.Delete(p, Categories, Suppliers);
        }

        public async Task<IActionResult> OnPostAsync([FromForm] Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
