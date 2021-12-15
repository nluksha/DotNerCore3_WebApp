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
    public class CreateModel : EditorPageModel
    {
        public CreateModel(DataContext context)
            : base(context) { }

        public void OnGet()
        {
            Product p = TempData.ContainsKey("product") ? JsonSerializer.Deserialize<Product>(TempData["product"] as string) : new Product();
            ViewModel = ViewModelFactory.Create(p, Categories, Suppliers);
        }

        public async Task<IActionResult> OnPostAsync([FromForm] Product product)
        {
            await CheckNewCategory(product);

            if (!ModelState.IsValid)
            {
                ViewModel = ViewModelFactory.Create(product, Categories, Suppliers);

                return Page();
            }

            product.ProductId = default;
            product.Category = default;
            product.Supplier = default;

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
