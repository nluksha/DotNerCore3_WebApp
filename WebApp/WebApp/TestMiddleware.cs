﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApp.Models;

namespace WebApp
{
    public class TestMiddleware
    {
        private RequestDelegate next;

        public TestMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DataContext dataContext)
        {
            if (context.Request.Path == "/test")
            {
                await context.Response.WriteAsync($"There are {dataContext.Products.Count()} products\n");
                await context.Response.WriteAsync($"There are {dataContext.Categories.Count()} categories\n");
                await context.Response.WriteAsync($"There are {dataContext.Suppliers.Count()} suppliers\n");
            } else
            {
                await next(context);
            }
        }
    }
}
