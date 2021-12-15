using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace WebApp.Pages
{
    public class EditModel : EditorPageModel
    {
        public EditModel(DataContext context)
            : base(context) { }

        public async Task OnGetAsync(long id)
        {
            Product p = TempData.ContainsKey("product")
                ? JsonSerializer.Deserialize<Product>(TempData["product"] as string)
                : await context.Products.FindAsync(id);
            ViewModel = ViewModelFactory.Edit(p, Categories, Suppliers);
        }

        public async Task<IActionResult> OnPostAsync([FromForm] Product product)
        {
            await CheckNewCategory(product);

            if (!ModelState.IsValid)
            {
                ViewModel = ViewModelFactory.Edit(product, Categories, Suppliers);
                return Page();
            }

            product.Category = default;
            product.Supplier = default;

            context.Products.Update(product);
            await context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
