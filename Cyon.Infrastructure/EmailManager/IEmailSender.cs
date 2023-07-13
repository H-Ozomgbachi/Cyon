namespace Cyon.Infrastructure.EmailManager
{
    public interface IEmailSender
    {
        Task SendEmail(Message message);
    }
}
