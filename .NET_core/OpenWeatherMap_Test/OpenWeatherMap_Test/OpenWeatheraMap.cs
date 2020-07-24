using System.Collections.Generic;

namespace OpenWeatherMap_Test
{
    //Reference : https://openweathermap.org/weather-data
    public class Coord
    {
        //longitude
        public double lon { get; set; }
        //Latitude
        public double lat { get; set; }
    }
    public class Weather
    {
        //Reference : https://openweathermap.org/weather-conditions
        //Weather condition ID
        public int id { get; set; }
        //Group of weather parameters (Rain, Snow, Extreme etc.)
        public string main { get; set; }
        //Weather condition within the group
        public string description { get; set; }
        //Weather icon ID
        public string icon { get; set; }
    }
    public class Main
    {
        //Temperature(Standare:Kelvin, Metric:Celsius, Imperial:Fahrenheit)
        public double temp { get; set; }
        //Sensible Temperature
        public double sensible_temp { get; set; }
        //Minimum temperature at the moment(Standare:Kelvin, Metric:Celsius, Imperial:Fahrenheit)
        public double temp_min { get; set; }
        //Maximum temperature at the moment(Standare:Kelvin, Metric:Celsius, Imperial:Fahrenheit)
        public double temp_max { get; set; }
        //Pressure(hPa)
        public int pressure { get; set; }
        //Humidity(%)
        public int humidity { get; set; }
    }
    public class Wind
    {
        //Wind speed(m/s)
        public double speed { get; set; }
        //Wind direction(degrees)
        public double deg { get; set; }
    }
    public class Clouds
    {
        //Cloudiness(%)
        public int all { get; set; }
    }
    public class Sys
    {
        //Internal parameter 
        public int type { get; set; }
        //Internal parameter 
        public int id { get; set; }
        //Country Code
        public string country { get; set; }
        //Sunrise(unix,UTC)
        public int sunrise { get; set; }
        //Sunset(unix,UTC)
        public int sunset { get; set; }
    }
    public class OpenWeatherMap 
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        //Internal parameter 
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        //Time of data calculation(unix, UTC)
        public int dt { get; set; }
        public Sys sys { get; set; }
        //Shift in seconds from UTC
        public int timezone { get; set; }
        //Country ID
        public int id { get; set; }
        //Country Name
        public string name { get; set; }
        //Internal parameter 
        public int cod { get; set; }
    }
}
