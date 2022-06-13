namespace WeatherReport
{
    public class Program
    {
        static void Main(string[] args) 
        {
            SMSWeather smsWeather = new();
            //EmailWeather emailWeather = new();

            //emailWeather.SendEmail();
            smsWeather.SendText();
        }
    }
}


