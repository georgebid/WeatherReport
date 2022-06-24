using System.Collections.Generic;


namespace WeatherReport
{
    //Originally had these in the correct format (Title case) but it was breaking. Eventually realised it was because the JSON needed the properties to be lowercase. Seems odd? Anyway around this?
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string description { get; set; }
        public string Icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double TempMin { get; set; }// annotations
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
    public class WeatherDetails
    {
        public Coord Coord { get; set; }
        public List<Weather> weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
