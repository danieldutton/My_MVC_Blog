using DansBlog.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog._UnitTests.Model.Entities
{
    [TestFixture]
    public class Category_Should
    {
        [Test]
        public void Name_FailModelValidationIfContentIsAnEmptyString()
        {
            var sut = new Category {Name = string.Empty};

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfContentIsAnEmptyString()
        {
            var sut = new Category {Name = string.Empty};

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_FailModelValidationIfNameIsMissing()
        {
            var sut = new Category { Count = 2, Posts = null, Name = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsMissing()
        {
            var sut = new Category { Count = 2, Posts = null, Name = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_CorrectErrorMessageDisplayedIfCharsOver30()
        {
            var chars31 = new string('a', 31);

            var sut = new Category {Name = chars31};

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 30 characters allowed", errorMessage);
        }

        [Test]
        public void Equals_ReturnTrueIfTwoCategoriesHaveIdenticalNameValues()
        {
            var category1 = new Category {Name = "Programming"};
            var category2 = new Category {Name = "Programming"};

            Assert.AreEqual(category1, category2);
        }

        [Test]
        public void Equals_ReturnFalseIfTwoCategoriesHaveDifferentNameValues()
        {
            var category1 = new Category { Name = "Programming" };
            var category2 = new Category { Name = "Css" };

            Assert.AreNotEqual(category1, category2);
        }
    }
}
