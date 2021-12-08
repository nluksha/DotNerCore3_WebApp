﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");

            var product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstAsync(p => p.ProductId == id);

            return View("Form", product);
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach (var key in Request.Form.Keys)
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }

            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View(TempData);
        }
    }
}
