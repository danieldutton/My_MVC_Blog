using DansBlog.Model.Domain;
using DansBlog.Repository;
using DansBlog.Utilities.Interfaces;
using DansBlog.Utilities.Xml;
using Moq;
using NUnit.Framework;

namespace DansBlog.IntegrationTests.Repository_Data
{
    [TestFixture]
    public class QuoteRepository_Should
    {
        private IXDocumentLoader _xDocLoader;

        private Mock<IRandomNumberGenerator> _fakeNumberGenerator;

        private const string QuotesFilesPath = "quotes.xml";

        [SetUp]
        public void Init()
        {
            _xDocLoader = new XDocumentLoader();
            _fakeNumberGenerator = new Mock<IRandomNumberGenerator>();
        }

        [Test]
        public void GetRandomQuote_ReturnQuote1WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            var sut = new QuoteRepository(_xDocLoader)
                {
                    RandomNumberGenerator = _fakeNumberGenerator.Object
                };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 1; 
            const string expectedText = "I am the wisest man alive for I know one thing, and that is that I know nothing";
            const string expectedAuthor = "Socrates";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote2WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 2;
            const string expectedText = "Any man who reads too much and uses his own brain too little falls into lazy habits of thinking.";
            const string expectedAuthor = "David Brinkley";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote3WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(2);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 3;
            const string expectedText = "Failure is simply the opportunity to begin again, this time more intelligently.";
            const string expectedAuthor = "Henry Ford";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote4WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(3);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 4;
            const string expectedText = "Instead of getting married again, I'm going to find a woman I don't like and just give her a house.";
            const string expectedAuthor = "Rod Stewart";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote5WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(4);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 5;
            const string expectedText = "Be yourself; everyone else is already taken.";
            const string expectedAuthor = "Oscar Wilde";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote6WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(5);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 6;
            const string expectedText = "An excellent man; he has no enemies; and none of his friends like him.";
            const string expectedAuthor = "Oscar Wilde";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote7WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(6);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 7;
            const string expectedText = "We are what we repeatedly do; excellence, then, is not an act but a habit.";
            const string expectedAuthor = "Aristotle";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote8WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(7);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 8;
            const string expectedText = "Believe those who are seeking the truth. Doubt those who find it.";
            const string expectedAuthor = "André Gide";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote9WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(8);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 9;
            const string expectedText = "Be smarter than other people, just don't tell them so.";
            const string expectedAuthor = "H. Jackson Brown, Jr.";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [Test]
        public void GetRandomQuote_ReturnQuote10WhenRequested()
        {
            _fakeNumberGenerator.Setup(x => x.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(9);

            var sut = new QuoteRepository(_xDocLoader)
            {
                RandomNumberGenerator = _fakeNumberGenerator.Object
            };

            Quote quote = sut.GetRandomQuote(QuotesFilesPath);

            const int expectedId = 10;
            const string expectedText = "Really great people make you feel that you, too, can become great.";
            const string expectedAuthor = "Mark Twain";

            Assert.AreEqual(expectedId, quote.Id);
            Assert.AreEqual(expectedText, quote.Text);
            Assert.AreEqual(expectedAuthor, quote.Author);
        }

        [TearDown]
        public void TearDown()
        {
            _xDocLoader = null;
            _fakeNumberGenerator = null;
        }
    }
}
