using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Classes
{
    public static class EmailSender
    {
        public static void SendMessageRegistration(string mailTo,string code,string clientName)
        {
            MailAddress from = new MailAddress("artroyaldetailing@mail.ru", "Детейлинг-студия Art Royal");
            MailAddress to = new MailAddress(mailTo);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение регистрации";
            HtmlDocument document = new HtmlDocument();
            String fileName = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(fileName, Encoding.UTF8.GetBytes(Properties.Resources.regmessage));
            document.Load(fileName);
            HtmlNode clientNode = document.GetElementbyId("client");
            clientNode.InnerHtml = clientName;
            HtmlNode codeNode = document.GetElementbyId("code");
            codeNode.InnerHtml = code;
            m.Body = document.DocumentNode.OuterHtml;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("artroyaldetailing@mail.ru", "9uBb1AV34bPuspscJWAf");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public static string GenerateCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
