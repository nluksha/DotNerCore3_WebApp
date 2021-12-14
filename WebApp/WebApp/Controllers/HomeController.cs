using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private DataContext context;
        private IEnumerable<Category> Categories => context.Categories;
        private IEnumerable<Supplier> Supplier => context.Suppliers;

        public HomeController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Products.Include(p => p.Category).Include(p => p.Supplier));
        }

        public async Task<IActionResult> Details(long id)
        {
            Product p = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            ProductViewModel model = ViewModelFactory.Details(p);

            return View("ProductEditor", model);
        }

        public IActionResult Create()
        {
            return View("ProductEditor", ViewModelFactory.Create(new Product(), Categories, Supplier));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductEditor", ViewModelFactory.Create(product, Categories, Supplier));
            }

            product.ProductId = default;
            product.Category = default;
            product.Supplier = default;

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
