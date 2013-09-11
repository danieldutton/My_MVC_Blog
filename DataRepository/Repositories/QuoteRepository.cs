using DansBlog.Model.Partials;
using DansBlog.Repository.Interfaces;
using DansBlog.Utilities.Interfaces;
using DansBlog.Utilities.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DansBlog.Repository.Repositories
{
    public class QuoteRepository : IQuoteRepository<Quote>
    {
        private readonly IXmlLoader _xmlLoader;

        public DefaultQuoteGenerator DefaultQuoteGenerator { get; set; }

        public IRandomNumberGenerator RandomNumberGenerator { get; set; }


        public QuoteRepository(IXmlLoader xmlLoader)
        {
            _xmlLoader = xmlLoader;

            RandomNumberGenerator = new RandomNumberGenerator();
            DefaultQuoteGenerator = new DefaultQuoteGenerator();
        }

        public Quote GetRandomQuote(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return DefaultQuoteGenerator.GetDefaultQuote();

            string text, author;

            try
            {
                XDocument doc = _xmlLoader.LoadXml(filePath);

                int randomIndex = RandomNumberGenerator.GetRandomNumber(0, doc.Descendants("quote").Count());

                var xElement = doc.Element("quotes");

                List<XElement> quoteDescendants = xElement.Descendants("quote").ToList();

                text = quoteDescendants.ElementAt(randomIndex).Element("text").Value;

                author = quoteDescendants.ElementAt(randomIndex).Element("author").Value;
            }
            catch (NullReferenceException)
            {
                return DefaultQuoteGenerator.GetDefaultQuote();
            }

            var quote = new Quote(text, author);

            return quote;
        }
    }

    public class DefaultQuoteGenerator
    {
        public virtual Quote GetDefaultQuote()
        {
            return new Quote(text: "Default Quote", author: "Default Author");
        }
    }
}
