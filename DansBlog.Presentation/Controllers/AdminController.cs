using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DansBlog.Presentation.Controllers
{   
    [Authorize]
    public class AdminController : ApplicationController
    {
        public AdminController(IPostRepository postRepository, IViewMapper viewMapper) 
            : base(postRepository, viewMapper)
        {
        }

        public ActionResult Index(int? page)
        {
            List<Post> posts = PostRepository.All;

            if(posts == null)
                return HttpNotFound();
            
            const int pageSize = 28;
            int pageNumber = (page ?? 1);
            
            BlogPostViewModel viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "Index", false);

            return View(viewModel);
        }

        public ActionResult Details(int id = 1)
        {
            Post post = PostRepository.Find(id);
            
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        public ActionResult Create(){

            var post = new Post { Author = User.Identity.Name };
            
            return View(post);
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                PostRepository.Add(post);
                return RedirectToAction("Index");
            }

            return View(post);
        }

        public ActionResult Edit(int id = 1)
        {
            Post post = PostRepository.Find(id);
            
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                PostRepository.Update(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public ActionResult Delete(int id = 1)
        {
            Post post = PostRepository.Find(id);
            
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = PostRepository.Find(id);

            if (post == null)
                return HttpNotFound();

            PostRepository.Delete(post);

            return RedirectToAction("Index");
        }

        public ActionResult Moderate(int id = 1)
        {
            List<Comment> comments = PostRepository.GetUnModeratedPostComments(id);

            if (comments == null)
                return HttpNotFound();

            return View(comments);
        }

        [HttpPost]
        public ActionResult Moderate(List<Comment> comments)
        {
            if (comments == null) return HttpNotFound();

            foreach (var comment in comments)
            {
                if (!comment.HasBeenModerated)
                {
                    comment.HasBeenModerated = true;
                }
                   PostRepository.AddModeratedCommentToPost(comment, comment.PostId);
            }
            return View("ModerationSucessfull");
        }

        public JsonResult AutoCompleteCategory(string term)
        {
            List<string> result = CategoryRepository.SearchForCategories(term);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}