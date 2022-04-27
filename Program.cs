using System;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Smtp;

namespace WeatherReport
{
    public class Program
    {
        // convert to an async task in order to make calls to an asycrinous method. 
        static async Task Main(string[] args)
        {
            string apiKey = "63d2b1f2e65740c36eae171acd874bd5";

            string lat = "51.454514";

            string lon = "-2.587910";

            HttpClient client = new HttpClient();

            var url = new Uri($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}");

            var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);

           WeatherDetails weather = JsonSerializer.Deserialize<WeatherDetails>(result);

            double convertToCelsius(double temp)
            {
                double celsius = temp - 273.15;
                double roundDown = Math.Round(celsius, 1);
                return roundDown;
            }

            //define the server that will send out the email. In this case its local host (me) but this could be gmail etc.
            var sender = new SmtpSender(() => new SmtpClient(host: "localhost")
            {
                // for testing purposes the security is turned off. Usually you'd want it on. 
                EnableSsl = false,
                // this will put the emails in a directory
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                // the location of the directory. Specifying that whenever you send an email it will be sent to the directory for testing.
                PickupDirectoryLocation = @"C:\Users\Georgina.Bidder\.vscode\emailDirectory"
            });
            
            // string builder is more efficient than using string appending or string concatination.
            StringBuilder template = new();
            template.AppendLine(value: "Dear @Model.FirstName,");
            template.AppendLine(value: $"<p>On { DateTime.Now}The temperature today is { convertToCelsius(weather.main.temp) } though it will feel like { convertToCelsius(weather.main.feels_like)}. Today's conditions will be {weather.weather[0].description}.</p>");

            Email.DefaultSender = sender;

            //create the email template and content.
            var email = await Email
                .From(emailAddress: "georginabidder@googlemail.com")
                .To(emailAddress: "georginatruetest@gmail.com", name: "George")
                .Subject(subject: "Today's weather report!")
                //passing in the template, and the person model. 
                .UsingTemplate(template.ToString(), new {FirstName = "Georgina" })
                //.Body($"On {DateTime.Now} The temperature today is {convertToCelsius(weather.main.temp)} though it will feel like {convertToCelsius(weather.main.feels_like)}. Today's conditions will be {weather.weather[0].description}.")
                .SendAsync();

          // confirm the above has worked
            Console.WriteLine("Email sent.");
        }
    }
}
//public class Coord
//{
//    public double lon { get; set; }
//    public double lat { get; set; }
//}

//public class Weather
//{
//    public int id { get; set; }
//    public string main { get; set; }
//    public string description { get; set; }
//    public string icon { get; set; }
//}

//public class Main
//{
//    public double temp { get; set; }
//    public double feels_like { get; set; }
//    public double temp_min { get; set; }
//    public double temp_max { get; set; }
//    public int pressure { get; set; }
//    public int humidity { get; set; }
//}

//public class Wind
//{
//    public double speed { get; set; }
//    public int deg { get; set; }
//}

//public class Clouds
//{
//    public int all { get; set; }
//}

//public class Sys
//{
//    public int type { get; set; }
//    public int id { get; set; }
//    public double message { get; set; }
//    public string country { get; set; }
//    public int sunrise { get; set; }
//    public int sunset { get; set; }
//}

//public class WeatherDetails
//{
//    public Coord coord { get; set; }
//    public List<Weather> weather { get; set; }
//    public string @base { get; set; }
//    public Main main { get; set; }
//    public int visibility { get; set; }
//    public Wind wind { get; set; }
//    public Clouds clouds { get; set; }
//    public int dt { get; set; }
//    public Sys sys { get; set; }
//    public int timezone { get; set; }
//    public int id { get; set; }
//    public string name { get; set; }
//    public int cod { get; set; }

