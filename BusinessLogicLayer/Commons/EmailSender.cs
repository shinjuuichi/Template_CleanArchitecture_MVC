//using System.Net;
//using System.Net.Mail;
//using Microsoft.AspNetCore.Identity.UI.Services;

//namespace BusinessLogicLayer.Commons
//{
//    public class EmailSender(AppConfiguration configuration) : IEmailSender
//    {
//        public Task SendEmailAsync(string email, string subject, string htmlMessage)
//        {
//            string? sender = configuration.EmailConfig.Email;
//            string? password = configuration.EmailConfig.Password;
//            MailMessage mail = new()
//            {
//                From = new MailAddress(sender),
//                Subject = subject,
//                Body = htmlMessage,
//                IsBodyHtml = true,
//            };

//            mail.To.Add(email);
//            SmtpClient client = new()
//            {
//                Port = 587,
//                Host = "smtp.gmail.com",
//                EnableSsl = true,
//                DeliveryMethod = SmtpDeliveryMethod.Network,
//                UseDefaultCredentials = false,
//                Credentials = new NetworkCredential(sender, password)
//            };

//            return client.SendMailAsync(mail);
//        }
//    }
//}
