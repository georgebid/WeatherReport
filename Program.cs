namespace WeatherReport
{
    public class Program
    {
        static void Main(string[] args) 
        {
         //  SmsCredentials smsWeather = new();
           EmailWeather emailWeather = new();
           

           emailWeather.SendEmail();
           SmsCredentials.GetCredentials();
        }
    }
}


