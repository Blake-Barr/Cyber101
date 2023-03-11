
using System.Net.Mail;
using System.Net;

namespace WatchfulEye.Models
{
    public class PhishingModel
    {
        /**
         * !WEEmail! - Replace with target email
         * !WELink! - Replace with link
        **/
        public void sendEmail(EmailTemplate e, string address, string name, string id)
        {
            var smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("", ""),
                EnableSsl = true,
            };

            var emailhtml = e.HTML.Replace("!WEEmail!", address);
            emailhtml = emailhtml.Replace("!WEName!", name);
            emailhtml = emailhtml.Replace("!WELink!", "https://localhost:7128/WatchfulEye/Fooled?userId=" + id);
            emailhtml = emailhtml.Replace("!WESite!", "https://localhost:7128/WatchfulEye/Fooled?userId=" + id);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(""),
                Subject = e.header,
                Body = emailhtml,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(address);

            smtpClient.Send(mailMessage);
        }
    }
}
