namespace WeatherReport
{
    public class Program
    {
        static void Main(string[] args) 
        {
           SmsWeather smsWeather = new();
           EmailWeather emailWeather = new();

           emailWeather.SendEmail();
           smsWeather.SendText();
        }
    }
}


