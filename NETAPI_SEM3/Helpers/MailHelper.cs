using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MimeKit;
using NETAPI_SEM3.ViewModel;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DemoSession16.Helpers
{
    public class MailHelper
    {
        private IConfiguration configuration;
        public MailHelper(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public bool Send(string from, string to, string subject, string body)
        {
            try
            {
                var host = configuration["Gmail:Host"];
                var port = int.Parse(configuration["Gmail:Port"]);
                var username = configuration["Gmail:Username"];
                var password = configuration["Gmail:Password"];
                var enable = bool.Parse(configuration["Gmail:SMTP:starttls:enable"]);
                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };
                var mailMessage = new MailMessage(from, to);
                mailMessage.Subject = subject;
                //mailMessage.IsBodyHtml = true;
                mailMessage.Body = body;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Send(string from, string to, string subject, string body, string htmlAttachment)
        {
            try
            {
                var host = configuration["Gmail:Host"];
                var port = int.Parse(configuration["Gmail:Port"]);
                var username = configuration["Gmail:Username"];
                var password = configuration["Gmail:Password"];
                var enable = bool.Parse(configuration["Gmail:SMTP:starttls:enable"]);
                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };
                var mailMessage = new MailMessage(from, to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                if (!string.IsNullOrEmpty(htmlAttachment))
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write(htmlAttachment);
                            writer.Flush();
                            stream.Position = 0;
                            mailMessage.Attachments.Add(new Attachment(stream, "ConfirmEmail", "text/html"));
                            smtpClient.Send(mailMessage);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetMailBody(string userId, string token)
        {
            //string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={user.Id}&token={validEmailToken}";

            string url = "http://localhost:5000/api/account/emailconfirmation?userId=" + userId + "&token=" + token;


          
            return string.Format(@"<div style='text-align:center;'>
                     <h1>Welcome to our Web Site</h1>
                        <h3>Click below button for verify your Email Id</h3>
                        <form method='post' action='{0}' style='display: inline;'>
                            <button type='submit' style='display: inline; 
                                text-align: center; font-weight: bold; background-color: #008cba; 
                                border-radius: 10px; color: #ffffff; cursor: pointer; width: 100%; padding: 10px;'>
                                Confirm Email
                            </ button >
                        </ form >
                    </ div > ", url, userId);
        }
    }
}
