using System.Collections.Generic;
using DansBlog.Model.Entities;
using DansBlog.Presentation.ViewModels;

namespace DansBlog.Presentation.Mappers
{
    public interface IViewMapper
    {
        BlogPostViewModel MapIndexViewModel(List<Post> posts, int? pageNo, int pageSize, string actionToInvoke, bool LeaveComment, string searchTerm = "");
    }
}
