using DansBlog.Services.Archiving;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.Utilities;
using DansBlog.Utilities.DateTimes;
using NUnit.Framework;

namespace DansBlog.IntegrationTests.Services
{
    [TestFixture]
    public class Archiver_Should
    {
        [Test]
        public void Foo()
        {
            IDistinctMonthHelper monthHelper  =new DistinctMonthHelper(new CurrentTimeHelper());
            IArchiveMapper archiveMapper = new ArchiveMapper();
            var sut = new Archiver(monthHelper, archiveMapper);
        }
    }
}
