using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace DansBlog.IntegrationTests.Repository_Data
{
    [TestFixture]
    public class PostRepository_Should
    {
        private const string DbFile = "DansBlog.DataAccess.BlogDbContext";

        private BlogDbContext _dataContext;

        private PostRepository _sut;


        [SetUp]
        public void InitTest()
        {
            _dataContext = new BlogDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new PostRepository(_dataContext);
        }

        [Test]
        public void All_ReturnTheCorrectCountOfPosts()
        {
            List<Post> posts = _sut.All;

            Assert.AreEqual(10, posts.Count);
        }

        [Test]
        public void All_ReturnTheCorrectPostsOrderedByPublishDateDescending()
        {
            List<Post> posts = _sut.All;    
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Dispose();

            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }
            _sut = null;
        }
    }
}
