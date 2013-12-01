using DansBlog.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog._UnitTests.Model.Entities
{
    [TestFixture]
    public class Comment_Should
    {
        private const string AuthorValue = "Daniel";

        private const string ContentValue = "Content";

        private const string EmailValue = "dan@dan.com";


        [Test]
        public void Content_ErrorMessageDisplayedIfCharsOver500()
        {
            var chars71 = new string('a', 501);

            var sut = new Comment { Author = AuthorValue, Email = EmailValue, Content = chars71 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 500 characters allowed", errorMessage);
        }

        [Test]
        public void Content_FailModelValidationIfContentIsMissing()
        {
            var sut = new Comment {Author = AuthorValue, Email = EmailValue, Content = null};

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentIsMissing()
        {
            var sut = new Comment { Author = AuthorValue, Email = EmailValue, Content = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("A comment is required", errorMessage);
        }

        [Test]
        public void Content_FailModelValidationIfContentIsAnEmptyString()
        {
            var sut = new Comment { Author = AuthorValue, Email = EmailValue, Content = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentIsAnEmptyString()
        {
            var sut = new Comment { Author = AuthorValue, Email = EmailValue, Content = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("A comment is required", errorMessage);
        }

        [Test]
        public void Author_FailModelValidationIfAuthorIsMissing()
        {
            var sut = new Comment { Author = null, Email = EmailValue, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Author_GenerateTheCorrectErrorMessageIfAuthorIsMissing()
        {
            var sut = new Comment { Author = null, Email = EmailValue, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Author name is required", errorMessage);
        }

        [Test]
        public void Author_FailModelValidationIfContentIsAnEmptyString()
        {
            var sut = new Comment { Author = AuthorValue, Email = EmailValue, Content = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Author_GenerateTheCorrectErrorMessageIfContentIsAnEmptyString()
        {
            var sut = new Comment { Author = AuthorValue, Email = EmailValue, Content = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("A comment is required", errorMessage);
        }

        [Test]
        public void Author_ErrorMessageDisplayedIfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Comment { Author = chars71, Email = EmailValue, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }


        [Test]
        public void Email_FailModelValidationIfEmailIsMissing()
        {
            var sut = new Comment { Author = AuthorValue, Email = null, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateTheCorrectErrorMessageIfEmailIsMissing()
        {
            var sut = new Comment { Author = AuthorValue, Email = null, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("E-mail address is required", errorMessage);
        }

        [Test]
        public void Email_FailModelValidationIfContentIsAnEmptyString()
        {
            var sut = new Comment { Author = AuthorValue, Email = string.Empty, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateTheCorrectErrorMessageIfContentIsAnEmptyString()
        {
            var sut = new Comment { Author = AuthorValue, Email = string.Empty, Content = ContentValue};

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("E-mail address is required", errorMessage);
        }

        [Test]
        public void Email_ErrorMessageDisplayedIfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Comment { Author = AuthorValue, Email = chars71, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("E-mail address Too Long", errorMessage);
        }
    }
}
