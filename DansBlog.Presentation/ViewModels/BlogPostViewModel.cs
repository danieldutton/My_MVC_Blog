using DansBlog.Model.Entities;
using PagedList;

namespace DansBlog.Presentation.ViewModels
{
    public class BlogPostViewModel
    {
        public PagedList<Post> Posts { get; set; }

        public bool LeaveComments { get; set; }

        public string ActionToInvoke { get; set; }

        public string SearchTerm { get; set; }

        public BlogPostViewModel()
        {
            SearchTerm = string.Empty;
        }
    }
}