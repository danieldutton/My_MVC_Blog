using DansBlog.Model.Entities;
using NUnit.Framework;

namespace DansBlog.UnitTests.Model.Entities
{
    [TestFixture]
    public class TagShould
    {
        [Test]
        public void GiveTrueIfTwoCategoriesWithTheSameNameValueAreEqual()
        {
            var category1 = new Tag { Name = "Programming" };
            var category2 = new Tag { Name = "Programming" };

            Assert.AreEqual(category1, category2);
        }

        [Test]
        public void GiveFalseIfTwoCategoriesWithDifferentNameValuesAreNotEqual()
        {
            var category1 = new Tag { Name = "CSS" };
            var category2 = new Tag { Name = "Programming" };

            Assert.AreNotEqual(category1, category2);
        }
    }
}
