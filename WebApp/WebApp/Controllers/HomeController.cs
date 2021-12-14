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
    }
}
