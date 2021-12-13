using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [RequireHttps]
    public class MessageModel : PageModel
    {
        public object Message { get; set; } = "This is the Message Razor Page";
        public void OnGet()
        {
        }
    }
}
