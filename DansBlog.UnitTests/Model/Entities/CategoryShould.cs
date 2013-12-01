using DansBlog.Model.Entities;
using NUnit.Framework;

namespace DansBlog._UnitTests.Model.Entities
{
    [TestFixture]
    public class CategoryShould
    {
        [Test]
        public void GiveTrueIfTwoCategoriesWithTheSameNameValueAreEqual()
        {
            var category1 = new Category {Name = "Programming"};
            var category2 = new Category {Name = "Programming"};

            Assert.AreEqual(category1, category2);
        }

        [Test]
        public void GiveFalseIfTwoCategoriesWithDifferentNameValuesAreNotEqual()
        {
            var category1 = new Category { Name = "Programming" };
            var category2 = new Category { Name = "Css" };

            Assert.AreNotEqual(category1, category2);
        }
    }
}
