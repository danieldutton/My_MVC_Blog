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
    public class SearchController_Should
    {
        private Mock<IPostRepository> _fakePostRepo;

        private Mock<IViewMapper> _fakeViewMapper;

        private SearchController _sut;

        private List<Post> _posts;

        [SetUp]
        public void Init()
        {
            _fakePostRepo = new Mock<IPostRepository>();
            _fakeViewMapper = new Mock<IViewMapper>();
            _sut = new SearchController(_fakePostRepo.Object, _fakeViewMapper.Object);

            _posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
        }

        [Test]
        public void Index_UseDefaultSearchTerm_Blank_IfNoSearchParameterIsGiven()
        {
            _sut.Index(It.IsAny<int>(), It.IsAny<bool>());

            _fakePostRepo.Verify(x => x.Find(It.Is<string>(s => s == "blank")));
        }

        [Test]
        public void Index_CallMethod_Find_ExactlyOnce()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<string>())).Returns(() => new List<Post>());

            _sut.Index(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>());

            _fakePostRepo.Verify(x => x.Find(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Index_ReturnHttpNotFound_If_SearchReturnsNull()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<string>())).Returns(() => null);

            var result = _sut.Index(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>()) as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Index_DefaultPageSizeTo6()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<string>())).Returns(() => new List<Post>());

            _sut.Index(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>());

            _fakeViewMapper.Verify(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.IsAny<int>(),
                                                            It.Is<int>(p => p == 6), It.IsAny<string>(),
                                                            It.IsAny<bool>(), It.IsAny<string>()));
        }

        [Test]
        public void Index_IfPageValueIsNullDefaultTo1()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<string>())).Returns(() => new List<Post>());

            _sut.Index(null, It.IsAny<bool>(), It.IsAny<string>());

            _fakeViewMapper.Verify(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(p => p == 1),
                                                            It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>(),
                                                            It.IsAny<string>()));
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<string>())).Returns(() => new List<Post>());

            var viewResult = _sut.Index(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>()) as ViewResult;

            Assert.AreEqual("ArchiveSearch", viewResult.ViewName);
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            _fakePostRepo.Setup(x => x.Find(It.IsAny<string>())).Returns(_posts);
            _fakeViewMapper.Setup(x => x.MapIndexViewModel(_posts, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(),
                                                           It.IsAny<bool>(), It.IsAny<string>()))
                           .Returns(new BlogPostViewModel());

            var viewResult = _sut.Index(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<string>()) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf<BlogPostViewModel>(model);
        }

        [TearDown]
        public void TearDown()
        {
            _fakePostRepo = null;
            _fakeViewMapper = null;
            _posts = null;
            _sut = null;
        }
    }
}