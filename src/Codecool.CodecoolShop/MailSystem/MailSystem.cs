using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace Codecool.CodecoolShop.MailSystem
{
    public class MailSystem
    {
        public MailSystem()
        {
                
        }

        public static void SendEmail(string sName, string sEmail, string sSubject, string sMessage, string emailType, bool isOrder = false) // működik, a formot kell csak beállítani
        {// ezeket majd a form-ból kapjuk meg, és paraméterként átadjuk a metódusnak
            var emailContent = "";
            if (isOrder)
            {
                emailContent = File.ReadAllText("MailSystem/autoEmailOrder.txt");
            }
            else
            {
                emailContent = File.ReadAllText("MailSystem/autoEmail.txt");
            }
            
            string newMail = emailContent.Replace("{{MEMBER_NAME}}", $"{sName}")
                .Replace("{{MEMBER_EMAIL}}", $"{sEmail}")
                .Replace("{{MEMBER_MESSAGE}}", $"{sMessage}").Replace("{{TITLE}}", $"{sSubject}");
            

            string server = "smtp.freemail.hu";
            MailAddress from = new MailAddress("testcsharp@freemail.hu");
            MailAddress to = new MailAddress($"{sEmail}");
            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;

            message.Subject = $"{emailType}";
            message.Body = $"{newMail}";

            SmtpClient client = new SmtpClient(server,587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("testcsharp@freemail.hu", "tesT01234");
            
            //Console.WriteLine("Sending an email message to {0} by using SMTP host {1} port {2}.",
            //     to.ToString(), client.Host, client.Port);

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in SendEmail(): {0}",
                    ex.ToString());
            }
        }
    }
}
