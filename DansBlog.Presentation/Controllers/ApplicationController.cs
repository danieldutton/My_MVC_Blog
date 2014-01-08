using DansBlog.Model.Domain;
using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.ViewModel;
using DansBlog.Utilities.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace DansBlog.Presentation.Controllers
{
    [HandleError]
    public class ApplicationController : Controller
    {
        [Inject]
        public IQuoteRepository<Quote> QuoteRepository { get; set; }

        [Inject]
        public ICategoryRepository CategoryRepository { get; set; }

        [Inject]
        public IArchiver Archiver { get; set; }

        [Inject]
        public ICurrentDateTime CurrentDateTime { get; set; }

        private readonly IPostRepository _postRepository;

        protected IPostRepository PostRepository
        {
            get { return _postRepository; }
        }

        private readonly IViewMapper _viewMapper;

        protected IViewMapper ViewMapper
        {
            get { return _viewMapper; }
        }


        public ApplicationController(IPostRepository postRepository,
                                     IViewMapper viewMapper)
        {
            _postRepository = postRepository;
            _viewMapper = viewMapper;
        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string filePath = Server.MapPath(ConfigurationManager.AppSettings["Quote_Partial_XmlFilePath"]);
            Quote quote = QuoteRepository.GetRandomQuote(filePath);

            int categoryCount = int.Parse(ConfigurationManager.AppSettings["Category_Partial_DisplayCount"]);
            List<Category> categories = CategoryRepository.MostPopularCategories(categoryCount);

            int displayCount = int.Parse(ConfigurationManager.AppSettings["Archive_Partial_DisplayCount"]);

            List<Archive> archivedMonths = Archiver.GetArchivedMonths(DateTime.Now, displayCount, _postRepository.All);

            var masterLayout = new MasterLayout
                {
                    ArchivedMonths = archivedMonths,
                    Categories = categories,
                    QuoteOfTheDay = quote
                };

            ViewBag.Layout = masterLayout;

            base.OnActionExecuted(filterContext);
        }
    }
}