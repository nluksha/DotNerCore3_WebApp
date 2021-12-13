using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class Simple2CacheAttribute : Attribute, IAsyncResourceFilter
    {
        private Dictionary<PathString, IActionResult> cachedResponses = new Dictionary<PathString, IActionResult>();

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var path = context.HttpContext.Request.Path;

            if (cachedResponses.ContainsKey(path))
            {
                context.Result = cachedResponses[path];
                cachedResponses.Remove(path);
            } else
            {
                var execContext = await next();
                cachedResponses.Add(context.HttpContext.Request.Path, execContext.Result);
            }
        }
    }
}
