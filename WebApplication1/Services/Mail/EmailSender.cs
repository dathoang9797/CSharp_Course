using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace WebAppFruitables.Services.Mail;

public class EmailSender : IEmailSender
{
    private MailSettings settings;

    public EmailSender(IOptions<MailSettings> options) => settings = options.Value;

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        if (settings.Host != null)
        {
            using SmtpClient client = new SmtpClient();
            client.Host = settings.Host;
            client.Port = settings.Port;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(settings.Email, settings.Password);

            using MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            if (settings.Email != null)
                message.From = new MailAddress(settings.Email, settings.DisplayName);

            message.To.Add(new MailAddress(email));
            await client.SendMailAsync(message);
        }
    }
}