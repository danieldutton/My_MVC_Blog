using DansBlog.Services.Email.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog.UnitTests.Services.Email
{
    [TestFixture]
    public class Contact_Should
    {
        private const string NameValue = "Name";

        private const string SubjectValue = "Subject";

        private const string EmailValue = "dan@dan.com";

        private const string MessageValue = "Message";

        [Test]
        public void Name_FailModelValidationIfNameIsAnEmptyString()
        {
            var sut = new Contact { Name = string.Empty, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsAnEmptyString()
        {
            var sut = new Contact { Name = string.Empty, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_FailModelValidationIfNameIsMissing()
        {
            var sut = new Contact { Name = null, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsMissing()
        {
            var sut = new Contact { Name = null, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_ErrorMessageDisplayedIfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Contact { Name = chars71, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }

        //
        [Test]
        public void Subject_FailModelValidationIfSubjectIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = string.Empty, Email = EmailValue, Message = MessageValue };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Subject_GenerateTheCorrectErrorMessageIfSubjectIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = string.Empty, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Subject is required", errorMessage);
        }

        [Test]
        public void Subject_FailModelValidationIfSubjectIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = null, Email = EmailValue, Message = MessageValue };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Subject_GenerateTheCorrectErrorMessageIfSubjectIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = null, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Subject is required", errorMessage);
        }

        [Test]
        public void Subject_ErrorMessageDisplayedIfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Contact { Name = NameValue, Subject = chars71, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }

        //
        [Test]
        public void Email_FailModelValidationIfEmailIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = string.Empty, Message = MessageValue };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateTheCorrectErrorMessageIfEmailIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = string.Empty, Message = MessageValue };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Email is required", errorMessage);
        }

        [Test]
        public void Email_FailModelValidationIfEmailIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = null, Message = MessageValue };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateTheCorrectErrorMessageIfEmailIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = null, Message = MessageValue };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Email is required", errorMessage);
        }

        [Test]
        public void Email_ErrorMessageDisplayedIfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = chars71, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }

        //
        [Test]
        public void Message_FailModelValidationIfMessageIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = string.Empty };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Message_GenerateTheCorrectErrorMessageIfMessageIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = string.Empty };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Message is required", errorMessage);
        }

        [Test]
        public void Message_FailModelValidationIfMessageIsMissing()
        {
            var sut = new Contact { Name =NameValue, Subject = SubjectValue, Email = EmailValue, Message = null };

            int errorCount = UnitTests.Model.Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Message_GenerateTheCorrectErrorMessageIfMessageIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = null };

            IList<ValidationResult> result = UnitTests.Model.Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Message is required", errorMessage);
        }

        [Test]
        public void Message_ErrorMessageDisplayedIfCharsOver500()
        {
            var chars501 = new string('a', 501);

            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = chars501 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 500 characters allowed", errorMessage);
        }
    }
}
