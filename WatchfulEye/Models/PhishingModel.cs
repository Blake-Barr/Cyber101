
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
                Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"ltr\"> \r\n<head>\r\n<style type=\"text/css\">\r\n .link:link, .link:active, .link:visited {\r\n       color:#2672ec !important;\r\n       text-decoration:none !important;\r\n }\r\n\r\n .link:hover {\r\n       color:#4284ee !important;\r\n       text-decoration:none !important;\r\n }\r\n</style>\r\n<title></title>\r\n</head>\r\n<body>\r\n<table dir=\"ltr\">\r\n      <tr><td id=\"i1\" style=\"padding:0; font-family:'Segoe UI Semibold', 'Segoe UI Bold', 'Segoe UI', 'Helvetica Neue Medium', Arial, sans-serif; font-size:17px; color:#707070;\">Microsoft account</td></tr>\r\n      <tr><td id=\"i2\" style=\"padding:0; font-family:'Segoe UI Light', 'Segoe UI', 'Helvetica Neue Medium', Arial, sans-serif; font-size:41px; color:#2672ec;\">Password reset code</td></tr>\r\n      <tr><td id=\"i3\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">Please use this code to reset the password for the Microsoft account <a dir=\"ltr\" id=\"iAccount\" class=\"link\" style=\"color:#2672ec; text-decoration:none\" href=\"Johndoe8674@Gmail.com\">Johndoe8674@Gmail.com</a>.</td></tr>\r\n      <tr><td id=\"i4\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">Here is your code: <span style=\"font-family:'Segoe UI Bold', 'Segoe UI Semibold', 'Segoe UI', 'Helvetica Neue Medium', Arial, sans-serif; font-size:14px; font-weight:bold; color:#2a2a2a;\">9631677</span></td></tr>\r\n      <tr><td id=\"i5\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">\r\n                \r\n                If you don't recognize the Microsoft account <a dir=\"ltr\" id=\"iAccount\" class=\"link\" style=\"color:#2672ec; text-decoration:none\" href=\"Johndoe8674@Gmail.com\">Johndoe8674@Gmail.com</a>, you can <a id=\"iLink2\" class=\"link\" style=\"color:#2672ec; text-decoration:none\" href=\"Random WebSite\">click here</a> to remove your email address from that account.\r\n            </td></tr>\r\n      <tr><td id=\"i6\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">Thanks,</td></tr>\r\n      <tr><td id=\"i7\" style=\"padding:0; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">The Microsoft account team</td></tr>\r\n</table>\r\n</body>\r\n</html>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add("barrbm@mail.uc.edu");

            smtpClient.Send(mailMessage);
        }

        /**
         * !WEEmail! - Replace with target email
         * !WELink! - Replace with link
        **/
        public void sendEmail(EmailTemplate e, string address, string name)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("watchfuleyeapp@gmail.com", "pkuvxmbqhkaffant"),
                EnableSsl = true,
            };

            var emailhtml = e.HTML.Replace("!WEEmail!", address);
            emailhtml = emailhtml.Replace("!WEName!", name);
            emailhtml = emailhtml.Replace("!WELink!", "https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            emailhtml = emailhtml.Replace("!WESite!", "https://localhost:7128/WatchfulEye/ShadySiteExample");

            var mailMessage = new MailMessage
            {
                From = new MailAddress("watchfuleyeapp@gmail.com"),
                Subject = e.header,
                Body = emailhtml,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(address);

            smtpClient.Send(mailMessage);
        }
    }
}
