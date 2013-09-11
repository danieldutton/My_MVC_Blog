using DansBlog.DataAccess;
using DansBlog.Presentation.Controllers;
using DansBlog.Presentation.Mappers;
using DansBlog.Repository.Repositories;
using DansBlog.Services.Email.Interfaces;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace DansBlog.IntegrationTests.Presentation.Controllers
{
    [TestFixture]
    public class HomeController_Index_Should
    {
        [Test]
        public void Foo()
        {
            var fakeEmailService = new Mock<IEmailer>();
            var fakeViewMapper = new Mock<IViewMapper>();
            var db = new BlogDbContext();
            var postRepository = new PostRepository(db);
            var sut = new HomeController(postRepository, fakeEmailService.Object, fakeViewMapper.Object);

            ViewResult result = sut.Index(1);            
        }
    }
}
