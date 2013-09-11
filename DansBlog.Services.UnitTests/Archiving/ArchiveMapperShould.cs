using DansBlog.Services.Archiving.Utilities;
using DansBlog.Services.Archiving.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DansBlog.UnitTests.Services.Archiving
{
    [TestFixture]
    public class ArchiveMapperShould
    {
        private ArchiveMapper sut;

        [SetUp]
        public void Init()
        {
            sut = new ArchiveMapper();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapArchiveModel_ThrowAnArgumentNullException_IfArchivesParamIsNull()
        {
            sut.MapArchiveModel(null, Mother.GetFiveSimpleBlogPosts());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapArchiveModel_ThrowAnArgumentNullException_IfBlogPostsParamIsNull()
        {
            sut.MapArchiveModel(Mother.GetListOfFiveDateTimes(), null);
        }

        [Test]
        public void MapArchiveModel_ReturnInstanceOfTypeListOfArchives()
        {
            List<Archive> archives = sut.MapArchiveModel(Mother.GetListOfFiveDateTimes(), Mother.GetFiveSimpleBlogPosts());

            Assert.IsInstanceOf<List<Archive>>(archives);
        }

        [Test]
        public void MapArchiveModel_ReturnAListOfArchives()
        {
            List<Archive> archives = sut.MapArchiveModel(Mother.GetListOfFiveDateTimes(), Mother.GetFiveSimpleBlogPosts());

            CollectionAssert.AllItemsAreInstancesOfType(archives, typeof (Archive));
        }

        [Test]
        public void MapArchiveModel_ReturnsTheCorrectCountOfArchives()
        {
            List<Archive> archives = sut.MapArchiveModel(Mother.GetListOfFiveDateTimes(), Mother.GetFiveSimpleBlogPosts());

            const int expected = 5;
            int actual = archives.Count;

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {
            sut = null;
        }
    }
}
