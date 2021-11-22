using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext context;

        public ProductsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        [HttpGet("{id}")]
        public Product GetProduct([FromServices] ILogger<ProductsController> logger)
        {
            logger.LogDebug("GetProduct Action Invoked");

            return context.Products.FirstOrDefault();
        }
    }
}
