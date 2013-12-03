using System.Data.Entity;
using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DansBlog._UnitTests.Repository.Repositories
{
    [TestFixture]
    public class CategoryRepository_Should
    {
        [Test]
        public void All_CallCategoriesProperty()
        {
            //var fakeDbContext = new Mock<IDbContext>();
            //fakeDbContext.Setup(x => x.Categories).Returns(()=> new List<Category>());
            //var sut = new CategoryRepository(fakeDbContext.Object);
            //List<Category> categories = sut.All;
            //fakeDbContext.Verify(x => x.Categories, Times.Exactly(2));
        }

        
    }
}
