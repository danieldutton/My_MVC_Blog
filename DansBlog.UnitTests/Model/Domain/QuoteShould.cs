﻿using DansBlog.Model.Domain;
using NUnit.Framework;

namespace DansBlog.UnitTests.Model.Domain
{
    [TestFixture]
    public class QuoteShould
    {
        [Test]
        public void ToString_ReturnTheCorrectString()
        {
            var quote = new Quote(0, "This is a really good quote", "Daniel Dutton");

            const string expected = "[Quote] Text: This is a really good quote Author: Daniel Dutton";
            string actual = quote.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
