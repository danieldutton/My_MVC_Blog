using DansBlog.Model.Entities;
using NUnit.Framework;

namespace DansBlog._UnitTests.Model.Entities
{
    [TestFixture]
    public class Tag_Should
    {
        [Test]
        public void Equals_ReturnTrueIfTwoCategoriesHaveIdenticalNameValues()
        {
            var category1 = new Tag { Name = "Programming" };
            var category2 = new Tag { Name = "Programming" };

            Assert.AreEqual(category1, category2);
        }

        [Test]
        public void Equals_ReturnFalseIfTwoCategoriesHaveDifferentNameValues()
        {
            var category1 = new Tag { Name = "CSS" };
            var category2 = new Tag { Name = "Programming" };

            Assert.AreNotEqual(category1, category2);
        }
    }
}
