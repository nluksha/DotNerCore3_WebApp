using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class Home2Controller : Controller
    {
        private DataContext context;

        public Home2Controller(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            var p = await context.Products.FindAsync(id);
            ViewBag.AveragePrice = await context.Products.AverageAsync(p => p.Price);

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
