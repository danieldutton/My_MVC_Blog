using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DansBlog.Presentation.Controllers
{
    public class SearchController : ApplicationController
    {
        public SearchController(IPostRepository postRepository, IViewMapper viewMapper) 
            : base(postRepository, viewMapper)
        {
        }


        [ValidateInput(false)]
        public ActionResult Index(int? page, bool? leaveComments, string search = "blank")
        {
            List<Post> posts = PostRepository.Find(search);

            if (posts == null)
                return HttpNotFound();

            const int pageSize = 6;
            int pageNumber = (page ?? 1);
            BlogPostViewModel viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "Index", false, search);
            
            return View("ArchiveSearch", viewModel);
        }

    }
}
