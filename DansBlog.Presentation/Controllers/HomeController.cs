using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using DansBlog.Services.Email.Interfaces;
using DansBlog.Services.Email.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace DansBlog.Presentation.Controllers
{   
    public class HomeController : ApplicationController
    {
        private readonly IViewMapper _viewMapper;

        public int PageSize = 5;

        public IEmailer MessagingService { get; private set; }


        public HomeController(IPostRepository postRepository, 
                              IEmailer messagingService,
                              IViewMapper viewMapper) 
            : base(postRepository, viewMapper)
        {
            _viewMapper = viewMapper;
            MessagingService = messagingService;
        }

        [OutputCache(Duration=1800, VaryByParam="page")]
        public ViewResult Index(int? page)
        {
            List<Post> posts = PostRepository.All;           

            BlogPostViewModel viewModel = _viewMapper.MapIndexViewModel(posts, page, PageSize, "Index", false);

            return View(viewModel);
        }
       
        public ViewResult About()
        {
            return View();
        }

        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ViewResult Archive()
        {
            IEnumerable<IGrouping<int, Post>> groupedPosts = PostRepository.PostsGroupedByYear();
            
            return View(groupedPosts);
        }

        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ViewResult TagCloud()
        {
            List<Tag> tags = PostRepository.GetDistinctTags();
            
            return View(tags);
        }
       
        public ActionResult FetchComments(int id = 1)
        {
            List<Comment> comments = PostRepository.GetModeratedPostComments(id);
                      
            if(Request.IsAjaxRequest())
                return PartialView(comments);

            return View("NonAjaxView", comments);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ViewResult LeaveComment(Comment comment)
        {
            comment.CreationTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                PostRepository.AddCommentToPost(comment, comment.PostId);

                MessagingService.Contact = new Contact
                    {
                        Name = comment.Author,
                        Email = comment.Email,
                        Message = comment.Content,
                        Subject = "comment to moderate post id: " + comment.PostId
                    };
                MessagingService.Message();
            }
            else
            {
                return View("_CommentSubmittedFailed");
            }

            return View("_CommentSubmitted");
        }

        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ViewResult TagSearch(int? page, string sort = "Programming")
        {
            ViewBag.Tag = sort;

            List<Post> posts = PostRepository.GetPostByTag(sort);
            
            const int pageSize = 5;
            int pageNumber = (page ?? 1);

            BlogPostViewModel viewModel = _viewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "TagSearch", false);

            return View("_BlogPost", viewModel);
        }

        public ViewResult Downloads()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MessagingService.Contact = contact;
                    MessagingService.Message();
                    
                    RedirectToAction("ContactConfirmed");
                }
                catch (Exception)
                {
                    RedirectToAction("ContactFailed");
                }
            }
            return View("ContactConfirmed");
        }

        public ViewResult ContactConfirmed()
        {
            return View("ContactConfirmed");
        }
        
        public ViewResult ContactFailed()
        {
            return View("ContactFailed");
        }

        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ViewResult CategorySearch(int? page, string search)
        {
            List<Post> posts = PostRepository.GetPostsByCategory(search);

            const int pageSize = 5;
            int pageNumber = (page ?? 1);

            var viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "CategorySearch", false);

            return View("_BlogPost", viewModel);
        }

        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ViewResult ArchiveSearch(int? page, int sort, int year)
        {
            List<Post> posts = PostRepository.GetPostsByDate(sort, year);

            int pageSize = int.Parse(ConfigurationManager.AppSettings["Archive_Partial_DisplayCount"]);
            int pageNumber = (page ?? 1);
            var viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "ArchiveSearch", false);

            return View("_BlogPost", viewModel);
        }

        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ViewResult Details(int? page, bool leaveComments, int postId = 0)
        {
            Post post = PostRepository.Find(postId);
            var posts = new List<Post> { post, };

            const int pageSize = 5;
            int pageNumber = (page ?? 1);

            var viewModel = ViewMapper.MapIndexViewModel(posts, pageNumber, pageSize, "Details", leaveComments);

            return View("_BlogPost", viewModel);
        }

        public ViewResult Error()
        {
            return View();
        }

    }
}
