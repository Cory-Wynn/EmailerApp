using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EmailerApp
{
    class Email
    {
        string MailSmtpHost { get; set; }
        int MailSmtpPort { get; set; }
        string MailSmtpUsername { get; set; }
        string MailSmtpPassword { get; set; }
        string MailFrom { get; set; }

        // Constructor
        public Email()
        {
            MailSmtpHost = ConfigurationManager.AppSettings["MailSmtpHost"];
            MailSmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailSmtpPort"]);
            MailSmtpUsername = ConfigurationManager.AppSettings["MailSmtpUsername"];
            MailSmtpPassword = ConfigurationManager.AppSettings["MailSmtpPassword"];
            MailFrom = ConfigurationManager.AppSettings["MailFrom"];
        }

        public bool SendEmail(string subject, string body, string to)
        {
            MailMessage mail = new MailMessage(MailFrom, to, subject, body);
            var alternameView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));
            mail.AlternateViews.Add(alternameView);

            var smtpClient = new SmtpClient(MailSmtpHost, MailSmtpPort);
            smtpClient.Credentials = new NetworkCredential(MailSmtpUsername, MailSmtpPassword);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            try
            {
                smtpClient.Send(mail);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                throw;
            }

            return true;
        }
    }
}

