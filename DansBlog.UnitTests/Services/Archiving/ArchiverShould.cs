using DansBlog.Services.Archiving;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.ViewModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DansBlog._UnitTests.Services.Archiving
{
    [TestFixture]
    public class ArchiverShould
    {
        private Mock<IDistinctMonthHelper> _fakeDistinctMonthHelper;

        private Mock<IArchiveMapper> _fakeArchiveMapper;

        private DateTime _dateTime;

        [SetUp]
        public void Init()
        {
            _fakeDistinctMonthHelper = new Mock<IDistinctMonthHelper>();
            _fakeArchiveMapper = new Mock<IArchiveMapper>();
            _dateTime = new DateTime(2013, 8, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetArchivedMonths_ThrowAnArgumentNullException_IfBlogPostsParamIsNull()
        {
            var sut = new Archiver(_fakeDistinctMonthHelper.Object, _fakeArchiveMapper.Object);

            sut.GetArchivedMonths(_dateTime, 5, null);
        }

        [Test]
        public void GetArchivedMonths_CallGetDistinctPreviousMonths()
        {
            var sut = new Archiver(_fakeDistinctMonthHelper.Object, _fakeArchiveMapper.Object);

            sut.GetArchivedMonths(_dateTime, 5, Mother.GetFiveSimpleBlogPosts());

            _fakeDistinctMonthHelper.Verify(x => x.GetDistinctPreviousMonths(It.IsAny<DateTime>(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void GetArchivedMonths_CallMapArchiveViewModel()
        {
            _fakeDistinctMonthHelper.Setup(x => x.GetDistinctPreviousMonths(It.IsAny<DateTime>(), It.IsAny<int>()))
            .Returns(Mother.GetListOfFiveDateTimes());

            _fakeArchiveMapper.Setup(x => x.MapArchiveModel(Mother.GetListOfFiveDateTimes(), Mother.GetFiveSimpleBlogPosts()))
            .Returns(() => new List<Archive>());

            var sut = new Archiver(_fakeDistinctMonthHelper.Object, _fakeArchiveMapper.Object);

            sut.GetArchivedMonths(_dateTime, 5, Mother.GetFiveSimpleBlogPosts());

            _fakeArchiveMapper.Verify();
        }

        [TearDown]
        public void TearDown()
        {
            _fakeDistinctMonthHelper = null;
            _fakeArchiveMapper = null;
        }
    }
}
