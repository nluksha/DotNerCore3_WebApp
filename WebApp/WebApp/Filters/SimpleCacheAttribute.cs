using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class SimpleCacheAttribute : Attribute, IResourceFilter
    {
        private Dictionary<PathString, IActionResult> cachedResponses = new Dictionary<PathString, IActionResult>();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            cachedResponses.Add(context.HttpContext.Request.Path, context.Result);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;

            if (cachedResponses.ContainsKey(path))
            {
                context.Result = cachedResponses[path];
                cachedResponses.Remove(path);
            }
        }
    }
}
