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
        public void ReturnQuoteOneIfRandomIndexIsZero()
        {
            var fakeXmlLoader = new Mock<IXDocumentLoader>();
            fakeXmlLoader.Setup(x => x.LoadXDocument(It.IsAny<string>())).Returns(Mother.GetXDocument);

            var fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
            fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            var fakeDefaultQuoteGenerator = new Mock<DefaultQuoteGenerator>();

            var sut = new QuoteRepository(fakeXmlLoader.Object)
            {
                RandomNumberGenerator = fakeNumberGenerator.Object,
                DefaultQuoteGenerator = fakeDefaultQuoteGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(1, quote.Id);
            Assert.AreEqual("author1", quote.Author);
            Assert.AreEqual("text1", quote.Text);
        }

        [Test]
        public void ReturnQuoteTwoIfRandomIndexIsOne()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(2, quote.Id);
            Assert.AreEqual("author2", quote.Author);
            Assert.AreEqual("text2", quote.Text);
        }

        [Test]
        public void ReturnQuoteThreeIfRandomIndexIsTwo()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(3, quote.Id);
            Assert.AreEqual("author3", quote.Author);
            Assert.AreEqual("text3", quote.Text);
        }

        [Test]
        public void ReturnQuoteFourIfRandomIndexIsThree()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(4, quote.Id);
            Assert.AreEqual("author4", quote.Author);
            Assert.AreEqual("text4", quote.Text);
        }

        [Test]
        public void ReturnQuoteFiveIfRandomIndexIsFour()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(5, quote.Id);
            Assert.AreEqual("author5", quote.Author);
            Assert.AreEqual("text5", quote.Text); ;
        }

        [Test]
        public void ReturnQuoteSixIfRandomIndexIsFive()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(6, quote.Id);
            Assert.AreEqual("author6", quote.Author);
            Assert.AreEqual("text6", quote.Text);
        }

        [Test]
        public void ReturnQuoteSevenIfRandomIndexIsSix()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(7, quote.Id);
            Assert.AreEqual("author7", quote.Author);
            Assert.AreEqual("text7", quote.Text);
        }

        [Test]
        public void ReturnQuoteEightIfRandomIndexIsSeven()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(8, quote.Id);
            Assert.AreEqual("author8", quote.Author);
            Assert.AreEqual("text8", quote.Text);
        }

        [Test]
        public void ReturnQuoteNineIfRandomIndexIsEight()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(9, quote.Id);
            Assert.AreEqual("author9", quote.Author);
            Assert.AreEqual("text9", quote.Text);
        }

        [Test]
        public void ReturnQuoteTenIfRandomIndexIsNine()
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

            Quote quote = sut.GetRandomQuote(filePath: "test");

            Assert.AreEqual(10, quote.Id);
            Assert.AreEqual("author10", quote.Author);
            Assert.AreEqual("text10", quote.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _inMemoryXDoc = null;
        }
    }
}
