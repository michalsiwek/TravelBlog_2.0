using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TravelBlog.Models.Viewmodels;

namespace TravelBlog.Infrastructure
{
    public interface ISendEmailService
    {
        void SendEmail(ContactViewModel model);
    }

    public class SendEmailService : ISendEmailService
    {
        private SmtpClient _smtpClient;
        private readonly string _emailAddress = "blog.manager.app@gmail.com";
        private readonly string _password = "blogmanager1";
        private readonly string _emailTemplate = "<h3>Message from: {0}</h3><hr><br>{1}";

        public SendEmailService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            _smtpClient.EnableSsl = true;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(_emailAddress, _password);
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void SendEmail(ContactViewModel model)
        {
            MailMessage mail = new MailMessage();            

            mail.From = new MailAddress(_emailAddress, model.Contact.EmailAddress);
            mail.To.Add(new MailAddress(_emailAddress));
            mail.Subject = model.Contact.Title;
            mail.IsBodyHtml = true;
            mail.Body = string.Format(_emailTemplate, model.Contact.EmailAddress, model.Contact.GetMessage());

            _smtpClient.Send(mail);
        }
    }
}