using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;

        public HomeController(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            var p = await context.Products.FindAsync(id);

            if (p.CategoryId == 1)
            {
                return View("Watersports", p);
            }

            return View(p);
        }

        public IActionResult Common()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(context.Products);
        }
    }
}
