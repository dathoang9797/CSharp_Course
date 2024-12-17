using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace WebAppFruitable.Services.Mail;

public class EmailSender : IEmailSender
{
    private MailSettings _settings;

    public EmailSender(IOptions<MailSettings> options) => _settings = options.Value;

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        if (_settings.Host != null)
        {
            using SmtpClient client = new SmtpClient();
            client.Host = _settings.Host;
            client.Port = _settings.Port;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_settings.Email, _settings.Password);

            using MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            if (_settings.Email != null)
                message.From = new MailAddress(_settings.Email, _settings.DisplayName);

            message.To.Add(new MailAddress(email));
            await client.SendMailAsync(message);
        }
    }
}