using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebApp.Components
{
    public class PageSize: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://apress.com");

            return View(response.Content.Headers.ContentLength);
        }
    }
}
