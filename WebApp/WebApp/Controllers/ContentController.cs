using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private DataContext context;

        public ContentController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("string")]
        public string GetString() => "This is astring response";

        [HttpGet("object")]
        public async Task<Product> GetObject()
        {
            return await context.Products.FirstAsync();
        }
    }
}
