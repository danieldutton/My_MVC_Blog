﻿using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace DansBlog.IntegrationTests.Repository_Data
{
    [TestFixture]
    public class PostRepository_Should
    {
        private BlogDbContext _dataContext;

        private PostRepository _sut;


        [SetUp]
        public void InitTest()
        {
            _dataContext = new BlogDbContext();
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
            _sut = null;
        }
    }
}
