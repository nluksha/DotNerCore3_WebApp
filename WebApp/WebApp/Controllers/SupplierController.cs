using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private DataContext context;

        public SupplierController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<Supplier> GetSupplier(long id)
        {
            Supplier supploer = await context.Suppliers.Include(s => s.Products).FirstAsync(s => s.SupplierId == id);

            foreach (var p in supploer.Products)
            {
                p.Supplier = null;
            }

            return supploer;
        }

        [HttpPatch("{id}")]
        public async Task<Supplier> PatchSupplier(long id, JsonPatchDocument<Supplier> patchDocument)
        {
            Supplier s = await context.Suppliers.FindAsync(id);

            if (s != null)
            {
                patchDocument.ApplyTo(s);
                await context.SaveChangesAsync();
            }

            return s;
        }
    }
}
