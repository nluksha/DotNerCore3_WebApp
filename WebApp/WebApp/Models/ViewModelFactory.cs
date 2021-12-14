using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public static class ViewModelFactory
    {
        public static ProductViewModel Details(Product p)
        {
            return new ProductViewModel
            {
                Product = p,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                Categories = p == null ? Enumerable.Empty<Category>() : new List<Category> { p.Category },
                Suppliers = p == null ? Enumerable.Empty<Supplier>() : new List<Supplier> { p.Supplier }
            };
        }
    }
}
