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
        public void All_ReturnListOfCategories()
        {
            
        }

        [Test]
        public void Find_ReturnCategoryById()
        {
            var categories = new List<Category>
                {
                    new Category(),
                    new Category(),
                    new Category(),
                    new Category(),
                    new Category(),
                };

            var fakeDbContext = new Mock<IDbContext>();
            fakeDbContext.Setup(x => x.Categories).Returns(()=> categories);
            var sut = new CategoryRepository(fakeDbContext.Object);

        }
    }
}
