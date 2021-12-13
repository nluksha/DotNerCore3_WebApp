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
    public class ResultDiagnosticsAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.HttpContext.Request.Query.ContainsKey("diag"))
            {
                var diagData = new Dictionary<string, string>
                {
                    {"Result type", context.Result.GetType().Name}
                };

                if (context.Result is ViewResult vr)
                {
                    diagData["View Name"] = vr.ViewName;
                    diagData["Model Type"] = vr.ViewData.Model.GetType().Name;
                    diagData["Model Data"] = vr.ViewData.Model.ToString();
                } else if (context.Result is PageResult pr)
                {
                    diagData["View Name"] = pr.Model.GetType().Name;
                    diagData["Model Type"] = pr.ViewData.Model.ToString();
                }

                context.Result = new ViewResult
                {
                    ViewName = "/Views/Shared/Message.cshtml",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = diagData
                    }
                };
            }

            await next();
        }
    }
}
