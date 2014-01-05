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
        #region Index

        [Test]
        public void Index_CallProperty_All()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeViewMapper = new Mock<IViewMapper>();
            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            
            sut.Index(1);

            fakePostRepository.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void Index_IfPostFoundIsNull_ReturnHttpNotFound()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(()=> null);
            var fakeViewMapper = new Mock<IViewMapper>();
            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);

            var result = sut.Index(It.IsAny<int>()) as HttpNotFoundResult;

            Assert.AreEqual("404", result.StatusCode);
        }

        [Test]
        public void Index_SetPageSizeToDefaultOfOne_IfValueGivenIsNull()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.All).Returns(Mother.GetTenPosts_With_1_Comment_PerPost());

            var fakeViewMapper = new Mock<IViewMapper>();
            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);

            sut.Index(null);

            fakeViewMapper.Verify(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(i => i ==3), It.IsAny<int>(), "Index", false, ""));
        }

        [Test]
        public void Index_SetPageNumberParaToDefaultOfOne_IfParamIsNull()
        {
            List<Post> posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.All).Returns(posts);
            var fakeViewMapper = new Mock<IViewMapper>();
            fakeViewMapper.Setup(x => x.MapIndexViewModel(posts, 1, It.IsAny<int>(), "Index", false, ""))
                          .Returns(() => new BlogPostViewModel());

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            sut.Index(1);

            fakeViewMapper.Verify();   
        }

        [Test]
        public void Index_CallMethod_MapIndexViewModel()
        {
            List<Post> posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.All).Returns(posts);
            var fakeViewMapper = new Mock<IViewMapper>();
            fakeViewMapper.Setup(x => x.MapIndexViewModel(posts, 1, It.IsAny<int>(), "Index", false, ""))
                          .Returns(() => new BlogPostViewModel());

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            sut.Index(1);

            fakeViewMapper.Verify();
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            List<Post> posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.All).Returns(posts);
            var fakeViewMapper = new Mock<IViewMapper>();
            fakeViewMapper.Setup(x => x.MapIndexViewModel(posts, 1, It.IsAny<int>(), "Index", false, "")).Returns(()=> new BlogPostViewModel());

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            var viewResult = sut.Index(1) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf(typeof (BlogPostViewModel), model);
        } 

        [Test]
        public void Index_ReturnTheCorrectModelData()
        {
            List<Post> posts = Mother.GetTenPosts_No_Categories_NoComments_No_Tags();
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.All).Returns(posts);
            var fakeViewMapper = new Mock<IViewMapper>();
            fakeViewMapper.Setup(x => x.MapIndexViewModel(posts, 1, It.IsAny<int>(), "Index", false, "")).Returns(() => new BlogPostViewModel());

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            var viewResult = sut.Index(1) as ViewResult;
            var model = viewResult.Model as BlogPostViewModel;

            Assert.IsInstanceOf(typeof(BlogPostViewModel), model);   
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            ViewResult  viewResult = sut.Index(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        #endregion

        #region Details

        [Test]
        public void Details_SetIdParamToDefaultValueOfOne_IfParamNotSpecified()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.All).Returns(Mother.GetTenPosts_With_1_Comment_PerPost());
            var fakeViewMapper = new Mock<IViewMapper>();
            

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            sut.Details();

            fakeViewMapper.Verify(x => x.MapIndexViewModel(It.IsAny<List<Post>>(), It.Is<int>(i => i == 29), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>(), ""));
        }

        [Test]
        public void Details_CallMethod_Find()
        {
            
        }

        [Test]
        public void Details_IfPostFoundIsNull_ReturnHttpNotFound()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            fakePostRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(()=> null);
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            var viewResult = sut.Details(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);    
        } // rewrite this test

        [Test]
        public void Details_ReturnTheCorrectDefaultView()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);
            var viewResult = sut.Details(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);    
        }

        [Test]
        public void Details_ReturnTheCorrectModelType()
        {
            
        }

        [Test]
        public void Details_ReturnTheCorrectModel()
        {
            
        }

        #endregion

        #region  Create Get

        [Test]
        public void Create_ReturnTheCorrectView()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);

            string expected = string.Empty;
            string actual = sut.Create().ViewName;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Create_ReturnTheCorrectModelType()
        {
            var fakePostRepository = new Mock<IPostRepository>();
            var fakeViewMapper = new Mock<IViewMapper>();

            var sut = new AdminController(fakePostRepository.Object, fakeViewMapper.Object);

            var model = sut.Create().Model as BlogPostViewModel;

            Assert.IsInstanceOf(typeof(BlogPostViewModel), model);
        }

        [Test]
        public void Create_ReturnTheCorrectModel()
        {
            
        }

        #endregion

    }
}
