using SpeakHub.Service.Dtos.Common;

namespace SpeakHub.Service.Interfaces.Common
{
    public interface IEmailService
    {
        public Task<bool> SendAsync(EmailMessage emailMessage);
    }
}
