using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.TagHelpers
{
    public class TimeTagHelperComponent: TagHelperComponent
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var timestamp = DateTime.Now.ToLongTimeString();

            if (output.TagName == "body")
            {
                var el = new TagBuilder("div");
                el.Attributes.Add("class", "bg-info text-white m-2 p-2");
                el.InnerHtml.Append($"Time: {timestamp}");

                output.PreContent.AppendHtml(el);
            }
        }
    }
}
