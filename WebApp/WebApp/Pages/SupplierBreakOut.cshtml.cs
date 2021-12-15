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
    public class SupplierBreakOutModel : PageModel
    {
        private DataContext context;

        [BindProperty]
        public Supplier Supplier { get; set; }
        public string ReturnPage { get; set; }
        public string ProductId { get; set; }

        public SupplierBreakOutModel(DataContext context)
        {
            this.context = context;
        }




        public void OnGet([FromQuery(Name = "Product")] Product product, string returnPage)
        {
            TempData["product"] = Serialize(product);
            TempData["returnAction"] = ReturnPage = returnPage;
            TempData["productId"] = ProductId = product.ProductId.ToString();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            context.Suppliers.Add(Supplier);
            await context.SaveChangesAsync();

            Product product = Deserialize(TempData["product"] as string);
            product.SupplierId = Supplier.SupplierId;
            TempData["product"] = Serialize(product);

            string id = TempData["productId"] as string;

            return RedirectToPage(TempData["returnAction"] as string, new { id = id });
        }

        private string Serialize(Product product) => JsonSerializer.Serialize(product);

        private Product Deserialize(string json) => JsonSerializer.Deserialize<Product>(json);
    }
}
