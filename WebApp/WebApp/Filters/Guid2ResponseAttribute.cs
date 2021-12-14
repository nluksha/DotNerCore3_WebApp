﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApp.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class Guid2ResponseAttribute : Attribute, IAsyncAlwaysRunResultFilter
    {
        private int counter = 0;
        private string guid = Guid.NewGuid().ToString();

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Dictionary<string, string> result;

            if (context.Result is ViewResult vr && vr.ViewData.Model is Dictionary<string, string> data)
            {
                result = data;
            } else
            {
                result = new Dictionary<string, string>();
                context.Result = new ViewResult
                {
                    ViewName = "/Views/Shared/Message.cshtml",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = result
                    }
                };
            }

            while(result.ContainsKey($"Counter_{counter}"))
            {
                counter++;
            }

            result[$"Counter_{counter}"] = guid;

            await next();
        }
    }
}
