
namespace AppizsoftApp.Infrastructure.Services
{
    using AppizsoftApp.Application.Interfaces.Services;
    using Microsoft.Extensions.Configuration;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class SmtpEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private IConfigurationSection SmtpSettings;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public SmtpEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            SmtpSettings = _configuration.GetSection("SmtpSettings");
            _smtpServer = SmtpSettings["Server"];
            _smtpPort = int.Parse(SmtpSettings["Port"]);
            _smtpUsername = SmtpSettings["Username"];
            _smtpPassword = SmtpSettings["Password"];
        }

        public async Task SendEmailAsync(string to, string subject, string body)
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

            mailMessage.To.Add(to);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }

}
