using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text.Json;

namespace WeatherReport
{
    internal class SmsWeather
    {
        public void SendText()
        {
            WeatherLocation weatherLocation = new WeatherLocation();

            WeatherDetails weather = JsonSerializer.Deserialize<WeatherDetails>(weatherLocation.LocationInfo());
           
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(username:accountSid, password:authToken);

            
            CelsiusConvertor celsiusConvertor = new CelsiusConvertor();


            Console.WriteLine(message.Sid);
        }
        
    }
}
