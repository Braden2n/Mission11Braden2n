using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11BradenToone.Models;

namespace Mission11BradenToone.Infrastructure;

[HtmlTargetElement("div", Attributes="pagination")]
public class PaginationTagHelper(IUrlHelperFactory factory) : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }
    public string? PageAction { get; set; }
    public Pagination? Pagination { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && Pagination != null)
        {
            IUrlHelper urlHelper = factory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= Pagination.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a")
                {
                    Attributes =
                    {
                        ["href"] = urlHelper.Action(PageAction, new { pageNum = i })
                    }
                };
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
                if (i != Pagination.TotalPages)
                {
                    result.InnerHtml.Append(", ");
                }
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}