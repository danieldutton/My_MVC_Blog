using DansBlog.Model.Entities;
using DansBlog.Presentation.Controllers;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DansBlog._UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class AdminController_Should
    {
        private Mock<IPostRepository> _fakePostRepo;

        private Mock<IViewMapper> _fakeViewMapper;

        private AdminController _sut;

        private List<Post> _posts;

        [SetUp]
        public void Init()
        {
            _fakePostRepo = new Mock<IPostRepository>();
            _fakeViewMapper = new Mock<IViewMapper>();
            _sut = new AdminController(_fakePostRepo.Object, _fakeViewMapper.Object);
            _posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
        }

        #region Index

        [Test]
        public void Index_CallProperty_All_ExactlyOnce()
        {
            _sut.Index(1);

            _fakePostRepo.VerifyGet(x => x.All, Times.Once());
        }

        [Test]
        public void Index_ReturnHttpNotFoundIf_All_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.All).Returns(() => null);

            var viewResult = _sut.Index(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Index_SetPageSizeTo28()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(It.IsAny<int>());

            _fakeViewMapper.Verify(
                x =>
                x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.Is<int>(i => i == 28), It.IsAny<string>(),
                                    It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Index_SetPageSizeToDefaultOf1_IfValueGivenIsNull()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(null);

            _fakeViewMapper.Verify(
                x => 
                    x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(i => i == 1), It.IsAny<int>(),
                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Index_CallMethod_MapIndexViewModelExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(1);

            _fakeViewMapper.Verify(
                x => 
                    x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(), 
                    It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()), 
                    Times.Once());
        }

        [Test]
        public void Index_CallMethod_MapIndexViewModel_WithTheCorrectData()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(1);

            _fakeViewMapper.Verify(
                x =>
                    x.MapIndexViewModel(It.Is<List<Post>>(p => p.Equals(_posts)), It.Is<int>(i => i == 1), It.Is<int>(i => i == 28), 
                    It.Is<string>(i => i == "Index"), It.Is<bool>(i => i == false), It.IsAny<string>()));
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
            _fakePostRepo.Setup(x => x.All).Returns(_posts);
            _fakeViewMapper.SetReturnsDefault(new BlogPostViewModel());

            var viewResult = _sut.Index(1) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf(typeof (BlogPostViewModel), model);
        }

        #endregion

        #region Details

        [Test]
        public void Details_SetParamToOnebyDefaultIfNoneSpecified()
        {
            _sut.Details();

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Details_CallFindExactlyOnce()
        {
            _sut.Details(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Details_CallFindWithSpecifiedId()
        {
            _sut.Details(5);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void Details_ReturnHttpNotFoundIf_Find_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);

            var viewResult = _sut.Details(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Details_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Post());

            var viewResult = _sut.Details(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Details_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Post());
            _fakeViewMapper.Setup(
                x =>
                x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(),
                                    It.IsAny<bool>(), It.IsAny<string>()));

            var viewResult = _sut.Details(It.IsAny<int>()) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf(typeof(Post), model);
        }

        #endregion

        #region Create Get

        [Test]
        public void Create_Get_ReturnTheCorrectView()
        {
            var fakeContext = new Mock<ControllerContext>();
            fakeContext.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("Daniel Dutton");
            fakeContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            _sut.ControllerContext = fakeContext.Object;

            var viewResult = _sut.Create() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Create_Get_ReturnTheCorrectModelType()
        {
            var fakeContext = new Mock<ControllerContext>();
            fakeContext.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("Daniel Dutton");
            fakeContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            _sut.ControllerContext = fakeContext.Object;

            var viewResult = _sut.Create() as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf<Post>(model);   
        }

        [Test]
        public void Create_Get_ReturnAModelTypeWithUserPropertyInitialised()
        {
            var fakeContext = new Mock<ControllerContext>();
            fakeContext.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("Daniel Dutton");
            fakeContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            _sut.ControllerContext = fakeContext.Object;

            var viewResult = _sut.Create() as ViewResult;
            var model = viewResult.Model as Post;

            Assert.AreEqual("Daniel Dutton", model.Author);
        }

        #endregion

        #region Create Post

        [Test]
        public void Create_Post_CallAddMethodExactlyOnce_IfModelStateIsValid()
        {
            _sut.Create(It.IsAny<Post>());

            _fakePostRepo.Verify(x => x.Add(It.IsAny<Post>()), Times.Once());
        }

        [Test]
        public void Create_Post_CallAddMethodWithTheSpecifiedPost_IfModelStateIsValid()
        {
            var postStub = new Post();

            _sut.Create(postStub);

            _fakePostRepo.Verify(x => x.Add(It.Is<Post>(p => p.Equals(postStub))));
        }

        [Test]
        public void Create_Post_RedirectToIndexAction_IfModelStateIsValid()
        {
            var redirectResult = (RedirectToRouteResult)_sut.Create(It.IsAny<Post>());

            Assert.AreEqual(redirectResult.RouteValues, "/Admin/Inde");
        }

        [Test]
        public void Create_Post_ReturnTheCorrectView_IfModelStateIsNotValid()
        {
            _sut.ModelState.AddModelError(" ", " ");

            var viewResult = _sut.Create(It.IsAny<Post>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Create_Post_ReturnTheCorrectModelType_IfModelStateIsNotValid()
        {
            _sut.ModelState.AddModelError(" ", " ");

            var viewResult = _sut.Create(It.IsAny<Post>()) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf<Post>(model);   
        }

        #endregion

        #region Edit Get

        [Test]
        public void Edit_Get_SetParamToOnebyDefaultIfNoneSpecified()
        {
            _sut.Edit();

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Edit_Get_CallFindExactlyOnce()
        {
            _sut.Edit();

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Edit_Get_CallFindWithTheSpecifiedParam()
        {
            _sut.Edit(4);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 4)));
        }

        [Test]
        public void Edit_Get_ReturnHttpNotFoundIf_Find_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);

            var viewResult = _sut.Edit(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Edit_Get_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            var viewResult = _sut.Edit(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Edit_Get_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            var viewResult = _sut.Edit(It.IsAny<Post>()) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf<Post>(model);
        }

        #endregion

        #region Edit Post

        [Test]
        public void Edit_Post_CallUpdateMethodExactlyOnce_IfModelStateIsValid()
        {
            _sut.Edit(It.IsAny<Post>());

            _fakePostRepo.Verify(x => x.Update(It.IsAny<Post>()), Times.Once());    
        }

        [Test]
        public void Edit_Post__CallUpdateMethodWithTheSpecifiedPost_IfModelStateIsValid()
        {
            var postStub = new Post();

            _sut.Edit(postStub);

            _fakePostRepo.Verify(x => x.Update(It.Is<Post>(p => p.Equals(postStub))));
        }

        [Test]
        public void Edit_Post_RedirectToIndexAction_IfModelStateIsValid()
        {
            
        }

        [Test]
        public void Edit_Post_ReturnCorrectViewIfModelStateIsNotValid()
        {
            
        }

        [Test]
        public void Edit_Post_ReturnCorrectModelTypeIfModelStateIsNotValid()
        {
            
        }

        #endregion

        #region Delete

        [Test]
        public void Delete_SetParamToOnebyDefaultIfNoneSpecified()
        {
            _sut.Delete();

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));    
        }

        [Test]
        public void Delete_CallFindExactlyOnce()
        {
            _sut.Delete(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Delete_CallFindWithSpecifiedId()
        {
            _sut.Delete(5);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void Delete_ReturnHttpNotFoundIf_Find_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);

            var viewResult = _sut.Delete(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Delete_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Post());

            var viewResult = _sut.Delete(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Delete_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Post());

            var viewResult = _sut.Delete(It.IsAny<int>()) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf(typeof(Post), model);
        }

        #endregion

        #region Delete Confirmed

        [Test]
        public void DeleteConfirmed_CallFindExactlyOnce()
        {
            _sut.DeleteConfirmed(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void DeleteConfirmed_CallFindWithSpecifiedId()
        {
            _sut.DeleteConfirmed(5);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void DeleteConfirmed_ReturnHttpNotFoundIf_Find_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);

            var viewResult = _sut.DeleteConfirmed(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void DeleteConfirmed_CallDeleteExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            _sut.DeleteConfirmed(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Delete(It.IsAny<Post>()), Times.Once());
        }

        [Test]
        public void DeleteConfirmed_CallDeleteWithTheCorrectPost()
        {
            var postStub = new Post();
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => postStub);
            
            _sut.DeleteConfirmed(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Delete(It.Is<Post>(y => y.Equals(postStub))));
        }

        [Test]
        public void DeleteConfirmed_RedirectToIndexAction()
        {
            
        }

        #endregion

        #region Moderate Get

        [Test]
        public void Moderate_Get_SetParamToOnebyDefaultIfNoneSpecified()
        {
            _sut.Moderate();

            _fakePostRepo.Verify(x => x.GetUnModeratedPostComments(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Moderate_Get_CallGetUnModeratedPostCommentsExactlyOnce()
        {
            _sut.Moderate(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.GetUnModeratedPostComments(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Moderate_Get_CallGetUnModeratedPostCommentsWithSpecifiedId()
        {
            _sut.Moderate(5);

            _fakePostRepo.Verify(x => x.GetUnModeratedPostComments(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void Moderate_Get_ReturnHttpNotFoundIf_GetUnModeratedPostComments_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.GetUnModeratedPostComments(It.IsAny<int>()))
                .Returns(() => null);

            var viewResult = _sut.Moderate(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Moderate_Get_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.GetUnModeratedPostComments(It.IsAny<int>()))
                .Returns(new List<Comment>());

            var viewResult = _sut.Moderate(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Moderate_Get_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.GetUnModeratedPostComments(It.IsAny<int>()))
                .Returns(new List<Comment>());

            var viewResult = _sut.Moderate(It.IsAny<int>()) as ViewResult;
            var model = viewResult.Model as List<Comment>;

            Assert.IsInstanceOf(typeof(List<Comment>), model);
        }

        #endregion

        #region Moderate Post

        #endregion

        [TearDown]
        public void TearDown()
        {
            _fakePostRepo = null;
            _fakeViewMapper = null;
            _sut = null;
            _posts = null;
        }

    }
}
