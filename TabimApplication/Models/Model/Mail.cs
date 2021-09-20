using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TabimApplication.Models.Model
{
    public class Mail
    {

        public static void MailSender(string body,string mail)
        {
            var fromAddress = new MailAddress("nesli.11.67@gmail.com");
            var toAddress = new MailAddress("mozturk357@gmail.com");
            var toAddressyeni = new MailAddress(mail);
            const string subject = "TabimApplication | Tabim İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "*=CUMr,e_CRaZ1")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddressyeni) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }

    }

}
