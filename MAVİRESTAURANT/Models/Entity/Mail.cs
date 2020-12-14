using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MAVİRESTAURANT.Models.Entity
{
    public class Mail
    {
        public static void MailSender(string body)
        {
            var fromAddress = new MailAddress("restaurantmavi@gmail.com");
            var toAddress = new MailAddress("restaurantmavi@gmail.com");
            const string subject = "Mavi Restaurant | Sitenizden Gelen İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "HabibeSevim")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}