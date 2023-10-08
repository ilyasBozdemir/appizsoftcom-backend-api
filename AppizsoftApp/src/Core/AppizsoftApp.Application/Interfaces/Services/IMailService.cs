using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true, byte[] attachment = null, string attachmentFileName = null);
        Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true, byte[] attachment = null, string attachmentFileName = null);
        Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
    }
}
