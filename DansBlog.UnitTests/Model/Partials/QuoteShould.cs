using DansBlog.Model.Partials;
using NUnit.Framework;

namespace DansBlog._UnitTests.Model.Partials
{
    [TestFixture]
    public class QuoteShould
    {
        [Test]
        public void ToString_ReturnTheCorrectString()
        {
            var quote = new Quote("This is a really good quote", "Daniel Dutton");

            const string expected = "[Quote] Text: This is a really good quote Author: Daniel Dutton";
            string actual = quote.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
