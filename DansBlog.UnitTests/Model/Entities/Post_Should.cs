using DansBlog.Model.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog.UnitTests.Model.Entities
{
    [TestFixture]
    public class Post_Should
    {
        private readonly DateTime _publishedDate = new DateTime(2013, 12, 4);

        private const string ContentValue = "Content";

        private const string TitleValue = "Title";

        private const string AuthorValue = "Author";


        [Test]
        public void Title_FailModelValidationIfTitleIsAnEmptyString()
        {
            var sut = new Post { PublishDate = _publishedDate, Content = ContentValue, Title = string.Empty, Author = AuthorValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateTheCorrectErrorMessageIfTitleIsAnEmptyString()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = ContentValue, Title = string.Empty, Author = AuthorValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Title_FailModelValidationIfTitleIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = ContentValue, Title = null, Author =AuthorValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateTheCorrectErrorMessageIfTitleIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = ContentValue, Title = null, Author = AuthorValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Content_FailModelValidationIfContentIsAnEmptyString()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = string.Empty, Title = TitleValue, Author = AuthorValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentIsAnEmptyString()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = string.Empty, Title = TitleValue, Author = AuthorValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Content_FailModelValidationIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = null, Title = TitleValue, Author = AuthorValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = null, Title = TitleValue, Author = AuthorValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Author_FailModelValidationIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = ContentValue, Title = TitleValue, Author = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Author_GenerateTheCorrectErrorMessageIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = ContentValue, Title = TitleValue, Author = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Author is required", errorMessage);
        }

        [Test]
        public void ModeratedCommentCount_ReturnTheCorrectCountForModeratedComments()
        {
            var sut = new Post
                {
                    Comments = new List<Comment>
                        {
                            new Comment{HasBeenModerated = true}, 
                            new Comment{HasBeenModerated = true},
                            new Comment {HasBeenModerated = false},
                        }
                };

            int result = sut.ModeratedCommentCount;

            Assert.AreEqual(2, result);
        }

        [Test]
        public void ModeratedCommentCount_Return0IfPostCommentsAreNull()
        {
            var sut = new Post
                {
                    Comments = null,
                };

            int result = sut.ModeratedCommentCount;

            Assert.AreEqual(0, result);
        }  
    }
}
