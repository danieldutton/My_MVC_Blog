using System.Collections.Generic;
using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository.Repositories;
using NUnit.Framework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace DansBlog._IntegrationTests.Repository_Data
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
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new BlogDataInitializer());

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
