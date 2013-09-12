using DansBlog.Model.Entities;
using DansBlog.Presentation.Controllers;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using DansBlog.Services.Email.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DansBlog.UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class HomeControllerShould
    {
        #region Index

        [Test]
        public void Index_CallMethod_All()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);
            sut.Index(1);

            fakePostRepository.Verify(x => x.All, Times.Once()); 
        }

        [Test]
        public void Index_CallMethod_MapIndexViewModel()
        {
            List<Post> posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            fakePostRepository.Setup(x => x.All).Returns(posts);

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);
            sut.Index(1);

            fakeViewMapper.Verify(x => x.MapIndexViewModel(posts, 1, 5, "Index", false, string.Empty), Times.Exactly(1));
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.About();

            string expected = string.Empty;
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            fakeViewMapper.Setup(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), 1, 5, "Index", false, string.Empty))
                .Returns(()=> new BlogPostViewModel());

            fakePostRepository.Setup(x => x.All).Returns(It.IsAny<List<Post>>());

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);
            var model = sut.Index(1).Model as BlogPostViewModel;

            Assert.IsInstanceOf(typeof (BlogPostViewModel), model);
        }

        #endregion

        #region About

        [Test]
        public void About_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.About();

            string expected = string.Empty;
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Archive

        [Test]
        public void Archive_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.Archive();

            string expected = string.Empty;
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Archive_ReturnTheCorrectViewModelType()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            fakeViewMapper.Setup(
                x =>
                x.MapIndexViewModel(Mother.GetTenPosts_No_Categories_NoComments_No_Tags(), 1, 5, It.IsAny<string>(),
                                    It.IsAny<bool>(), It.IsAny<string>()));

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.Index(1);

            var expected = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<IEnumerable<IGrouping<int, Post>>>(expected);
        }

        #endregion

        #region TagCloud

        [Test]
        public void TagCloud_MakeACallToAction_GetDistinctTags()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);
            sut.TagCloud();

            fakePostRepository.Verify(x => x.GetDistinctTags(), Times.Exactly(1));
        }

        [Test]
        public void TagCloud_ReturnsTheCorrectView()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);
            sut.TagCloud();

            string expected = string.Empty;
            string actual = sut.TagCloud().ViewName;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region FetchComments

        [Test]
        public void FetchComments_CallMethod_GetModeratedPostComments()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();

            context.Setup(x => x.Request).Returns(request.Object);

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);                                

            sut.ControllerContext = new ControllerContext(context.Object,
                                   new RouteData(), sut);

            sut.FetchComments();

            fakePostRepository.Verify(x => x.GetModeratedPostComments(1), Times.Once());
        }

        [Test]
        public void FetchComments_SetIDParamToOneIfNoneGiven()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();

            context.Setup(x => x.Request).Returns(request.Object);

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            sut.ControllerContext = new ControllerContext(context.Object,
                                   new RouteData(), sut);

            var viewResult = sut.FetchComments() as ViewResult;

            var model = viewResult.Model as List<Comment>;

            Assert.AreEqual(1, model[0].PostId);
        }

        [Test]
        public void FetchComments_ReturnTheCorrectView_IfIsAjaxRequest()
        {
            
        }

        [Test]
        public void FetchComments_ReturnTheCorrectView_IfNormalRequest()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();

            context.Setup(x => x.Request).Returns(request.Object);

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            sut.ControllerContext = new ControllerContext(context.Object,
                                   new RouteData(), sut);

            
            var viewResult = sut.FetchComments() as ViewResult;
            const string expected = "NonAjaxView";
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FetchComments_ReturnTheCorrectModelType_IfNormalRequest()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.GetModeratedPostComments(1))
                              .Returns(It.IsAny<List<Comment>>());
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();

            context.Setup(x => x.Request).Returns(request.Object);

            var sut = new HomeController(fakePostRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            sut.ControllerContext = new ControllerContext(context.Object,
                                   new RouteData(), sut);


            var viewResult = sut.FetchComments() as ViewResult;

            Assert.IsInstanceOf(typeof (List<Comment>), viewResult.Model);
        }

        [Test]
        public void FetchComments_ReturnTheCorrectModelType_IfAjaxRequest()
        {
            
        }

        [Test]
        public void FetchComments_ReturnTheCorrectPostsComments()
        {
                
        }

        #endregion

        #region LeaveComment

        #endregion

        #region TagSearch

        #endregion

        #region Downloads

        [Test]
        public void Downloads_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.Downloads();

            string expected = string.Empty;
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Contact (Get)

        [Test]
        public void Contact_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.Contact();

            string expected = string.Empty;
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Contact (Post)

        #endregion

        #region ContactConfirmed

        [Test]
        public void ContactConfirmed_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.ContactConfirmed();

            const string expected = "ContactConfirmed";
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ContactFailed

        [Test]
        public void ContactFailed_ReturnTheCorrectView()
        {
            var fakeRepository = new Mock<IPostRepository>();
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new HomeController(fakeRepository.Object, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult viewResult = sut.ContactFailed();

            const string expected = "ContactFailed";
            string actual = viewResult.ViewName;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region CategorySearch

        #endregion

        #region ArchiveSearch

        #endregion

        #region Details

        [Test]
        public void Details_CallMethod_Find()
        {
            
        }

        #endregion
    }
}
