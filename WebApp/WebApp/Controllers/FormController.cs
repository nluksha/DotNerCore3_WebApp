using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private DataContext context;

        public FormController(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(long? id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => id == null || p.ProductId == id);

            return View("Form", product);
        }

        [HttpPost]
        public IActionResult SubmitForm(Product product)
        {
            TempData["name"] = product.Name;
            TempData["price"] = product.Price.ToString();
            TempData["CategoryId"] = product.CategoryId.ToString();
            TempData["SupplierId"] = product.SupplierId.ToString();

            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View(TempData);
        }
    }
}
