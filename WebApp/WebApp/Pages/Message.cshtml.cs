using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Filters;

namespace WebApp.Pages
{
    [RequireHttps]
    [SimpleCache]
    public class MessageModel : PageModel
    {
        public object Message { get; set; } = $"{DateTime.Now.ToLocalTime()} This is the Message Razor Page";
        public void OnGet()
        {
        }
    }
}
