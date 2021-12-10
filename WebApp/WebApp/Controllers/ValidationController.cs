using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private DataContext dataContext;

        public ValidationController(DataContext context)
        {
            dataContext = context;
        }

        [HttpGet("categoryKey")]
        public bool CategoryKey(string categoryId)
        {
            long key;

            return long.TryParse(categoryId, out key) && dataContext.Categories.Find(key) != null;
        }

        [HttpGet("supplierKey")]
        public bool SupplierKey(string supplierId)
        {
            long key;

            return long.TryParse(supplierId, out key) && dataContext.Suppliers.Find(key) != null;
        }
    }
}
