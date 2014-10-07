using System.Collections.Generic;
using DansBlog.Model.Entities;
using DansBlog.ViewModels;

namespace DansBlog.Mappers
{
    public interface IViewMapper
    {
        BlogPostViewModel MapIndexViewModel(List<Post> posts, int? pageNo, int pageSize, string actionToInvoke, bool LeaveComment, string searchTerm = "");
    }
}
