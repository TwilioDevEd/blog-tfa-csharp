using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using Twilio;

namespace TFA.Web.Tests
{
    [TestFixture]
    public class SmsServiceTest
    {
        [Test]
        public async Task WhenSendAsync_MessageIsSent()
        {
            var mockClient = new Mock<TwilioRestClient>(string.Empty, string.Empty);
            mockClient
                .Setup(c => c.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new Message {Status = "queued"});
            var smsService = new SmsService(mockClient.Object);

            var identityMessage = new IdentityMessage
            {
                Destination = "+555 555",
                Body = "Your security code is 914203"
            };
            await smsService.SendAsync(identityMessage);

            mockClient.Verify(
                c => c.SendMessage(Config.TwilioNumber, identityMessage.Destination, identityMessage.Body), Times.Once);
        }
    }
}