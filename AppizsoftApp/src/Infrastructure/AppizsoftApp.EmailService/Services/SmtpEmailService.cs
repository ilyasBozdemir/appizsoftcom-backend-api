
namespace AppizsoftApp.Infrastructure.Services
{
    using AppizsoftApp.Application.Interfaces.Services;
    using Microsoft.Extensions.Configuration;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class SmtpEmailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private IConfigurationSection SmtpSettings;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _displayName;

        public SmtpEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            SmtpSettings = _configuration.GetSection("SmtpSettings");
            _smtpServer = SmtpSettings["Server"];
            _smtpPort = int.Parse(SmtpSettings["Port"]);
            _smtpUsername = SmtpSettings["Username"];
            _smtpPassword = SmtpSettings["Password"];
            _displayName = SmtpSettings["DisplayName"];
        }
        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true, byte[] attachment = null, string attachmentFileName = null)
        {
            var smtpClient = new SmtpClient
            {
                Host = _smtpServer,
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUsername),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            foreach (var to in tos)
                mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.From = new(_smtpUsername, _displayName, System.Text.Encoding.UTF8);


            if (attachment != null && !string.IsNullOrEmpty(attachmentFileName))
            {
                var attachmentStream = new System.IO.MemoryStream(attachment);
                var attachmentData = new Attachment(attachmentStream, attachmentFileName);
                mailMessage.Attachments.Add(attachmentData);
            }


            await smtpClient.SendMailAsync(mailMessage);

        }

        public Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            throw new NotImplementedException();
        }

        public Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true, byte[] attachment = null, string attachmentFileName = null)
         => await SendMailAsync(new[] { to }, subject, body, isBodyHtml, attachment, attachmentFileName);
    }

}
