using DansBlog.Model.Entities;
using DansBlog.Presentation.ViewModels;
using System.Collections.Generic;

namespace DansBlog.Presentation.Mappers
{
    public interface IViewMapper
    {
        BlogPostViewModel MapIndexViewModel(List<Post> posts, int? pageNo, int pageSize, string actionToInvoke, bool LeaveComment, string searchTerm = "");
    }
}
