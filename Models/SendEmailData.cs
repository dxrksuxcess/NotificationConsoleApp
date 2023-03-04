
namespace NotificationApp.Models
{
    public class SendEmailData
    {
        public string? SenderEmail { get; set; }
        public string? SenderName { get; set; }
        public string? PasswordOfSenderEmail { get; set; }
        public string? MailRuServerSmtp { get; set; }
        public int DefPortSmtp { get; set; }
        public int ReservePortSmtp { get; set; }

    }
}
