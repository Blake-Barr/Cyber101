
using System.Net.Mail;
using System.Net;

namespace WatchfulEye.Models
{
    public class PhishingModel
    {
        public void testCreateEmail()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("watchfuleyeapp@gmail.com", "pkuvxmbqhkaffant"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("watchfuleyeapp@gmail.com"),
                Subject = "subject",
                Body = "<h1>Hello</h1>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add("barrbm@mail.uc.edu");

            smtpClient.Send(mailMessage);
        }
    }
}
