using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

            using System.Net.Mail;
            using System.Text;
namespace TranSmart.Static
{
    public class MailSender
    {
        SmtpClient client;
        public MailMessage Mail;
        public MailSender()
        {
            client = new SmtpClient();

            // Command line argument must the the SMTP host.
            client.Port = 25;// 587;// 465;// 2525;
            client.Host = "mail.transsmart.org";
            client.EnableSsl = false;// true;//
            client.Timeout = 20000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("info@transsmart.org", "Pass@mypro17"); 
            //client.Credentials = new System.Net.NetworkCredential("transmart@transteceg.com","Pass@mypro17"); 

            //("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");

            //
        }
        public Exception Send( string To, string Subject, string Body)
        {
            Mail = new MailMessage("info@transsmart.org", To, Subject, Body);
            Mail.IsBodyHtml = true;

            Mail.BodyEncoding = UTF8Encoding.UTF8;
            Mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            try
            {
                client.Send(Mail);
                return null;
            }
            catch (Exception ex)
            {
               Global.Log.Error("", ex);
               return ex;
            }            
        }
        public Exception Send(string To, string Subject, string Body,string FileName)
        {
            Mail = new MailMessage("transmart@transteceg.com", To, Subject, Body);
            Mail.IsBodyHtml = true;
            Attachment att = new Attachment(FileName);
            Mail.Attachments.Add(att);
            Mail.BodyEncoding = UTF8Encoding.UTF8;
            Mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            try
            {
                client.Send(Mail);
                return null;
            }
            catch (Exception ex)
            {
                Global.Log.Error("", ex);
                return ex;
            }
        }
        public void Send()
        {
            client.Send(Mail);
        }        
    }
}