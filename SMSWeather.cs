using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Net.Http;
using System.Text.Json;

namespace WeatherReport
{
    internal class SmsWeather
    {
        public void SendText()
        {
            string apiKey = "b07325fc40156ccf165c6401078311b1";

           string lat = "51.454514";

           string lon = "-2.587910";

            HttpClient client = new HttpClient();

           var url = new Uri($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}");
           var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            WeatherDetails weather = JsonSerializer.Deserialize<WeatherDetails>(result);
            Console.WriteLine(result);
            //string accountSid = Environment.GetEnvironmentVariable("ACa867f5a821d819a4ec245d3be9caf110");
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(username:accountSid, password:authToken);

            
            CelsiusConvertor celsiusConvertor = new CelsiusConvertor();

           // Console.WriteLine(celsiusConvertor.ConvertToCelsius(weather.main.temp));

            var message = MessageResource.Create(
                body: $"On { DateTime.Now} the current temperature in Bristol is {celsiusConvertor.ConvertToCelsius(weather.main.temp)}°c although it feels like {celsiusConvertor.ConvertToCelsius(weather.main.feels_like)}°c. Today's conditions will be {weather.weather[0].description}.",
                from: new Twilio.Types.PhoneNumber("+19108386231"),
                to: new Twilio.Types.PhoneNumber("+447818517131")
            );

            Console.WriteLine(message.Sid);
        }
        //    public async Task SendSms()
        //{
        //    // Find your Account Sid and Token at twilio.com/console
        //    const string accountSid = "ACa867f5a821d819a4ec245d3be9caf110";
        //    const string authToken = "your_auth_token";

        //    TwilioClient.Init(accountSid, authToken);

        //    var message = await MessageResource.CreateAsync(
        //        body: "This is the ship that made the Kessel Run in fourteen parsecs?",
        //        from: new Twilio.Types.PhoneNumber("+15017122661"),
        //        to: new Twilio.Types.PhoneNumber("+15558675310")
        //    );

        //    Console.WriteLine(message.Sid);
        //}
    }
}
