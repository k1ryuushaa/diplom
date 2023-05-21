using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Classes
{
    public static class EmailSender
    {
        public static void SendMessage(string mailTo,string message)
        {
            MailAddress from = new MailAddress("artroyaldetailing@mail.ru", "Детейлинг-студия Art Royal");
            MailAddress to = new MailAddress(mailTo);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение регистрации";
            m.Body = $"<h2><b>Доброго времени суток.</b></h2><br><h2>Наша студия рада что вы с нами</h2><br/><h3>{message}</h3>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("artroyaldetailing@mail.ru", "oilpoilARD");
            smtp.EnableSsl = true;
            smtp.Send(m);
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
