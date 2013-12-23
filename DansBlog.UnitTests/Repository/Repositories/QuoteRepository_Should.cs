using DansBlog.Model.Domain;
using DansBlog.Repository.Repositories;
using DansBlog.Utilities.Interfaces;
using Moq;
using NUnit.Framework;
using System.Xml.Linq;

namespace DansBlog._UnitTests.Repository.Repositories
{
    [TestFixture]
    public class QuoteRepository_Should
    {
        private XDocument _inMemoryXDoc;

        [SetUp]
        public void Init()
        {
            _inMemoryXDoc = Mother.GetXDocument();
        }

        [Test]
        public void MakeACallTo_GetDefaultQuote_IfFilePathParameterIs_Null()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: null);

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void MakeACallTo_GetDefaultQuote_IfFilePathParameterIsAn_EmptyString()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: string.Empty);

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void MakeACallTo_LoadXml()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeXmlLoader.Verify(x => x.LoadXDocument("test"), Times.Once());
        }

        [Test]
        public void MakeACallTo_DefaultQuoteIf_LoadXml_ReturnsANull_XDocument()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(() => null);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void MakeACallTo_GetRandomNumber()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: null);

            fakeNumberGenerator.Verify();
        }

        [Test]
        public void MakeACallTo_GetDefaultQuote_If_XElementIs_Null()
        {
            var nullElementXDoc = new XDocument();

            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(nullElementXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteOneIfRandomIndexIsOne()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(Mother.GetXDocument);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());   
        }

        [Test]
        public void ReturnQuoteTwoIfRandomIndexIsTwo()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(2);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteThreeIfRandomIndexIsThree()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(3);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteFourIfRandomIndexIsFour()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(4);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteFiveIfRandomIndexIsFive()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(5);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteSixIfRandomIndexIsSix()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(6);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteSevenIfRandomIndexIsSeven()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(7);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteEightIfRandomIndexIsEight()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(8);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteNineIfRandomIndexNine()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(9);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

        [Test]
        public void ReturnQuoteTenIfRandomIndexIsTen()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(_inMemoryXDoc);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(10);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            sut.GetRandomQuote(filePath: "test");

            fakeDefaultQuoteGenerator.Verify(x => x.GetDefaultQuote(), Times.Once());
        }

    }
}
