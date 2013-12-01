using DansBlog.Model.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog._UnitTests.Model.Entities
{
    [TestFixture]
    public class PostShould
    {
        //ToDo Test PublishedDate DisplayName and DisplayFormat

        [Test]
        public void Title_FailModelValidationIfTitleIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = "Test", Title = null, Author = "author" };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateTheCorrectErrorMessageIfTitleIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = "Test", Title = null, Author = "author" };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Content_FailModelValidationIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = null, Title = "title", Author = "author" };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = null, Title = "title", Author = "author" };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Author_FailModelValidationIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = "Content", Title = "title", Author = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Author_GenerateTheCorrectErrorMessageIfContentIsMissing()
        {
            var sut = new Post { PublishDate = new DateTime(2013, 2, 4), Content = "Content", Title = "title", Author = null };

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
