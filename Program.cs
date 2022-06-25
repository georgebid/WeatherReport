namespace WeatherReport
{
    public class Program
    {
        static void Main(string[] args) 
        {

            //Need to add an instance as its not static anymore.
           // EmailWeather.SendEmail();
           SmsCredentials.GetCredentials();
        }
    }
}


