using DansBlog.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog.UnitTests.Model.Entities
{
    [TestFixture]
    public class Tag_Should
    {
        [Test]
        public void Name_FailModelValidationIfNameIsAnEmptyString()
        {
            var sut = new Tag { Name = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsAnEmptyString()
        {
            var sut = new Tag { Name = string.Empty };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_FailModelValidationIfNameIsMissing()
        {
            var sut = new Tag {Name = null};

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsMissing()
        {
            var sut = new Tag { Name = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

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
