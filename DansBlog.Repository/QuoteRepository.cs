using DansBlog.Model.Domain;
using DansBlog.Repository.Interfaces;
using DansBlog.Utilities.Interfaces;
using DansBlog.Utilities.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DansBlog.Repository
{
    public class QuoteRepository : IQuoteRepository<Quote>
    {
        private readonly IXDocumentLoader _ixDocumentLoader;

        public DefaultQuoteGenerator DefaultQuoteGenerator { get; set; }

        public IRandomNumberGenerator RandomNumberGenerator { get; set; }


        public QuoteRepository(IXDocumentLoader ixDocumentLoader)
        {
            _ixDocumentLoader = ixDocumentLoader;

            RandomNumberGenerator = new RandomNumberGenerator();
            DefaultQuoteGenerator = new DefaultQuoteGenerator();
        }

        public Quote GetRandomQuote(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return DefaultQuoteGenerator.GetDefaultQuote();

            string text, author;

            int randomIndex;

            try
            {
                XDocument doc = _ixDocumentLoader.LoadXDocument(filePath);

                randomIndex = RandomNumberGenerator.GetRandomNumber(1, doc.Descendants("quote").Count());

                var xElement = doc.Element("quotes");

                List<XElement> quoteDescendants = xElement.Descendants("quote").ToList();

                text = quoteDescendants.ElementAt(randomIndex).Element("text").Value;

                author = quoteDescendants.ElementAt(randomIndex).Element("author").Value;
            }
            catch (NullReferenceException)
            {
                return DefaultQuoteGenerator.GetDefaultQuote();
            }

            var quote = new Quote(randomIndex + 1, text, author);

            return quote;
        }
    }

    public class DefaultQuoteGenerator
    {
        public virtual Quote GetDefaultQuote()
        {
            return new Quote(id: 0,text: "Default Quote", author: "Default Author");
        }
    }
}
