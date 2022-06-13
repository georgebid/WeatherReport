using System;

namespace WeatherReport
{
    public class CelsiusConvertor
    {
        public double ConvertToCelsius(double temp)
        {
            double celsius = temp - 273.15;
            double roundDown = Math.Round(celsius, 1);
            return roundDown;
        }
    }
}
