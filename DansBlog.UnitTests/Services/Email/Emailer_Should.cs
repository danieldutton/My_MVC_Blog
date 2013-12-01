using DansBlog.Services.Email.Model;
using NUnit.Framework;

namespace DansBlog._UnitTests.Services.Email
{
    [TestFixture]
    public class Emailer_Should
    {
        [Test]
        public void Message_SetSMTPClientWithTheCorrectSmtpServerValue()
        {
            var emailSettings = new EmailSettings("smtpServer", "targetEmail");

            //var sut = new Emailer(settings);
        }
    }
}
