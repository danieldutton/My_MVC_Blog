using System.Web;
using System.Web.Mvc;

namespace DansBlog.HtmlHelpers
{
    public static class CommentHelperExtension
    {
        public static HtmlString Foo(this HtmlHelper h, string attr, string id, string tagElement)
        {           
            var tBuilder = new TagBuilder(tagElement);
            tBuilder.GenerateId(attr + id);
            var c = new HtmlString(tBuilder.ToString());
            return c;
        }
    }
}