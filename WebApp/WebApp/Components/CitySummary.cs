using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Components
{
    public class CitySummary: ViewComponent
    {
        private CitiesData data;

        public CitySummary(CitiesData data)
        {
            this.data = data;
        }

        public IViewComponentResult Invoke(string themeName)
        {
            ViewBag.Theme = themeName;

            return View(new CityViewModel
            {
                Cities = data.Cities.Count(),
                Population = data.Cities.Sum(c => c.Population)
            });
        }
    }
}
