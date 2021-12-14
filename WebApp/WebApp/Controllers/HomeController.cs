using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [HttpsOnly]
    [ResultDiagnostics]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Message", "This is the Index action on the Home controller");
        }

        public IActionResult Secure()
        {
            return View("Message", "This is the Secure action on the Home controller");
        }

        [ChangeArg]
        public IActionResult Messages(string message1, string message2 = "None")
        {
            return View("Message", $"{message1}, {message2}");
        }

        [RangeException]
        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            } else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            } else
            {
                return View("Message", $"THe value id {id}");
            }
        }
    }
}
