using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Presentation.Controllers;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace DansBlog._IntegrationTests.Controller_Repository_Data
{
    [TestFixture]
    public class AdminController_Should
    {
        private const string DbFile = "DansBlog.DataAccess.BlogDbContext";

        private BlogDbContext _dataContext;
        
        private AdminController _sut;

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
            _sut = new AdminController(_postRepository, _viewMapper);
        }

        #region Index

        [Test]
        public void Index_ReturnTheCorrectCountOfPosts()
        {
            var viewResult = _sut.Index(1) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.AreEqual(10, model.Posts.TotalItemCount);
        }

        [Test]
        public void Index_ReturnAllPostsByDateDescendingOrder()
        {
            var viewResult = _sut.Index(1) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            var expected = new List<DateTime>
                {
                    new DateTime(2014, 1, 8),
                    new DateTime(2013, 12, 27),
                    new DateTime(2013, 12, 13),
                    new DateTime(2013, 12, 2),
                    new DateTime(2012, 11, 14),
                    new DateTime(2012, 11, 4),
                    new DateTime(2012, 11, 3),
                    new DateTime(2011, 10, 22),
                    new DateTime(2011, 10, 18),
                    new DateTime(2011, 10, 7),
                };

            IEnumerable<DateTime> result = model.Posts.Select(x => x.PublishDate);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        #endregion

        #region Details

        [Test]
        public void Details_ReturnThePostSpecifiedById()
        {
            var viewResult = _sut.Details(5) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(5, model.Id);
            Assert.AreEqual("Title 5", model.Title);
        }

        [Test]
        public void Details_ReturnPost1ByDefaultIfNoIdParamIsSpecified()
        {
            var viewResult = _sut.Details() as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Title 1", model.Title);
        }

        [Test]
        public void Details_ReturnHttpNotFoundIfIdParamIsNegative()
        {
            var viewResult = _sut.Details(-1) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Details_ReturnHttpNotFoundIfIdParamIsGreaterThanMaxId()
        {
            var viewResult = _sut.Details(25) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);    
        }

        #endregion

        #region Create get

        [Test]
        public void Create_ReturnOnePostWithAuthorPropertyInitCorrectlyToLoggedInUser()
        {
            var fakeContext = new Mock<ControllerContext>();
            fakeContext.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("Daniel Dutton");
            fakeContext.SetupGet(x => x.HttpContext.Request.IsAuthenticated).Returns(true);
            _sut.ControllerContext = fakeContext.Object;

            var viewResult = _sut.Create() as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual("Daniel Dutton", model.Author);
        }

        #endregion

        #region Create Post

        [Test]
        public void Create_AddANewPostToTheDatabase()
        {
            var newPost = new Post
                {
                    Author = "Daniel Dutton",
                    PublishDate = new DateTime(2013, 12, 24),
                    Title = "New Title",
                    Content = "New Content"
                };

            _sut.Create(newPost);
            var viewResult = _sut.Details(11) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(11, model.Id);
            Assert.AreEqual("New Title", model.Title);
            Assert.AreEqual("New Content", model.Content);
        }

        #endregion

        #region Edit Get

        [Test]
        public void EditGet_ReturnThePostSpecifiedById()
        {
            var viewResult = _sut.Edit(5) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(5, model.Id);
            Assert.AreEqual("Title 5", model.Title);
        }

        [Test]
        public void EditGet_ReturnPost1ByDefaultIfNoIdParamIsSpecified()
        {
            var viewResult = _sut.Edit() as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Title 1", model.Title);
        }

        [Test]
        public void EditGet_ReturnHttpNotFoundIfIdParamIsNegative()
        {
            var viewResult = _sut.Edit(-1) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void EditGet_ReturnHttpNotFoundIfIdParamIsGreaterThanMaxId()
        {
            var viewResult = _sut.Edit(25) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        #endregion

        #region Edit Post

        [Test]
        public void EditPost_UpdateAnAlreadyExistingPost()
        {
            var viewResult = _sut.Details(5) as ViewResult;
            var model = viewResult.Model as Post;

            model.Title = "New Title";
            model.Content = "New Content";

            _sut.Edit(model);

            var vresult = _sut.Details(5) as ViewResult;
            var resultModel = vresult.Model as Post;

            Assert.AreEqual("New Title", resultModel.Title);
            Assert.AreEqual("New Content", resultModel.Content);
        }

        #endregion

        #region Delete Get

        [Test]
        public void Delete_ReturnThePostSpecifiedById()
        {
            var viewResult = _sut.Delete(5) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(5, model.Id);
            Assert.AreEqual("Title 5", model.Title);
        }

        [Test]
        public void Delete_ReturnPost1ByDefaultIfNoIdParamIsSpecified()
        {
            var viewResult = _sut.Delete() as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Title 1", model.Title);
        }

        [Test]
        public void Delete_ReturnHttpNotFoundIfIdParamIsNegative()
        {
            var viewResult = _sut.Delete(-1) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Delete_ReturnHttpNotFoundIfIdParamIsGreaterThanMaxId()
        {
            var viewResult = _sut.Delete(25) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        #endregion

        #region Delete Confirmed

        [Test]
        public void DeleteConfirmed_DeleteARequestedItemById()
        {
           _sut.DeleteConfirmed(5);
           var vr = _sut.Details(5) as ViewResult;
           Post model = vr.Model as Post;
           Assert.AreEqual("test", model.Title);
        }

        [Test]
        public void DeleteConfirmed_ReturnHttpNotFoundIfIdDoesNotExist()
        {
            var viewResult = _sut.DeleteConfirmed(5) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        #endregion

        #region Moderate Get

        [Test]
        public void ModerateGet_ReturnCommentsForTheSpecifiedPostId()
        {
            var viewResult = _sut.Moderate(5) as ViewResult;
            var model = viewResult.Model as List<Comment>;

            Assert.AreEqual(5, model[0].PostId);
            Assert.AreEqual("Comment 5 Content", model[0].Content);
        }

        [Test]
        public void ModerateGet_ReturnCommentsForPost1ByDefaultIfNoIdParamIsSpecified()
        {
            var viewResult = _sut.Moderate() as ViewResult;
            var model = viewResult.Model as List<Comment>;

            Assert.AreEqual(1, model[0].PostId);
            Assert.AreEqual("Comment 1 Content", model[0].Content);
        }

        [Test]
        public void ModerateGet_ReturnHttpNotFoundIfIdParamIsNegative()
        {
            var viewResult = _sut.Moderate(-1) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void ModerateGet_ReturnHttpNotFoundIfIdParamIsGreaterThanMaxId()
        {
            var viewResult = _sut.Moderate(25) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        #endregion

        #region Moderate Post

        #endregion

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
