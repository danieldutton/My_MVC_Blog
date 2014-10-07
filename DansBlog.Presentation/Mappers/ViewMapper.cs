using DansBlog.Model.Entities;
using DansBlog.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;

namespace DansBlog.Mappers
{
    public class ViewMapper : IViewMapper
    {
        public BlogPostViewModel MapIndexViewModel(List<Post> posts, int? pageNo, int pageSize, string actionToInvoke, bool leaveComment, string searchTerm="")
        {
            if (posts == null) throw new ArgumentNullException();

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