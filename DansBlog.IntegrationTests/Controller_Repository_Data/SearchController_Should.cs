using DansBlog.Controllers;
using DansBlog.DataAccess;
using DansBlog.Mappers;
using DansBlog.Repository;
using DansBlog.ViewModels;
using NUnit.Framework;
using System.Web.Mvc;

namespace DansBlog.IntegrationTests.Controller_Repository_Data
{
    [TestFixture]
    public class SearchController_Should
    {
        private BlogDbContext _dataContext;

        private SearchController _sut;

        private PostRepository _postRepository;

        private ViewMapper _viewMapper;


        [SetUp]
        public void InitTest()
        {
            _dataContext = new BlogDbContext();
            _postRepository = new PostRepository(_dataContext);
            _viewMapper = new ViewMapper();
            _sut = new SearchController(_postRepository, _viewMapper);
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            var viewResult = _sut.Index(1, false, "Lorem Ipsum") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<BlogPostViewModel>(model);
        }

        [Test]
        public void Index_ReturnCorrectSearchResults_MatchingCase()
        {
            var viewResult = _sut.Index(1, false, "Lorem ipsum") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(10, model.Posts.TotalItemCount);   
        }

        [Test]
        public void Index_Return6ItemsPerPage()
        {
            var viewResult = _sut.Index(1, false, "Lorem ipsum") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(6, model.Posts.PageSize);    
        }

        [Test]
        public void Index_ReturnTheOriginalSearchTermInTheModel()
        {
            var viewResult = _sut.Index(1, false, "Lorem ipsum") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual("Lorem ipsum", model.SearchTerm);   
        }

        [Test]
        public void Index_ReturnCorrectSearchResults_AllLowerCase()
        {
            var viewResult = _sut.Index(1, false, "lorem ipsum") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(10, model.Posts.TotalItemCount); 
        }

        [Test]
        public void Index_ReturnCorrectSearchResults_AllUpperCase()
        {
            var viewResult = _sut.Index(1, false, "LOREM IPSUM") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(10, model.Posts.TotalItemCount); 
        }

        [Test]
        public void Index_ReturnCorrectSearchResults_MixedCase()
        {
            var viewResult = _sut.Index(1, false, "LoREm iPSUm") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(10, model.Posts.TotalItemCount); 
        }

        [Test]
        public void Index_ReturnNoResultsWhereAResultDoesNotExist()
        {
            var viewResult = _sut.Index(1, false, "crazynonexistanttext") as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(0, model.Posts.TotalItemCount);
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Dispose();
            _postRepository = null;
        }
    }
}
