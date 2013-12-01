using DansBlog.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog._UnitTests.Model.Entities
{
    [TestFixture]
    public class CategoryShould
    {
        [Test]
        public void Name_FailModelValidationIfNameIsMissing()
        {
            var sut = new Category {Count = 2, Posts = null, Name = null};

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsMissing()
        {
            var sut = new Category {Count = 2, Posts = null, Name = null};

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

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
