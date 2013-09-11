using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DansBlog.Presentation.Controllers
{
    [HandleError]
    public class SearchController : ApplicationController
    {
        #region Constructor(s)

        public SearchController(IPostRepository postRepository, IViewMapper viewMapper) 
            : base(postRepository, viewMapper)
        {
        }

        #endregion

        #region Action(s)

        [ValidateInput(false)]
        public ViewResult Index(int? page, bool? leaveComments, string search = "blank")
        {
            List<Post> posts = PostRepository.Find(search);

            const int pageSize = 6;
            int pageNumber = (page ?? 1);
            var viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "Index", false, search);
            
            return View("ArchiveSearch", viewModel);
        }

        #endregion
    }
}
