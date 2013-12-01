using DansBlog.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace DansBlog.UnitTests.Model.Entities
{
    [TestFixture]
    public class PostShould
    {
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
        public void ModeratedCommentCount_Return0IfPostCommentsArNull()
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
