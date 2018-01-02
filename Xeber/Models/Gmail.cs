using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Xeber.Models
{


    public class Gmail
    {
        public static void SendMail(string body)
        {
            var fromAddress = new MailAddress("rustemlifiruze@gmail.com", "Xeber saytindan bildirim");
            var toAddress = new MailAddress("rustemlifiruze@gmail.com");
            const string subject = "Leaf Solutions Geribildirim";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "01F!ruze28")
                //trololol kısmı e-posta adresinin şifresi
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