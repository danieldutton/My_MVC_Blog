//using DansBlog.Model.Entities;
//using DansBlog.Model.Partials;
//using DansBlog.Presentation.Controllers;
//using DansBlog.Repository;
//using DansBlog.Repository.Interfaces;
//using Moq;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Web.Mvc;

//namespace DansBlog.UnitTests.Presentation.Controllers
//{
//    [TestFixture]
//    public class SearchControllerShould
//    {
//        private Mock<ICategoryRepository> _fakeCategoryRepository;

//        private Mock<IQuoteRepository<Quote>> _fakeQuoteRepository;

//        private Mock<IPostRepository> _fakePostRepository;

//        private RepositoryBundle _repositoryBundle;

//        private SearchController _searchController;


//        [SetUp]
//        public void Init()
//        {
//            _fakeCategoryRepository = new Mock<ICategoryRepository>();
//            _fakeQuoteRepository = new Mock<IQuoteRepository<Quote>>();
//            _fakePostRepository = new Mock<IPostRepository>();

//            _fakePostRepository.Setup(x => x.Find(It.IsAny<string>())).Returns(It.IsAny<List<Post>>());
//            _fakePostRepository.Setup(x => x.All).Returns(It.IsAny<List<Post>>());

//            _repositoryBundle = new RepositoryBundle(_fakePostRepository.Object, _fakeQuoteRepository.Object,
//            _fakeCategoryRepository.Object);

//            _searchController = new SearchController(_repositoryBundle);
//        }

//        [Test]
//        public void DefaultTheSearchTermTo_Blank_If_DefaultParamterIsUsed()
//        {
//            ViewResult viewResult = _searchController.Index(1, false);
//            const string expected = "blank";
//            var actual = (string)viewResult.ViewData["SearchTerm"];
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void SetTheUserSearchTermInTheViewBag()
//        {
//            ViewResult viewResult = _searchController.Index(1, false, "TestSearch");
//            const string expected = "TestSearch";
//            var actual = (string)viewResult.ViewData["SearchTerm"];
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void CallPostRepository_Find()
//        {

//        }

//        [Test]
//        public void SetPagedListPageNumberToOneIfPageParamaterIsNull()
//        {

//        }

//        [Test]
//        public void ReturnTheCorrectView()
//        {

//        }

//        [Test]
//        public void ReturnAPagedListOfPosts()
//        {

//        }
//    }
//}
