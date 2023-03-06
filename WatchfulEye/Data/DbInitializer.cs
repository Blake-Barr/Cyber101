﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using WatchfulEye.Models;
using WatchfulEye.Models.Simulator;

namespace WatchfulEye.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(WatchfulEyeContext cx, IApplicationBuilder app, IServiceScope scope)
        {

            //cx.Database.EnsureDeleted();

            //cx.Database.Migrate();

            if (cx.emailTemplates.Any())
            {
                foreach (var entity in cx.emailTemplates)
                    cx.emailTemplates.Remove(entity);
                cx.SaveChanges();
                //return;
            }

            if (cx.fakeSites.Any())
            {
                foreach (var entity in cx.fakeSites)
                    cx.fakeSites.Remove(entity);
                cx.SaveChanges();
                //return;
            }

            if (cx.simContent.Any())
            {
                foreach (var entity in cx.fakeSites)
                    cx.fakeSites.Remove(entity);
                cx.SaveChanges();
                //return;
            }

            if (cx.Users.Any())
            {
                //return;
            }

            var emails = new EmailTemplate[]
            {
                new EmailTemplate{difficultyLevel=0,name="test email",HTML="<h1>Hello</h1>",header="test email"},
                new EmailTemplate{difficultyLevel=1,name="Please Reset Your Password (Microsoft)",HTML="<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"ltr\"> \r\n<head>\r\n<style type=\"text/css\">\r\n .link:link, .link:active, .link:visited {\r\n       color:#2672ec !important;\r\n       text-decoration:none !important;\r\n }\r\n\r\n .link:hover {\r\n       color:#4284ee !important;\r\n       text-decoration:none !important;\r\n }\r\n</style>\r\n<title></title>\r\n</head>\r\n<body>\r\n<table dir=\"ltr\">\r\n      <tr><td id=\"i1\" style=\"padding:0; font-family:'Segoe UI Semibold', 'Segoe UI Bold', 'Segoe UI', 'Helvetica Neue Medium', Arial, sans-serif; font-size:17px; color:#707070;\">Microsoft account</td></tr>\r\n      <tr><td id=\"i2\" style=\"padding:0; font-family:'Segoe UI Light', 'Segoe UI', 'Helvetica Neue Medium', Arial, sans-serif; font-size:41px; color:#2672ec;\">Password reset code</td></tr>\r\n      <tr><td id=\"i3\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">Please use this code to reset the password for the Microsoft account <a dir=\"ltr\" id=\"iAccount\" class=\"link\" style=\"color:#2672ec; text-decoration:none\" href=\"!WELink!\">!WEEmail!</a>.</td></tr>\r\n      <tr><td id=\"i4\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">Here is your code: <span style=\"font-family:'Segoe UI Bold', 'Segoe UI Semibold', 'Segoe UI', 'Helvetica Neue Medium', Arial, sans-serif; font-size:14px; font-weight:bold; color:#2a2a2a;\">9631677</span></td></tr>\r\n      <tr><td id=\"i5\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">\r\n                \r\n                If you don't recognize the Microsoft account <a dir=\"ltr\" id=\"iAccount\" class=\"link\" style=\"color:#2672ec; text-decoration:none\" href=\"!WELink!\">!WEEmail!</a>, you can <a id=\"iLink2\" class=\"link\" style=\"color:#2672ec; text-decoration:none\" href=\"!WELink!\">click here</a> to remove your email address from that account.\r\n            </td></tr>\r\n      <tr><td id=\"i6\" style=\"padding:0; padding-top:25px; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">Thanks,</td></tr>\r\n      <tr><td id=\"i7\" style=\"padding:0; font-family:'Segoe UI', Tahoma, Verdana, Arial, sans-serif; font-size:14px; color:#2a2a2a;\">The Microsoft account team</td></tr>\r\n</table>\r\n</body>\r\n</html>",header="Please Reset Your Password"},
                new EmailTemplate{difficultyLevel=1,name="Capital Line Credit Line",HTML="<html lang=\"en\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:v=\"urn:schemas-microsoft-com:vml\">\r\n<head>\r\n<title></title>\r\n<meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\"/>\r\n<meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\"/>\r\n<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->\r\n<style>\r\n\t\t* {\r\n\t\t\tbox-sizing: border-box;\r\n\t\t}\r\n\r\n\t\tbody {\r\n\t\t\tmargin: 0;\r\n\t\t\tpadding: 0;\r\n\t\t}\r\n\r\n\t\ta[x-apple-data-detectors] {\r\n\t\t\tcolor: inherit !important;\r\n\t\t\ttext-decoration: inherit !important;\r\n\t\t}\r\n\r\n\t\t#MessageViewBody a {\r\n\t\t\tcolor: inherit;\r\n\t\t\ttext-decoration: none;\r\n\t\t}\r\n\r\n\t\tp {\r\n\t\t\tline-height: inherit\r\n\t\t}\r\n\r\n\t\t.desktop_hide,\r\n\t\t.desktop_hide table {\r\n\t\t\tmso-hide: all;\r\n\t\t\tdisplay: none;\r\n\t\t\tmax-height: 0px;\r\n\t\t\toverflow: hidden;\r\n\t\t}\r\n\r\n\t\t@media (max-width:620px) {\r\n\t\t\t.desktop_hide table.icons-inner {\r\n\t\t\t\tdisplay: inline-block !important;\r\n\t\t\t}\r\n\r\n\t\t\t.icons-inner {\r\n\t\t\t\ttext-align: center;\r\n\t\t\t}\r\n\r\n\t\t\t.icons-inner td {\r\n\t\t\t\tmargin: 0 auto;\r\n\t\t\t}\r\n\r\n\t\t\t.row-content {\r\n\t\t\t\twidth: 100% !important;\r\n\t\t\t}\r\n\r\n\t\t\t.mobile_hide {\r\n\t\t\t\tdisplay: none;\r\n\t\t\t}\r\n\r\n\t\t\t.stack .column {\r\n\t\t\t\twidth: 100%;\r\n\t\t\t\tdisplay: block;\r\n\t\t\t}\r\n\r\n\t\t\t.mobile_hide {\r\n\t\t\t\tmin-height: 0;\r\n\t\t\t\tmax-height: 0;\r\n\t\t\t\tmax-width: 0;\r\n\t\t\t\toverflow: hidden;\r\n\t\t\t\tfont-size: 0px;\r\n\t\t\t}\r\n\r\n\t\t\t.desktop_hide,\r\n\t\t\t.desktop_hide table {\r\n\t\t\t\tdisplay: table !important;\r\n\t\t\t\tmax-height: none !important;\r\n\t\t\t}\r\n\t\t}\r\n\t</style>\r\n</head>\r\n<body style=\"background-color: transparent; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;\">\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"nl-container\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: transparent;\" width=\"100%\">\r\n<tbody>\r\n<tr>\r\n<td>\r\n<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tbody>\r\n<tr>\r\n<td>\r\n<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #cfd7e5; color: #000000; width: 600px;\" width=\"600\">\r\n<tbody>\r\n<tr>\r\n<td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"button_block block-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<div align=\"center\" class=\"alignment\">\r\n<!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" href=\"!WELink!\" style=\"height:63px;width:231px;v-text-anchor:middle;\" arcsize=\"96%\" stroke=\"false\" fillcolor=\"#e64016\"><w:anchorlock/><v:textbox inset=\"0px,0px,0px,0px\"><center style=\"color:#093b82; font-family:Arial, sans-serif; font-size:25px\"><![endif]--><a href=\"!WELink!\" style=\"text-decoration:none;display:inline-block;color:#093b82;background-color:#e64016;border-radius:60px;width:auto;border-top:0px solid transparent;font-weight:400;border-right:0px solid transparent;border-bottom:0px solid transparent;border-left:0px solid transparent;padding-top:5px;padding-bottom:5px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;\" target=\"_blank\"><span style=\"padding-left:20px;padding-right:20px;font-size:25px;display:inline-block;letter-spacing:normal;\"><span dir=\"ltr\" style=\"word-break: break-word; line-height: 50px;\"><strong>Capital One 2022</strong></span></span></a>\r\n<!--[if mso]></center></v:textbox></v:roundrect><![endif]-->\r\n</div>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"divider_block block-2\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<div align=\"center\" class=\"alignment\">\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"25%\">\r\n<tr>\r\n<td class=\"divider_inner\" style=\"font-size: 1px; line-height: 1px; border-top: 3px solid #E64016;\"><span>â€Š</span></td>\r\n</tr>\r\n</table>\r\n</div>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"heading_block block-3\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\" style=\"width:100%;text-align:center;\">\r\n<h1 style=\"margin: 0; color: #093b82; font-size: 22px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;\"><sub>Reward  Center</sub></h1>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"button_block block-4\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\" style=\"text-align:center;\">\r\n<div align=\"center\" class=\"alignment\">\r\n<!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" href=\"!WELink!\" style=\"height:118px;width:594px;v-text-anchor:middle;\" arcsize=\"4%\" stroke=\"false\" fillcolor=\"#093b82\"><w:anchorlock/><v:textbox inset=\"0px,0px,0px,0px\"><center style=\"color:#ffffff; font-family:Arial, sans-serif; font-size:24px\"><![endif]--><a href=\"!WELink!\" style=\"text-decoration:none;display:inline-block;color:#ffffff;background-color:#093b82;border-radius:4px;width:auto;border-top:0px solid #093B82;font-weight:400;border-right:0px solid #093B82;border-bottom:0px solid #093B82;border-left:0px solid #093B82;padding-top:35px;padding-bottom:35px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;\" target=\"_blank\"><span style=\"padding-left:60px;padding-right:60px;font-size:24px;display:inline-block;letter-spacing:normal;\"><span dir=\"ltr\" style=\"word-break: break-word; line-height: 48px;\"><strong>Congrats!, Your credit line   has increased</strong></span></span></a>\r\n<!--[if mso]></center></v:textbox></v:roundrect><![endif]-->\r\n</div>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"15\" cellspacing=\"0\" class=\"button_block block-5\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<div align=\"center\" class=\"alignment\">\r\n<!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" href=\"!WELink!\" style=\"height:64px;width:282px;v-text-anchor:middle;\" arcsize=\"94%\" strokeweight=\"2.25pt\" strokecolor=\"#093b82\" fillcolor=\"#093b82\"><w:anchorlock/><v:textbox inset=\"0px,0px,0px,0px\"><center style=\"color:#ffffff; font-family:Arial, sans-serif; font-size:19px\"><![endif]--><a href=\"!WELink!\" style=\"text-decoration:none;display:inline-block;color:#ffffff;background-color:#093b82;border-radius:60px;width:auto;border-top:3px solid transparent;font-weight:400;border-right:3px solid transparent;border-bottom:3px solid transparent;border-left:3px solid transparent;padding-top:10px;padding-bottom:10px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;\" target=\"_blank\"><span style=\"padding-left:60px;padding-right:60px;font-size:19px;display:inline-block;letter-spacing:1px;\"><span dir=\"ltr\" style=\"word-break: break-word; line-height: 38px;\"><strong>Reward Details</strong></span></span></a>\r\n<!--[if mso]></center></v:textbox></v:roundrect><![endif]-->\r\n</div>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"list_block block-6\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<ul style=\"margin: 0; padding: 0; margin-left: 20px; list-style-type: revert; color: #101112; font-size: 18px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; font-weight: 400; line-height: 120%; text-align: left; direction: ltr; letter-spacing: 0px;\">\r\n<li>Reward Date 10/19/2022 </li>\r\n</ul>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"list_block block-7\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<ul style=\"margin: 0; padding: 0; margin-left: 20px; list-style-type: revert; color: #101112; font-size: 18px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; font-weight: 400; line-height: 120%; text-align: left; direction: ltr; letter-spacing: 0px;\">\r\n<li>Reward number    15 - CF14S</li>\r\n</ul>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"list_block block-8\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<ul style=\"margin: 0; padding: 0; margin-left: 20px; list-style-type: revert; color: #101112; font-size: 18px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; font-weight: 400; line-height: 120%; text-align: left; direction: ltr; letter-spacing: 0px;\">\r\n<li>Reward Credit    $90.00</li>\r\n</ul>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"15\" cellspacing=\"0\" class=\"heading_block block-9\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<h1 style=\"margin: 0; color: #093b82; font-size: 26px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;\"><strong>Thanks for being a Capital One customer.</strong></h1>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"divider_block block-10\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<div align=\"center\" class=\"alignment\">\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"45%\">\r\n<tr>\r\n<td class=\"divider_inner\" style=\"font-size: 1px; line-height: 1px; border-top: 3px solid #093B82;\"><span>â€Š</span></td>\r\n</tr>\r\n</table>\r\n</div>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"heading_block block-11\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\" style=\"width:100%;text-align:center;\">\r\n<h1 style=\"margin: 0; color: #093b82; font-size: 20px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;\">This notification email is to inform you that you<br/>have an unclaimed $90 reward</h1>\r\n</td>\r\n</tr>\r\n</table>\r\n<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"button_block block-12\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\r\n<tr>\r\n<td class=\"pad\">\r\n<div align=\"center\" class=\"alignment\">\r\n<!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" href=\"!WELink!\" style=\"height:46px;width:162px;v-text-anchor:middle;\" arcsize=\"9%\" stroke=\"false\" fillcolor=\"#093b82\"><w:anchorlock/><v:textbox inset=\"0px,0px,0px,0px\"><center style=\"color:#ffffff; font-family:Arial, sans-serif; font-size:18px\"><![endif]--><a href=\"!WELink!\" style=\"text-decoration:none;display:inline-block;color:#ffffff;background-color:#093b82;border-radius:4px;width:auto;border-top:0px solid #093B82;font-weight:400;border-right:0px solid #093B82;border-bottom:0px solid #093B82;border-left:0px solid #093B82;padding-top:5px;padding-bottom:5px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;\" target=\"_blank\"><span style=\"padding-left:20px;padding-right:20px;font-size:18px;display:inline-block;letter-spacing:normal;\"><span dir=\"ltr\" style=\"word-break: break-word; line-height: 36px;\"><strong>CLICKE HERE</strong></span></span></a>\r\n<!--[if mso]></center></v:textbox></v:roundrect><![endif]-->\r\n</div>\r\n</td>\r\n</tr>\r\n</table>\r\n</td>\r\n</tr>\r\n</tbody>\r\n</table>\r\n</td>\r\n</tr>\r\n</tbody>\r\n</table>\r\n<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>\r\n</a>\r\n<center>\r\n<p>if you want to unsubscribe <a href=\"!WELink!\">click here</p>\r\n</a><br>\r\n<style>\r\n\r\n}\r\n</style>\r\n  </body>\r\n\r\n<center><h6> <center><p style=\"text-align:center;font-family: 'Open Sans','Arial','Helvetica',sans-serif;font-size:13px;\"><br><br> \r\nThe advertiser does not manage your subscription. <br>\r\n If you prefer not to receive further communication please unsubscribe  <a href=\"!WELink!\">   here </a><br>\r\n</body>\r\n</center>\r\n<html>\r\n<head>\r\n<title></title>\r\n</head>\r\n<body>\r\n",header="Y͏o͏u͏r͏ C͏a͏p͏i͏t͏a͏l͏ O͏n͏e͏ C͏r͏e͏d͏i͏t͏ L͏i͏n͏e͏ h͏a͏s͏ i͏n͏c͏r͏e͏a͏s͏e͏d͏!"},
                new EmailTemplate{difficultyLevel=1,name="Package Notification from FedEx",HTML="<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>Professional Publication</title>\r\n\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>\r\n</head>\r\n<a href=\"!WELink!\"style=\" font-family: 'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-seri; font-size: 15px; color: #181717; text-decoration:none;\">  <center><p style=\"font-size: 70px; margin: 10px; text-align: center; color: #127AC4\"><b style=\"color:#290078;\">Fed</b><b style=\"color:#f75600;\">Ex</b></b></p></center>\r\n\r\n<div style=\"width: 690px; display: block; margin: auto; background: #cfbbe0; padding: 10px; border-radius: 5px\">\r\n\r\n <div style=\"width: 680px; display: block; margin: auto; border: 5px solid #290078; border-radius: 5px; background: #FFFFFF\">\r\n  \r\n\r\n\r\n<h1 style=\"font-size: 30px; margin: 30px 0px; color: #787777; text-align: CENTER;\">DELIVERY OF THE SUSPENDED <BR>PACKAGE</h1>\r\n\r\n<div style=\"font-size: 20px; margin: 30px 0px; letter-spacing: 1px ; text-align: center;color:black\">\r\n<p>!WEName!, You have (1) package waiting for delivery. Use your code to<br>\r\ntrack it and receive it<BR><BR>\r\n<I>Schedule your delivery and subscribe to our calendar<br>\r\nnotifications to avoid this from happening again!</I>\r\n\r\n\r\n</p>\r\n</div>\r\n\r\n<h1 style=\"text-align: center; font-size: 24px; display: block; margin: auto; width: 310px; padding: 15px 0; background: #f75600; color: white; border: 5px solid #fff;;\"><b> Your tracking code\r\n</b></h1>\r\n\r\n<h1 style=\"text-align: center; font-size: 24px; display: block; margin: auto; width: 600px; padding: 15px 0; background: #ebebeb; color: black; border: 1px solid silver;;\"><b> 29194772\r\n</b></h1><br>\r\n\r\n\r\n<br>\r\n\r\n </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n</div></div><div><br>\r\n<h1 style=\"text-align: center; font-size: 24px; display: block; margin: auto; width: 350px; padding: 10px 0; background: #290078; color: white; border: 5px solid #290078;border-radius:50px;\"><b> Your tracking code\r\n</b></h1></a>\r\n\r\n       <p style=\"text-align:center;font-family: 'Open Sans','Arial','Helvetica',sans-serif;font-size:13px;\"><br><br>\r\nYou may unsubscribe at any time<a href=\"!WELink!\"> Unsubscribe </a><br> \r\n\r\n \r\n<br>\r\n <p>\t  \t    <p style=\"text-align:center;font-family: 'Open Sans','Arial','Helvetica',sans-serif;font-size:13px;\"><br><br> \r\nThe advertiser does not manage your subscription. <br>\r\n If you prefer not to receive further communication please unsubscribe  <a href=\"!WELink!\">   here </a><br>\r\n \r\n<br>\r\n </p><br />\r\n <br />\r\n <br />\r\n </p>\r\n </div>\r\n<p>  </p>\r\n <p> </p></td>\r\n </tr>\r\n</body></html>\r\n\r\n\r\n--000000000000B0MNRUNyYR84HR9b--\r\n--000000000000B0MNRUNyYR84HR9a--\r\n--000000000000SGCNuB7Qm6umj710elBSQB--\r\n",header="2nd Attempt_ Your package notification 📦😍(27304)"},
                new EmailTemplate{difficultyLevel=0,name="Shady Site Template Example",HTML="<h1>Hello !WEName!</h1> <h2>You should click <a href='!WESite!'>this malicious link</a> and give us your information</h2>",header="Look at this! it is important!!!"},
            };

            var sites = new FakeSite[]
            {
                new FakeSite{HTML="<html><style>h1  {color: red;}</style><body><h1>This is a test.</h1><p id='WE_SpotGameClue'>this is a bad thing!</p></body></html>",fakeURL="www.fake.com"}
            };

            var simContents = new SimulatorLevelContent[]
            {
                new SimulatorLevelContent{GameType = -1, HTMLContent = "<p> Level 1 </p>", LevelDescription="Welcome to the simulator! These first three levels will introduce you to some concepts related to phishing, as well as guide you through a tutorial level to get you familiar with the simulator level process. Have fun!"
                , LevelTitle="Simulator Tutorial - Part 1", TutorialLevel = 1},
                new SimulatorLevelContent{GameType = -1, HTMLContent = "<p> Level 2 </p>", LevelDescription="Level 2 Description"
                , LevelTitle="Simulator Tutorial - Part 2", TutorialLevel = 2},
                new SimulatorLevelContent{GameType = -1, HTMLContent = "<p> Level 3 </p>", LevelDescription="Level 3 Description"
                , LevelTitle="Simulator Tutorial - Part 3", TutorialLevel = 3},
                new SimulatorLevelContent{GameType = 0, HTMLContent = "<div id=\"quiz_body\">\r\n    <div class=\"question\">\r\n        <p>A method of authentication where an application proves the user's identity by requesting a user accomplish a specific task or set of tasks using other forms of identity verification (cell phones, emails, fingerprints, etc)</p>\r\n        <input type=\"radio\" id=\"a1\" name=\"q1\" value=\"A\">\r\n        <label for=\"a1\">Phishing</label><br>\r\n        <input type=\"radio\" id=\"a2\" name=\"q1\" value=\"B\">\r\n        <label for=\"a2\">Passwords</label><br>  \r\n        <input type=\"radio\" id=\"a3\" name=\"q1\" value=\"C\">\r\n        <label for=\"a3\">Multi-factor Authentication</label><br>\r\n        <input type=\"radio\" id=\"a4\" name=\"q1\" value=\"D\">\r\n        <label for=\"a4\">None of the above</label><br><br>\r\n    </div>\r\n    <div class=\"question\">\r\n        <p>Some services offer a feature to 'hide' your email when a website requests it, creating a disposable email address that will then redirect the requested information to your primary email. What is the primary benefit of this functionality?</p>\r\n        <input type=\"radio\" id=\"b1\" name=\"q2\" value=\"A\">\r\n        <label for=\"b1\">Prevents hackers from accessing your email via password guessing</label><br>\r\n        <input type=\"radio\" id=\"b2\" name=\"q2\" value=\"B\">\r\n        <label for=\"b2\">Hides your data from the website to reduce possible incoming spam</label><br>  \r\n        <input type=\"radio\" id=\"b3\" name=\"q2\" value=\"C\">\r\n        <label for=\"b3\">Secures the email exchange to prevent 'man in the middle' attacks.</label><br>\r\n        <input type=\"radio\" id=\"b4\" name=\"q2\" value=\"D\">\r\n        <label for=\"b4\">Allows Apple to build a superarmy of ICloud domains, as an effort towards their planned revolution.</label><br><br>\r\n    </div>\r\n    <div class=\"question\">\r\n        <p>What is the first thing you should do in the case that your password gets stolen?</p>\r\n        <input type=\"radio\" id=\"c1\" name=\"q3\" value=\"A\">\r\n        <label for=\"c1\">Delete the account you were trying to log into.</label><br>\r\n        <input type=\"radio\" id=\"c2\" name=\"q3\" value=\"B\">\r\n        <label for=\"c2\">Destroy your computer and live in the woods.</label><br>  \r\n        <input type=\"radio\" id=\"c3\" name=\"q3\" value=\"C\">\r\n        <label for=\"c3\">Cancel all of your credit cards.</label><br>\r\n        <input type=\"radio\" id=\"c4\" name=\"q3\" value=\"D\">\r\n        <label for=\"c4\">Change your password on all accounts connected to the stolen password.</label><br><br>\r\n    </div>\r\n</div>", LevelDescription="Quiz A desc"
                , LevelTitle="Quiz", TutorialLevel = 0, QuizAnswerKey = "CBD"},
                new SimulatorLevelContent{GameType = 0, HTMLContent = "<div id=\"quiz_body\">\r\n    <div class=\"question\">\r\n        <p>What are some things you should look out for to ensure the site you are visiting is not an impersonation?</p>\r\n        <input type=\"radio\" id=\"a1\" name=\"q1\" value=\"A\">\r\n        <label for=\"a1\">The URL</label><br>\r\n        <input type=\"radio\" id=\"a2\" name=\"q1\" value=\"B\">\r\n        <label for=\"a2\">Any low-quality, misleading or strange information on the site</label><br>  \r\n        <input type=\"radio\" id=\"a3\" name=\"q1\" value=\"C\">\r\n        <label for=\"a3\">Dead Links</label><br>\r\n        <input type=\"radio\" id=\"a4\" name=\"q1\" value=\"D\">\r\n        <label for=\"a4\">All of the above</label><br><br>\r\n    </div>\r\n    <div class=\"question\">\r\n        <p>If you receive a concerning email from a service, what is the best way to approach this issue?</p>\r\n        <input type=\"radio\" id=\"b1\" name=\"q2\" value=\"A\">\r\n        <label for=\"b1\">Directly reply to the email with the requested information.</label><br>\r\n        <input type=\"radio\" id=\"b2\" name=\"q2\" value=\"B\">\r\n        <label for=\"b2\">Use links in the email to get to their website to resolve the issue.</label><br>  \r\n        <input type=\"radio\" id=\"b3\" name=\"q2\" value=\"C\">\r\n        <label for=\"b3\">Contact the company using contact information from their official site.</label><br>\r\n    </div>\r\n    <div class=\"question\">\r\n        <p>What is a good practice to follow when creating a password?</p>\r\n        <input type=\"radio\" id=\"c1\" name=\"q3\" value=\"A\">\r\n        <label for=\"c1\">Use a lengthy mixture of characters, numbers and symbols that cannot easily be guessed.</label><br>\r\n        <input type=\"radio\" id=\"c2\" name=\"q3\" value=\"B\">\r\n        <label for=\"c2\">Use a password that you have created on another site.</label><br>  \r\n        <input type=\"radio\" id=\"c3\" name=\"q3\" value=\"C\">\r\n        <label for=\"c3\">Use simple words (password, admin)</label><br>\r\n        <input type=\"radio\" id=\"c4\" name=\"q3\" value=\"D\">\r\n        <label for=\"c4\">Ask someone to create a password for you.</label><br><br>\r\n    </div>\r\n</div>", LevelDescription="Quiz B desc"
                , LevelTitle="Quiz", TutorialLevel = 0, QuizAnswerKey = "DCA"},
                new SimulatorLevelContent{GameType = 0, HTMLContent = "<div id=\"quiz_body\">\r\n    <p>you are an employee of a small company, named NuSun, that houses 20 employees. You are one of the 4 Human Resource specilists within NuSun.\r\n        The other Three HR specialists are named Amy Douglas, Matt Ryan, and Ken Madden. The HR department always goes to lunch from 12pm to 1pm durning the week. <br>\r\n        At around 9am on a Tuesday, the HR department is notified that Matt won't be able to make it in due to being exposed to Covid 19. Ten minutes before your lunch break, you recieve an email from Matt.\r\n        In this email, Matt is requestion some information on an employee named Scott Robbert.<br>\r\n        In the next questions, choose the correct responses.\r\n    </p>\r\n    <div class=\"question\">\r\n        <p>From:Matt.Ryan@NuSun.com\r\n            <br />\r\n            To: hruser@NuSun.com\r\n            <br />\r\n            Hey,\r\n            <br />\r\n            <br />\r\n            I have messed up big time. I forgot that I need to give the Finance department Scott Robberts information so they can start his payroll.\r\n            <br />\r\n            I don't have time to follow the procedures. If you help me with this I will make it up to you in the future.</p>\r\n        <input type=\"radio\" id=\"a2\" name=\"q1\" value=\"A\">\r\n        <label for=\"a2\">Matt, I hope you are feeling better. Unfortunately I will not be able to obtain this information for you. We have procedures in place to protect our employees' information.</label><br>  \r\n        <input type=\"radio\" id=\"a3\" name=\"q1\" value=\"B\">\r\n        <label for=\"a3\">Happy to help you with this. I have attached the information you are seeking below. If there's anything else that needs to be done, please let me know.</label><br>\r\n    </div>\r\n    <div class=\"question\">\r\n        <p>From:Matt.Ryan@NuSun.com\r\n            <br />To: hruser@NuSun.com\r\n            <br />\r\n            Hey,\r\n            <br />\r\n            <br />\r\n            I really need to get this information turned in before the Finance team goes to lunch. This is very important and I know that I dropped the ball on this.\r\n            <br />\r\n            If I don't get this information over I will lose my job. You don't want me to lose my job over this mistake, do you?</p>\r\n        <input type=\"radio\" id=\"b1\" name=\"q2\" value=\"A\">\r\n        <label for=\"b1\">I do not want anyone to lose their job. I will be more than happy to help. I have attached the information you are seeking below. If there's anything else that needs to be done please let me know.</label><br>\r\n        <input type=\"radio\" id=\"b3\" name=\"q2\" value=\"B\">\r\n        <label for=\"b3\">This behavior is not common coming from you. I will be reporting this incident to management. I will not be helping you any further with this.</label><br>\r\n    </div>\r\n</div>", LevelDescription="Quiz C desc"
                , LevelTitle="Quiz", TutorialLevel = 0, QuizAnswerKey = "AB"}
            };

            var rm = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await rm.RoleExistsAsync(UserRoles.Admin))
                await rm.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await rm.RoleExistsAsync(UserRoles.User))
                await rm.CreateAsync(new IdentityRole(UserRoles.User));

            cx.emailTemplates.AddRange(emails);
            cx.fakeSites.AddRange(sites);
            cx.simContent.AddRange(simContents);
            cx.SaveChanges();
        }
    }
}
