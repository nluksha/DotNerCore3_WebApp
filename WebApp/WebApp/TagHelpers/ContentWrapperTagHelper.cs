using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.TagHelpers
{
    [HtmlTargetElement("*", Attributes ="[wrap=true]")]
    public class ContentWrapperTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var el = new TagBuilder("div");
            el.Attributes["class"] = "bg-primary text-white p-2 m-2";
            el.InnerHtml.AppendHtml("Wrapper");

            output.PreElement.AppendHtml(el);
            output.PostElement.AppendHtml(el);
        }
    }
}
