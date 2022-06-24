using System;
using System.Net.Http;

namespace WeatherReport
{
    public class WeatherLocation
    {
        public string LocationInfo()
        {
            string apiKey = "b07325fc40156ccf165c6401078311b1";

            string lat = "51.454514";

            string lon = "-2.587910";

            HttpClient client = new HttpClient();

            var url = new Uri($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}");

            var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return result;
        } 
        
    }
}
