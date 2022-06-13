using System;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using FluentEmail.Core;
using FluentEmail.Razor;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;

namespace WeatherReport
{
    public class EmailWeather
    {
        public void SendEmail()
        {
            // the info below needs to go into a seperate class that contains the API information.
            string apiKey = "b07325fc40156ccf165c6401078311b1";

            string lat = "51.454514";

            string lon = "-2.587910";

            HttpClient client = new HttpClient();

            var url = new Uri($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}");

            var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);

            WeatherDetails weather = JsonSerializer.Deserialize<WeatherDetails>(result);

            CelsiusConvertor celsiusConvertor = new CelsiusConvertor();

            Console.WriteLine(weather.weather[0].description);
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
            mailMessage.To.Add("georgina.bidder@icloud.com");
            //Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            //define the server that will send out the email. In this case its smtp gmail and I had to define the port - 587.
            using (SmtpClient sender = new SmtpClient(host: "smtp.gmail.com",587))
            {
                //marking the use default credentials seems to clear out and existing data and avoid erroring.
                sender.UseDefaultCredentials = false;
                // THIS NEEDS TO MOVE
                NameValueCollection sAll;
                sAll = ConfigurationManager.AppSettings;
                //sender.Credentials = new NetworkCredential("georginaweathertest@gmail.com", "Hmgd6961!");
                sender.Credentials = (ICredentialsByHost)sAll;
                sender.EnableSsl = true;
                sender.Send(mailMessage);
            };


            // confirm the above has worked.
            Console.WriteLine("Email sent.");
        }
    }
}
