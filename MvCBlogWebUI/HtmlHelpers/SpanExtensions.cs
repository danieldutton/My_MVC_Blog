using System;
using System.Web.Mvc;

namespace DansBlog.Presentation.HtmlHelpers
{
    public static class SpanExtensions
    {
        public static string TagSpan(this HtmlHelper helper, string text)
        {
            var random = new Random();
            int i = random.Next(0, 6);

            return string.Format("<span class='tag-{0}'>{1}</span>", i, text);
        }
    }
}