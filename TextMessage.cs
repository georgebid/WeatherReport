using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text.Json;

namespace WeatherReport
{
    public class TextMessage
    {
        public void Messaging()
        {
            CelsiusConvertor celsiusConvertor = new CelsiusConvertor();
            WeatherLocation weatherLocation = new WeatherLocation();
            WeatherDetails weather = JsonSerializer.Deserialize<WeatherDetails>(weatherLocation.LocationInfo());

            var message = MessageResource.Create(
                body: $"On { DateTime.Now} the current temperature in Bristol is {celsiusConvertor.ConvertToCelsius(weather.main.temp)}°c although it feels like {celsiusConvertor.ConvertToCelsius(weather.main.feels_like)}°c. Today's conditions will be {weather.weather[0].description}.",
                from: new Twilio.Types.PhoneNumber("+19108386231"),
                to: new Twilio.Types.PhoneNumber("+447818517131")
            );
        } 


    }
}
