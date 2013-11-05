using DansBlog.Services.Email.Model;

namespace DansBlog.Services.Email.Interfaces
{
    public interface IEmailer : IMessagingService
    {
        EmailSettings EmailSettings { get; set; }

        Contact Contact { get; set; }
    }
}
