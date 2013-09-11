using DansBlog.DataAccess;
using DansBlog.Presentation.Controllers;
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
            //var fakeEmailService = new Mock<IEmailService>();
            //var db = new BlogDbContext();
            //var postRepository = new PostRepository(db);
            //var sut = new HomeController(postRepository, fakeEmailService.Object);

            //ViewResult result = sut.Index(1);            
        }
    }
}
