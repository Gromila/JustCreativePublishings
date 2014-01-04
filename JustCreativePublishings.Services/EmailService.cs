using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public class EmailService : BaseService, IEmailService
    {
        String IEmailService.CreateConfirmationToken()
        {
            var guid = Guid.NewGuid().ToString();
            guid.Replace('&', '_').Replace('?', '_').Replace('/', '_').Replace('\\', '_');
            return guid;
        }

        void IEmailService.SendConfirmationToken(String to, String username, String url)
        {
            var message = new MailMessage { From = new MailAddress("gromilich@gmail.com") };
            message.To.Add(to);
            message.Body = url;
            message.Subject = "Confirm your registration";

            var credential = new NetworkCredential("gromilich@gmail.com", "DigitalThermo288");
            var client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = credential;
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
