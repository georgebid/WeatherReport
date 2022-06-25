using System;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using FluentEmail.Core;
using FluentEmail.Razor;
using System.Net;
using System.Configuration;


namespace WeatherReport
{
    public class EmailWeather
    {
        public void SendEmail()
        {
            // the info below needs to go into a separate class that contains the API information.
            WeatherLocation weatherLocation = new WeatherLocation();
           
            WeatherDetails weather = JsonSerializer.Deserialize<WeatherDetails>(weatherLocation.LocationInfo());

            CelsiusConvertor celsiusConvertor = new CelsiusConvertor();

            // string builder is more efficient than using string appending or string concatination.
            StringBuilder template = new StringBuilder();
            template.AppendLine(value: "Dear Georgina");
            template.AppendLine(value: $"<p>On {DateTime.Now} The current temperature in Bristol is {celsiusConvertor.ConvertToCelsius(weather.main.temp)} although it feels like {celsiusConvertor.ConvertToCelsius(weather.main.feels_like)}. Today's conditions will be {weather.weather[0].description}.</p>");

            var mailMessage = new MailMessage
            {
                From = new MailAddress("georginaweathertest@gmail.com"),
                Subject = "Today's Weather Report!",
                Body = template.ToString(),
                IsBodyHtml = true,
            };

            //mailMessage.To.Add("georgina.bidder@truedigital.co.uk");
            mailMessage.To.Add("mitch.ford1@gmail.com");
            //Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            EmailCredentials emailCredentials = new EmailCredentials();

            var sender = emailCredentials.GetEmailCredentials();

            sender.EnableSsl = true;
            sender.Send(mailMessage);

            // confirm the above has worked.
            Console.WriteLine("Email sent.");
        }
    }
}
