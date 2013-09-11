using DansBlog.Model.Entities;
using DansBlog.Presentation.ViewModels;
using PagedList;
using System.Collections.Generic;

namespace DansBlog.Presentation.Mappers
{
    public class ViewMapper : IViewMapper
    {
        public BlogPostViewModel MapIndexViewModel(List<Post> posts, int? pageNo, int pageSize, string actionToInvoke, bool leaveComment, string searchTerm="")
        {
            int pageNumber = (pageNo ?? 1);
            if (pageNumber < 1) pageNumber = 1;

            var pagedList = new PagedList<Post>(posts, pageNumber, pageSize);

            var model = new BlogPostViewModel
            {
                ActionToInvoke = actionToInvoke,
                LeaveComments = leaveComment,
                Posts = pagedList,
                SearchTerm = searchTerm,
            };
            return model;
        }
    }
}