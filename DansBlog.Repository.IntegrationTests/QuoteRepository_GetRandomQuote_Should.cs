using DansBlog.Model.Partials;
using DansBlog.Repository.Interfaces;
using DansBlog.Repository.Repositories;
using DansBlog.Utilities;
using DansBlog.Utilities.Interfaces;
using DansBlog.Utilities.Xml;
using NUnit.Framework;

namespace DansBlog.IntegrationTests.Repository
{
    [TestFixture]
    public class QuoteRepository_GetRandomQuote_Should
    {
        private const string XmlFilePath = @"C:\Users\Dan\Desktop\Git\MyBlog\DansBlog.Repository.IntegrationTests\TestFiles\quotes.xml";

        private IXmlLoader _xmlLoader;

        private IQuoteRepository<Quote> _quoteRepos;


        [SetUp]
        public void Init()
        {
            _xmlLoader = new XmlLoader();
            _quoteRepos = new QuoteRepository(_xmlLoader);
        }

        [Test]
        public void NotReturnANullQuote()
        {
            Quote quote = _quoteRepos.GetRandomQuote(XmlFilePath);
            Assert.IsNotNull(quote);
        }

        [Test]
        public void ReturnAnObectOfTypeQuote()
        {
            Quote quote = _quoteRepos.GetRandomQuote(XmlFilePath);
            Assert.IsInstanceOf(typeof(Quote), quote);
        }

        [Test]
        public void ReturnAQuoteWithPopulatedTextValue()
        {
            Quote quote = _quoteRepos.GetRandomQuote(XmlFilePath);
            Assert.IsNotNullOrEmpty(quote.Text);
        }

        [Test]
        public void ReturnAQuoteWithPopulatedAuthorValue()
        {
            Quote quote = _quoteRepos.GetRandomQuote(XmlFilePath);
            Assert.IsNotNullOrEmpty(quote.Author);
        }

        [TearDown]
        public void TearDown()
        {
            _quoteRepos = null;
        }
              
    }

}
