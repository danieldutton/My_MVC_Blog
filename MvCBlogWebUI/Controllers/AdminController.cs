using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DansBlog.Presentation.Controllers
{   [HandleError]
    [Authorize]
    public class AdminController : ApplicationController
    {
        public AdminController(IPostRepository postRepository, IViewMapper viewMapper) 
            : base(postRepository, viewMapper)
        {
        }

        public ActionResult Index(int? page)
        {
            var posts = PostRepository.All;
            
            const int pageSize = 28;
            int pageNumber = (page ?? 1);
            
            BlogPostViewModel viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "Index", false);

            return View(viewModel);
        }

        public ActionResult Details(int id = 0)
        {
            Post post = PostRepository.Find(id);
            
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Create(){

            var post = new Post {Author = User.Identity.Name};
            
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

        public ActionResult Edit(int id = 0)
        {
            Post post = PostRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
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

        public ActionResult Delete(int id = 0)
        {
            Post post = PostRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = PostRepository.Find(id);
            PostRepository.Delete(post);

            return RedirectToAction("Index");
        }

        public ViewResult Moderate(int id)
        {
            List<Comment> comments = PostRepository.GetUnModeratedPostComments(id);
            return View(comments);
        }

        [HttpPost]
        public ActionResult Moderate(List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                if (comment.HasBeenModerated)
                {
                    comment.HasBeenModerated = true;
                }
                   PostRepository.AddModeratedCommentToPost(comment, comment.PostId);
            }
            return View("ModerationSucessfull");
        }
    }
}