using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages
{
    public class EditorPageModel: PageModel
    {
        protected DataContext context;

        public IEnumerable<Category> Categories => context.Categories;
        public IEnumerable<Supplier> Suppliers => context.Suppliers;
        public ProductViewModel ViewModel { get; set; }

        public EditorPageModel(DataContext context)
        {
            this.context = context;
        }
    }
}
