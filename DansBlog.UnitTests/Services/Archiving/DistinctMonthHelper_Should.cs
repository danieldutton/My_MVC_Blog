using DansBlog.Services.Archiving.Utilities;
using DansBlog.Utilities.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog._UnitTests.Services.Archiving
{
    [TestFixture]
    public class DistinctMonthHelper_Should
    {
        [Test]
        public void GetDistinctPreviousMonths_SetMonthsRequiredParamTo1_IfANegativeValueIsGiven()
        {
            var dateTime = new DateTime(2013, 8, 4);
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(dateTime);

            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> result = sut.GetDistinctPreviousMonths(dateTime, -2);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetDistinctPreviousMonths_SetMonthsRequiredParamTo1_IfAZeroValueIsGiven()
        {
            var dateTime = new DateTime(2013, 8, 4);
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(dateTime);

            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> result = sut.GetDistinctPreviousMonths(dateTime, 0);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetDistinctPreviousMonths_SetDateParamToCurrentTime_IfItIsGreaterThanCurrentTime()
        {
            var dateTime = new DateTime(2014, 8, 4);
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 8, 4));

            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> result = sut.GetDistinctPreviousMonths(dateTime, 5);

            Assert.AreEqual(7, result[0].Month);
            Assert.AreEqual(2013, result[0].Year);
        }

        [Test]
        public void GetDistinctPreviousMonths_ReturnTheMonthCount_AsSpecifiedByMonthsRequiredParam()
        {
            var dateTime = new DateTime(2013, 8, 4);
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(dateTime);

            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> result = sut.GetDistinctPreviousMonths(dateTime, 10);

            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromJanuary()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 1, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 1, 1), 5);

            string[] expected = { "December", "November", "October", "September", "August" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromFebruary()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 2, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 2, 1), 5);

            string[] expected = { "January", "December", "November", "October", "September" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromMarch()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 3, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 3, 1), 5);

            string[] expected = { "February", "January", "December", "November", "October" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromApril()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 4, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 4, 1), 5);

            string[] expected = { "March", "February", "January", "December", "November" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromMay()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 5, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 5, 1), 5);

            string[] expected = { "April", "March", "February", "January", "December" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromJune()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 6, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 6, 1), 5);

            string[] expected = { "May", "April", "March", "February", "January" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromJuly()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 7, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 7, 1), 5);

            string[] expected = { "June", "May", "April", "March", "February" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromAugust()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 8, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 8, 1), 5);

            string[] expected = { "July", "June", "May", "April", "March" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromSeptember()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 9, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 9, 1), 5);

            string[] expected = { "August", "July", "June", "May", "April" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromOctober()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 10, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 10, 1), 5);

            string[] expected = { "September", "August", "July", "June", "May" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromNovember()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 11, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 11, 1), 5);

            string[] expected = { "October", "September", "August", "July", "June" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctPreviousMonths_FetchFiveMonthsPrevious_FromDecember()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 12, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 12, 1), 5);

            string[] expected = { "November", "October", "September", "August", "July" };
            IEnumerable<string> actual = months.Select(x => x.ToLongDateString().Split(' ').ElementAt(1));

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDistinctMonths_FetchFiveMonthsPrevious_WithOverlappingYears()
        {
            var fakeCurrentTime = new Mock<ICurrentDateTime>();
            fakeCurrentTime.Setup(x => x.GetCurrentTime()).Returns(() => new DateTime(2013, 12, 1));
            var sut = new DistinctMonthHelper(fakeCurrentTime.Object);

            List<DateTime> months = sut.GetDistinctPreviousMonths(new DateTime(2013, 3, 1), 5);

            int[] expected = { 2013, 2013, 2012, 2012, 2012 };
            IEnumerable<int> actual = months.Select(x => x.Year);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

