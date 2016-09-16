using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
 
namespace wwwmy.HtmlHelpers
{
    public static class TestHtmlHelper
    {
        public static HtmlString CreateString(this IHtmlHelper html, string item)
        {
            return new HtmlString($"<h4>TestHtmlHelper</h4><div>{item}</div>");
        }
    }
}