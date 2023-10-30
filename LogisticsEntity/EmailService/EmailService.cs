using LogisticsDataCore.Interfaces.IEmailService;
using System.Net.Mail;
using System.Net;
using LogisticsDataCore.Constants;

namespace LogisticsEntity.EmailService
{
    public class EmailService : IEmailService
    {

        public async Task SendEmailAsync(string email, string subject, string message, string password)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(EmailConstants.Email);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(EmailConstants.ServiceSmtpMail, EmailConstants.SmtpPort))
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                         delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                                                 System.Net.Security.SslPolicyErrors sslPolicyErrors)
                         {
                             return true; // **** Always accept
                         };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(EmailConstants.Email, password);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }


            return;
        }

    }
}
