using DansBlog.Controllers;
using DansBlog.DataAccess;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository;
using NUnit.Framework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web.Mvc;

namespace DansBlog.IntegrationTests.Controller_Repository_Data
{
    [TestFixture]
    public class SearchController_Should
    {
        private const string DbFile = "DansBlog.DataAccess.BlogDbContext";

        private BlogDbContext _dataContext;

        private SearchController _sut;

        private PostRepository _postRepository;

        private ViewMapper _viewMapper;


        [SetUp]
        public void InitTest()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new BlogDataInitializer());

            _dataContext = new BlogDbContext();
            _dataContext.Database.Initialize(true);
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

            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }
            _postRepository = null;
        }
    }
}
