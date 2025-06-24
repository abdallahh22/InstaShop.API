using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.EmailService
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var clinet = new SmtpClient("smtp.gmail.com", 587);
            clinet.Credentials = new NetworkCredential("InstaShop@gmail.com", "InstaShop1234");
            clinet.Send("InstaShop@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
