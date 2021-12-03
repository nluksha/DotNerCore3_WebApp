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

        public string Invoke()
        {
            return $"{data.Cities.Count()} cites, {data.Cities.Sum(c => c.Population)} people";
        }
    }
}
