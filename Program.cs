using System;
using System.Net.Mime;
using System.Xml;
using Twilio.Rest.Verify.V2.Service;

namespace WeatherReport
{
    public class Program
    {
        static void Main(string[] args) 
        {
            SendEmails sendEmail = new SendEmails();
            sendEmail.SendEmail();

           //TextMessage text = new();
           //text.Messaging();

           Console.WriteLine("Message sent.");
        }
    }
}


