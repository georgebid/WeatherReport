using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Razor;
using FluentEmail.Core;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json;
using System.Net;
using System.Configuration;

namespace WeatherReport
{
    public class SendEmails
    {
        //CURRENTLY NOT WORKING.
        public void SendEmail()
        {

            Email.DefaultRenderer = new RazorRenderer();
            EmailCredentials emailCredentials = new EmailCredentials();
            EmailMessage emailMessage = new EmailMessage();

            var sender = emailCredentials.GetEmailCredentials();
            sender.EnableSsl = true;
            emailMessage.EmailMessaging();
           // sender.Send(mailMessage);

            // confirm the above has worked.
            Console.WriteLine("Email sent.");
        }
    }
}
