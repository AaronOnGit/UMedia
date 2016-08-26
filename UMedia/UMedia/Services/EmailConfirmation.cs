using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UMedia.Services
{
    public class EmailConfirmation
    {
        public async static Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var _email = "umedia@gmail.com";
                var epass = ConfigurationManager.AppSettings["EmailPassword"]; // get password from web.config
                var _dispName = "UMedia";
                MailMessage myMessage = new MailMessage();
                myMessage.To.Add(email);
                myMessage.From = new MailAddress(_email, _dispName);
                myMessage.Subject = subject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(myMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}