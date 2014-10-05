using DansBlog.Controllers;
using DansBlog.Model.Entities;
using DansBlog.Presentation.Mappers;
using DansBlog.Presentation.ViewModels;
using DansBlog.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DansBlog.UnitTests.Presentation.Controllers
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

        [Test]
        public void Index_Call_All_ExactlyOnce()
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
                x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(), It.Is<int>(i => i == 28),
                                    It.IsAny<string>(),
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
        public void Index_Call_MapIndexViewModelExactlyOnce()
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
        public void Index_Call_MapIndexViewModel_WithCorrectData()
        {
            _fakePostRepo.Setup(x => x.All).Returns(_posts);

            _sut.Index(1);

            _fakeViewMapper.Verify(
                x =>
                x.MapIndexViewModel(It.Is<List<Post>>(p => p.Equals(_posts)), It.Is<int>(i => i == 1),
                                    It.Is<int>(i => i == 28),
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

        [Test]
        public void Details__SetIDParamTo_1_IfNoneGiven()
        {
            _sut.Details();

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Details_Call_Find_ExactlyOnce()
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
        public void Details_ReturnHttpNotFound_If_Find_ReturnsNull()
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

            Assert.IsInstanceOf(typeof (Post), model);
        }

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

        [Test]
        public void Create_Post_Call_Add_ExactlyOnce_IfModelStateIsValid()
        {
            _sut.Create(It.IsAny<Post>());

            _fakePostRepo.Verify(x => x.Add(It.IsAny<Post>()), Times.Once());
        }

        [Test]
        public void Create_Post_Call_Add_WithTheSpecifiedPost_IfModelStateIsValid()
        {
            var postStub = new Post();

            _sut.Create(postStub);

            _fakePostRepo.Verify(x => x.Add(It.Is<Post>(p => p.Equals(postStub))));
        }

        [Test]
        public void Create_Post_RedirectToIndexAction_IfModelStateIsValid()
        {
            var redirectResult = (RedirectToRouteResult) _sut.Create(It.IsAny<Post>());

            Assert.AreEqual(redirectResult.RouteName, "Index");
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
            var postStub = new Post();
            _sut.ModelState.AddModelError(" ", " ");

            var viewResult = _sut.Create(postStub) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf<Post>(model);
        }

        [Test]
        public void Edit_Get_SetIDParamTo_1_IfNoneGiven()
        {
            _sut.Edit();

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Edit_Get_Call_Find_ExactlyOnce()
        {
            _sut.Edit();

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Edit_Get_Call_Find_WithCorrectData()
        {
            _sut.Edit(4);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 4)));
        }

        [Test]
        public void Edit_Get_ReturnHttpNotFound_If_Find_ReturnsNull()
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

        [Test]
        public void Edit_Post_Call_Update_ExactlyOnce_IfModelStateIsValid()
        {
            _sut.Edit(It.IsAny<Post>());

            _fakePostRepo.Verify(x => x.Update(It.IsAny<Post>()), Times.Once());
        }

        [Test]
        public void Edit_Post__Call_Update_WithCorrectData_IfModelStateIsValid()
        {
            var postStub = new Post();

            _sut.Edit(postStub);

            _fakePostRepo.Verify(x => x.Update(It.Is<Post>(p => p.Equals(postStub))));
        }

        [Test]
        public void Edit_Post_RedirectToIndexAction_IfModelStateIsValid()
        {
            var redirectResult = (RedirectToRouteResult)_sut.Edit(It.IsAny<Post>());

            Assert.AreEqual("Index", redirectResult.RouteName);
        }

        [Test]
        public void Edit_Post_ReturnTheCorrectView_IfModelStateIsNotValid()
        {
            _sut.ModelState.AddModelError(" ", " ");

            var viewResult = _sut.Edit(It.IsAny<Post>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Edit_Post_ReturnTheCorrectModelType_IfModelStateIsNotValid()
        {
            var postStub = new Post();
            _sut.ModelState.AddModelError(" ", " ");

            var viewResult = _sut.Edit(postStub) as ViewResult;
            var model = viewResult.Model as Post;

            Assert.IsInstanceOf<Post>(model);
        }

        [Test]
        public void Delete_SetIDParamTo_1_IfNoneGiven()
        {
            _sut.Delete();

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Delete_Call_Find_ExactlyOnce()
        {
            _sut.Delete(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Delete_Call_Find_WithCorrectData()
        {
            _sut.Delete(5);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void Delete_ReturnHttpNotFound_If_Find_ReturnsNull()
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

            Assert.IsInstanceOf(typeof (Post), model);
        }

        [Test]
        public void DeleteConfirmed_Call_Find_ExactlyOnce()
        {
            _sut.DeleteConfirmed(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void DeleteConfirmed_Call_Find_WithCorrectData()
        {
            _sut.DeleteConfirmed(5);

            _fakePostRepo.Verify(x => x.Find(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void DeleteConfirmed_ReturnHttpNotFound_If_Find_ReturnsNull()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);

            var viewResult = _sut.DeleteConfirmed(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void DeleteConfirmed_Call_Delete_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Post());

            _sut.DeleteConfirmed(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Delete(It.IsAny<Post>()), Times.Once());
        }

        [Test]
        public void DeleteConfirmed_Call_Delete_WithCorrectData()
        {
            var postStub = new Post();
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(() => postStub);

            _sut.DeleteConfirmed(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.Delete(It.Is<Post>(y => y.Equals(postStub))));
        }

        [Test]
        public void DeleteConfirmed_RedirectToIndexAction()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<int>())).Returns(new Post());

            var redirectResult = (RedirectToRouteResult)_sut.DeleteConfirmed(It.IsAny<int>());

            Assert.AreEqual("Index", redirectResult.RouteName);
        }

        [Test]
        public void Moderate_Get_SetIDParamTo_1_IfNoneGiven()
        {
            _sut.Moderate();

            _fakePostRepo.Verify(x => x.GetUnModeratedPostComments(It.Is<int>(y => y == 1)));
        }

        [Test]
        public void Moderate_Get_Call_GetUnModeratedPostComments_ExactlyOnce()
        {
            _sut.Moderate(It.IsAny<int>());

            _fakePostRepo.Verify(x => x.GetUnModeratedPostComments(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void Moderate_Get_Call_GetUnModeratedPostComments_WithCorrectData()
        {
            _sut.Moderate(5);

            _fakePostRepo.Verify(x => x.GetUnModeratedPostComments(It.Is<int>(y => y == 5)));
        }

        [Test]
        public void Moderate_Get_ReturnHttpNotFound_If_GetUnModeratedPostComments_ReturnsNull()
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

            Assert.IsInstanceOf(typeof (List<Comment>), model);
        }

        [Test]
        public void Moderate_Post_ReturnHttpNotFound_If_CommentsParamIsNull()
        {
            var viewResult = _sut.Moderate(null) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Moderate_Post_Call_AddModeratedCommentToPost_ForModeratedCommentsOnly()
        {
            List<Comment> comments = Mother.GetTenComments_With_5_Moderated();

            _sut.Moderate(comments);

            _fakePostRepo.Verify(x => x.AddModeratedCommentToPost(It.IsAny<Comment>(), It.IsAny<int>()), Times.Exactly(5));
        }

        [Test]
        public void Moderate_Post_ReturnTheCorrectView()
        {
            List<Comment> comments = Mother.GetTenComments_With_5_Moderated();
            
            var viewResult = _sut.Moderate(comments) as ViewResult;

            Assert.AreEqual("ModerationSucessfull", viewResult.ViewName);    
        }

        [Test]
        public void AutoCompleteCategory_Call_SearchForCategory_ExactlyOnce()
        {
            var fakeCategoryRepository = new Mock<ICategoryRepository>();
            _sut.CategoryRepository = fakeCategoryRepository.Object;

            fakeCategoryRepository.Verify(x => x.SearchForCategories(It.IsAny<string>()), Times.Exactly(2));            
        }

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