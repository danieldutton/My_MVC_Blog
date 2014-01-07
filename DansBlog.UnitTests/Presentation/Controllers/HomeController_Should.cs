using System;
using DansBlog.Model.Entities;
using DansBlog.Presentation.Controllers;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using DansBlog.Services.Email.Interfaces;
using DansBlog.Services.Email.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DansBlog._UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class HomeController_Should
    {
        private Mock<IPostRepository> _fakePostRepo;

        private Mock<IEmailer> _fakeEmailer;

        private Mock<IViewMapper> _fakeViewMapper;

        private List<Post> _posts;

        private HomeController _sut;


        [SetUp]
        public void Init()
        {
            _fakePostRepo = new Mock<IPostRepository>();
            _fakeEmailer = new Mock<IEmailer>();
            _fakeViewMapper = new Mock<IViewMapper>();
            _posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
            _sut = new HomeController(_fakePostRepo.Object, _fakeEmailer.Object, _fakeViewMapper.Object);
        }

        [Test]
        public void Index_Call_All_ExactlyOnce()
        {
            _sut.Index(1);

            _fakePostRepo.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void Index__ReturnHttpNotFound_If_All_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.All).Returns(() => null);

            var viewResult = _sut.Index(1) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Index_Call_MapIndexViewModel_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(1);

            _fakeViewMapper.Verify(
                x =>
                x.MapIndexViewModel(It.Is<List<Post>>(y => y.Equals(_posts)), It.Is<int>(y => y == 1),
                                    It.Is<int>(y => y == 5),It.IsAny<string>(), 
                                    It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Index_CallMethod_MapIndexViewModel_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(1);

            _fakeViewMapper.Verify(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                                            It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()),
                                   Times.Once());
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            var viewResult = _sut.Index(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            _fakeViewMapper.Setup(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                                           It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()))
                           .Returns(() => new BlogPostViewModel());

            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            var viewResult = _sut.Index(1) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf(typeof (BlogPostViewModel), model);
        }

        [Test]
        public void About_ReturnTheCorrectView()
        {
            ViewResult viewResult = _sut.About();

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Archive_CallMethod_PostsGroupedByYear_ExactlyOnce()
        {
            _sut.Archive();

            _fakePostRepo.Verify(x => x.PostsGroupedByYear(), Times.Once());
        }

        [Test]
        public void Archive_ReturnHttpNotFound_If_PostsGroupedByYear_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.PostsGroupedByYear()).Returns(() => null);

            var viewResult = _sut.Archive() as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Archive_ReturnTheCorrectView()
        {
            var viewResult = _sut.Archive() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Archive_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.PostsGroupedByYear()).Returns(new List<IGrouping<int, Post>>());

            var viewResult = _sut.Archive() as ViewResult;
            var expected = viewResult.Model as List<IGrouping<int, Post>>;

            Assert.IsInstanceOf<List<IGrouping<int, Post>>>(expected);
        }

        [Test]
        public void TagCloud_CallMethod_GetDistinctTags_ExactlyOnce()
        {
            _sut.TagCloud();

            _fakePostRepo.Verify(x => x.GetDistinctTags(), Times.Once());
        }

        [Test]
        public void TagCloud_ReturnTheCorrectView()
        {
            ViewResult viewResult = _sut.TagCloud();

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void TagCloud_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.GetDistinctTags()).Returns(() => new List<Tag>());

            var model = _sut.TagCloud().Model as List<Tag>;

            Assert.IsInstanceOf<List<Tag>>(model);
        }

        [Test]
        public void FetchComments_SetIDParamTo_1_IfNoneGiven()
        {
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);

            _sut.FetchComments();

            _fakePostRepo.Verify(x => x.GetModeratedPostComments(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void FetchComments_CallMethod_GetModeratedPostComments_ExactlyOnce()
        {
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);

            _sut.FetchComments();

            _fakePostRepo.Verify(x => x.GetModeratedPostComments(1), Times.Once());
        }

        [Test]
        public void FetchComments_ReturnTheCorrectView_IfAjaxRequest()
        {
            var request = new Mock<HttpRequestBase>();

            request.SetupGet(x => x.Headers).Returns(
                new WebHeaderCollection
                    {
                        {"X-Requested-With", "XMLHttpRequest"}
                    });

            var context = new Mock<HttpContextBase>();

            context.SetupGet(x => x.Request).Returns(request.Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);

            var viewResult = _sut.FetchComments() as PartialViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void FetchComments_ReturnTheCorrectModelType_IfAjaxRequest()
        {
            _fakePostRepo.Setup(x => x.GetModeratedPostComments(It.IsAny<int>())).Returns(() => new List<Comment>());
            var request = new Mock<HttpRequestBase>();

            request.SetupGet(x => x.Headers).Returns( //add in mother class utility method
                new WebHeaderCollection
                    {
                        {"X-Requested-With", "XMLHttpRequest"}
                    });

            var context = new Mock<HttpContextBase>();

            context.SetupGet(x => x.Request).Returns(request.Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);

            var viewResult = _sut.FetchComments() as PartialViewResult;
            var model = viewResult.Model as List<Comment>;

            Assert.IsInstanceOf<List<Comment>>(model);
        }

        [Test]
        public void FetchComments_ReturnTheCorrectView_IfNormalRequest()
        {
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();

            context.SetupGet(x => x.Request).Returns(request.Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);

            var viewResult = _sut.FetchComments() as ViewResult;

            Assert.AreEqual("NonAjaxView", viewResult.ViewName);
        }

        [Test]
        public void FetchComments_ReturnTheCorrectModelType_IfNormalRequest()
        {
            _fakePostRepo.Setup(x => x.GetModeratedPostComments(It.IsAny<int>())).Returns(() => new List<Comment>());
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();

            context.SetupGet(x => x.Request).Returns(request.Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);

            var viewResult = _sut.FetchComments() as ViewResult;
            var model = viewResult.Model as List<Comment>;

            Assert.IsInstanceOf<List<Comment>>(model);
        }

        [Test]
        public void LeaveComment_CallMethod_AddCommentToPost_ExactlyOnce_IfModelStateIsValid()
        {
            var commentStub = new Comment();

            _sut.LeaveComment(commentStub);

            _fakePostRepo.Verify(x => x.AddCommentToPost(It.IsAny<Comment>(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void LeaveComment_PassTheCorrectCommentDataToAddCommentToPost_IfModelStateIsValid()
        {
            var commentStub = new Comment {PostId = 5};

            _sut.LeaveComment(commentStub);

            _fakePostRepo.Verify(
                x => x.AddCommentToPost(It.Is<Comment>(c => c.Equals(commentStub)), It.Is<int>(i => i == 5)),
                Times.Once());
        }

        [Test]
        public void LeaveComment_Call_Contact_ExactlyOnce_IfModelStateIsValid()
        {
            var commentStub = new Comment();

            _sut.LeaveComment(commentStub);

            _fakeEmailer.VerifySet(x => x.Contact = It.IsAny<Contact>(), Times.Once());
        }

        [Test]
        public void LeaveComment_Call_Message_ExactlyOnce()
        {
            var commentStub = new Comment();

            _sut.LeaveComment(commentStub);

            _fakeEmailer.Verify(x => x.Message(), Times.Once());
        }

        [Test]
        public void LeaveComment_ReturnTheCorrectView_IfModelStateIsValid()
        {
            var commentStub = new Comment();

            var viewResult = _sut.LeaveComment(commentStub);

            Assert.AreEqual("_CommentSubmitted", viewResult.ViewName);
        }

        [Test]
        public void LeaveComment_ReturnTheCorrectView_IfModelStateIsNotValid()
        {
            var commentStub = new Comment();
            _sut.ModelState.AddModelError("", "");

            var viewResult = _sut.LeaveComment(commentStub);

            Assert.AreEqual("_CommentSubmittedFailed", viewResult.ViewName);
        }

        [Test]
        public void TagSearch_UseDefaultSearchTerm_IfNonSpecified()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(new List<Post>());

            _sut.TagSearch(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.GetPostByTag(It.Is<string>(y => y == "Programming")));
        }

        [Test]
        public void TagSearch_PassCorrectSortValueToViewBag()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);

            var viewResult = _sut.TagSearch(It.IsAny<int>(), "Test Value") as ViewResult;
            var actual = viewResult.ViewData["Tag"];

            Assert.AreEqual("Test Value", actual);
        }

        [Test]
        public void TagSearch_Call_GetPostByTag_ExactlyOnce()
        {
            _sut.TagSearch(It.IsAny<int>(), It.IsAny<string>());

            _fakePostRepo.Verify(x => x.GetPostByTag(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void TagSearch__Call_GetPostByTag_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(new List<Post>());

            _sut.TagSearch(It.IsAny<int>(), "Test Value");

            _fakePostRepo.Verify(x => x.GetPostByTag(It.Is<string>(y => y == "Test Value")));
        }

        [Test]
        public void TagSearch_ReturnHttpNotFound_If_GetPostByTag_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(() => null);

            var viewResult = _sut.TagSearch(It.IsAny<int>(), It.IsAny<string>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void TagSearch_SetCorrectPageSize()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);

            _sut.TagSearch(It.IsAny<int>(), It.IsAny<string>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.Is<int>(y => y == 5),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void TagSearch__SetPageNoTo_1_IfNullParamIsProvided()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);

            _sut.TagSearch(null, It.IsAny<string>());

            _fakeViewMapper.Verify
                (x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(i => i == 1),
                                          It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void TagSearch_Call_MapIndexViewModel_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);

            _sut.TagSearch(It.IsAny<int>(), It.IsAny<string>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel
                         (It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>(),
                          It.IsAny<string>()),
                Times.Once());
        }

        [Test]
        public void TagSearch_Call_MapIndexViewModel_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);

            _sut.TagSearch(1, "Test Value");

            _fakeViewMapper.Verify(
                x =>
                x.MapIndexViewModel(It.Is<List<Post>>(y => y.Equals(_posts)), It.Is<int>(y => y == 1),
                                    It.Is<int>(y => y == 5), It.Is<string>(p => p == "TagSearch"), It.IsAny<bool>(),
                                    It.IsAny<string>()));
        }

        [Test]
        public void TagSearch_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);

            var viewResult = _sut.TagSearch(It.IsAny<int>(), It.IsAny<string>()) as ViewResult;

            Assert.AreEqual("_BlogPost", viewResult.ViewName);
        }

        [Test]
        public void TagSearch_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.GetPostByTag(It.IsAny<string>())).Returns(_posts);
            _fakeViewMapper.Setup(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                                           It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()))
                           .Returns(() => new BlogPostViewModel());

            var viewResult = _sut.TagSearch(It.IsAny<int>(), It.IsAny<string>()) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<BlogPostViewModel>(model);
        }

        [Test]
        public void Downloads_ReturnTheCorrectView()
        {
            var sut = new HomeController(_fakePostRepo.Object, _fakeEmailer.Object, _fakeViewMapper.Object);

            ViewResult viewResult = sut.Downloads();

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Contact_ReturnTheCorrectView()
        {
            var sut = new HomeController(_fakePostRepo.Object, _fakeEmailer.Object, _fakeViewMapper.Object);

            ViewResult viewResult = sut.Contact();

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Contact_Post_Call_Contact_Once_IfModelStateIsValid()
        {
            _sut.Contact(It.IsAny<Contact>());

            _fakeEmailer.VerifySet(x => x.Contact = It.IsAny<Contact>(), Times.Once());
        }

        [Test]
        public void Contact_Post_InitContactPropertyWithTheCorrectData()
        {
            var contactStub = new Contact();

            _sut.Contact(contactStub);

            _fakeEmailer.VerifySet(x => x.Contact = It.Is<Contact>(c => c.Equals(contactStub)));
        }

        [Test]
        public void Contact_Post_Call_Message_ExactlyOnce()
        {
            _sut.Contact(It.IsAny<Contact>());

            _fakeEmailer.Verify(x => x.Message(), Times.Once());
        }

        [Test]
        public void Contact_Post_RedirectToTheCorrectAction_IfModelStateIsValid()
        {
            var redirectResult = (RedirectToRouteResult) _sut.Contact(It.IsAny<Contact>());

            Assert.That(redirectResult.RouteName, Is.EqualTo("ContactConfirmed"));
        }

        [Test]
        public void Contact_Post_RedirectToTheCorrectAction_IfExceptionThrown()
        {
            _fakeEmailer.Setup(x => x.Message()).Throws(new Exception());
            
            var redirectResult = (RedirectToRouteResult)_sut.Contact(It.IsAny<Contact>());           

            Assert.That(redirectResult.RouteName, Is.EqualTo("ContactFailed"));
        }

        [Test]
        public void Contact_Post_ReturnTheCorrectVie_IfModelStateIsInvalid()
        {
            var contactStub = new Contact();
            _sut.ModelState.AddModelError("", "");

            var viewResult = _sut.Contact(contactStub) as ViewResult;

            Assert.AreEqual("ContactFailed", viewResult.ViewName);
        }

        [Test]
        public void ContactConfirmed_ReturnTheCorrectView()
        {
            var sut = new HomeController(_fakePostRepo.Object, _fakeEmailer.Object, _fakeViewMapper.Object);

            ViewResult viewResult = sut.ContactConfirmed();

            Assert.AreEqual("ContactConfirmed", viewResult.ViewName);
        }

        [Test]
        public void ContactFailed_ReturnTheCorrectView()
        {
            var sut = new HomeController(_fakePostRepo.Object, _fakeEmailer.Object, _fakeViewMapper.Object);

            ViewResult viewResult = sut.ContactFailed();

            Assert.AreEqual("ContactFailed", viewResult.ViewName);
        }

        [Test]
        public void CategorySearch_SetSearchParamToDefaultValue_IfNoneProvided()
        {
            _sut.CategorySearch(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.GetPostsByCategory(It.Is<string>(y => y == "search")));
        }

        [Test]
        public void CategorySearch_Call_GetPostsByCategory_ExactlyOnce()
        {
            _sut.CategorySearch(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.GetPostsByCategory(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CategorySearch_Call_GetPostsByCategory_WithTheCorrectSearchTerm()
        {
            _sut.CategorySearch(It.IsAny<int>(), "Search Term");

            _fakePostRepo.Verify(x => x.GetPostsByCategory(It.Is<string>(s => s == "Search Term")));
        }

        [Test]
        public void CategorySearch_ReturnHttpNotFound_If_GetPostsByCategory_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.GetPostsByCategory(It.IsAny<string>())).Returns(() => null);

            var viewResult = _sut.CategorySearch(It.IsAny<int>(), It.IsAny<string>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void CategorySearch_SetPageNoTo_1_IfNullParamIsProvided()
        {
            _fakePostRepo.Setup(x => x.GetPostsByCategory(It.IsAny<string>())).Returns(() => new List<Post>());

            _sut.CategorySearch(null, "Search Term");

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(y => y == 1), It.IsAny<int>(),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void CateorySearch_Call_MapIndexViewModel_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.GetPostsByCategory(It.IsAny<string>())).Returns(() => new List<Post>());

            _sut.CategorySearch(It.IsAny<int>(), It.IsAny<string>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CategorySearch_Call_MapIndexViewModel_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.GetPostsByCategory(It.IsAny<string>())).Returns(_posts);

            _sut.CategorySearch(2, "cycling");

            _fakeViewMapper.Verify(
                x =>
                x.MapIndexViewModel(It.Is<List<Post>>(p => p.Equals(_posts)), It.Is<int>(p => p == 2),
                                    It.Is<int>(p => p == 5),
                                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void CategorySearch_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.GetPostsByCategory(It.IsAny<string>())).Returns(() => new List<Post>());

            var viewResult = _sut.CategorySearch(It.IsAny<int>(), It.IsAny<string>()) as ViewResult;

            Assert.AreEqual("_BlogPost", viewResult.ViewName);
        }

        [Test]
        public void CategorySearch_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.GetPostsByCategory(It.IsAny<string>())).Returns(_posts);
            _fakeViewMapper.Setup(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                                           It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()))
                           .Returns(() => new BlogPostViewModel());

            var viewResult = _sut.CategorySearch(It.IsAny<int>(), It.IsAny<string>()) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<BlogPostViewModel>(model);
        }

        [Test]
        public void ArchiveSearch_Call_GetPostsByDate_ExactlyOnce()
        {
            _sut.ArchiveSearch(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());

            _fakePostRepo.Verify(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void ArchiveSearch_Call_GetPostsByDate_WithCorrectData()
        {
            _sut.ArchiveSearch(sort: 1, page: 4, year: 2013);

            _fakePostRepo.Verify(x => x.GetPostsByDate(It.Is<int>(a => a == 1), It.Is<int>(a => a == 2013)));
        }

        [Test]
        public void ArchiveSearch_ReturnHttpNotFound_If_GetPostsByDate_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(() => null);

            var viewResult = _sut.ArchiveSearch(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());
            var model = viewResult as HttpNotFoundResult;

            Assert.AreEqual(404, model.StatusCode);
        }

        [Test]
        public void ArchiveSearch_SetCorrectPageSize()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(_posts);

            _sut.ArchiveSearch(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.Is<int>(y => y == 6),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void ArchiveSearch_SetPageNoTo_1_IfNullParamIsProvided()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(_posts);

            _sut.ArchiveSearch(null, It.IsAny<int>(), It.IsAny<int>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(y => y == 1), It.IsAny<int>(),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void ArchiveSearch_Call_MapIndexViewModel_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(_posts);

            _sut.ArchiveSearch(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()),
                Times.Once());
        }

        [Test]
        public void ArchiveSearch_Call_MapIndexViewModel_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(_posts);

            _sut.ArchiveSearch(2, 4, 2013);

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.Is<List<Post>>(p => p.Equals(_posts)), It.Is<int>(p => p == 2),
                                         It.Is<int>(p => p == 6), It.IsAny<string>(), It.IsAny<bool>(),
                                         It.IsAny<string>()));
        }

        [Test]
        public void ArchiveSearch_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(_posts);

            var viewResult = _sut.ArchiveSearch(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()) as ViewResult;

            Assert.AreEqual("_BlogPost", viewResult.ViewName);
        }

        [Test]
        public void ArchiveSearch_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.GetPostsByDate(It.IsAny<int>(), It.IsAny<int>())).Returns(_posts);
            _fakeViewMapper.Setup(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                                           It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()))
                           .Returns(() => new BlogPostViewModel());

            var viewResult = _sut.ArchiveSearch(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<BlogPostViewModel>(model);
        }

        [Test]
        public void Details_SetPostIdParamTo_1_IfNoneGiven()
        {
            _sut.Details(It.IsAny<int>(), It.IsAny<bool>());

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Details_Call_Find_ExactlyOnce()
        {
            _sut.Details(It.IsAny<int>(), It.IsAny<bool>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void Details__SetCorrectPageSize()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            _sut.Details(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.Is<int>(y => y == 5),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Details_SetPageNoTo_1_IfNullParamIsProvided()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            _sut.Details(null, It.IsAny<bool>(), It.IsAny<int>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(y => y == 1), It.IsAny<int>(),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Details_Call_MapIndexViewModel_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            _sut.Details(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>());

            _fakeViewMapper.Verify(
                x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                         It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()),
                Times.Once());
        }

        [Test]
        public void Details_Call_MapIndexViewModel_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            _sut.Details(1, false, 4);

            _fakeViewMapper.Verify(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(p => p == 1),
                                                            It.Is<int>(p => p == 5), It.IsAny<string>(),
                                                            It.Is<bool>(p => p == false), It.IsAny<string>()));
        }

        [Test]
        public void Details_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            var viewResult = _sut.Details(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>());

            Assert.AreEqual("_BlogPost", viewResult.ViewName);
        }

        [Test]
        public void Details_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());
            _fakeViewMapper.Setup(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(),
                                                           It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()))
                           .Returns(() => new BlogPostViewModel());

            var viewResult = _sut.Details(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>());
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<BlogPostViewModel>(model);
        }

        [Test]
        public void Error_ReturnTheCorrectView()
        {
            ViewResult viewResult = _sut.Error();

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [TearDown]
        public void TearDown()
        {
            _fakePostRepo = null;
            _fakeEmailer = null;
            _fakeViewMapper = null;
            _posts = null;
            _sut = null;
        }
    }
}