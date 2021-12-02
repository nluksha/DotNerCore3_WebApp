using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages.Suppliers
{
    public class ListModel : PageModel
    {
        private DataContext context;

        public IEnumerable<string> Suppliers { get; set; }

        public ListModel(DataContext context)
        {
            this.context = context;
        }

        public void OnGetAsync(long id = 1)
        {
            Suppliers = context.Suppliers.Select(s => s.Name);
        }
    }
}
