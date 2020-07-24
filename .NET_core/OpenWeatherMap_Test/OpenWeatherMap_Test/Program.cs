using System;
using System.Net;
using System.Web.Script.Serialization;

namespace OpenWeatherMap_Test
{ 
    class Program
    {
        /*
           Information to receive may be changed by changing url
           When changing, the class must be changed according to the information type.
           Reference : https://openweathermap.org/api
        */
        static void Main()
        {
            //Your apiKey
            string apiKey = "a039ceb11797a887cd68228b844269d7";
            string city = "Daejeon";

            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}",city, apiKey);

            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(url);

            OpenWeatherMap weatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherMap>(json);

            Console.WriteLine("<Current Weather>\n");

            Console.WriteLine("Location : ({0},{1})", weatherInfo.coord.lat, weatherInfo.coord.lon);

            Console.WriteLine("\nWeather condition");
            Console.WriteLine(" - ID : {0}\n - Main : {1}\n - Description : {2}\n - Icon : {3}",
                weatherInfo.weather[0].id, weatherInfo.weather[0].main, weatherInfo.weather[0].description, weatherInfo.weather[0].icon);

            Console.WriteLine("\nInternal parameter : {0}", weatherInfo.@base);

            Console.WriteLine("\nTemperature");
            Console.WriteLine(" - Temperature : {0}℃\n - Sensible Temperature : {1}K\n - Minimum Temperature : {2}℃\n - Maximum Temperature : {3}℃\n - Pressure : {4}hPa\n - Humidity : {5}%",
             ConvertKelvin(weatherInfo.main.temp), weatherInfo.main.sensible_temp, ConvertKelvin(weatherInfo.main.temp_min), ConvertKelvin(weatherInfo.main.temp_max), weatherInfo.main.pressure, weatherInfo.main.humidity);

            Console.WriteLine("\nWind");
            Console.WriteLine(" - Speed : {0}m/s\n - Direction : {1} degrees", weatherInfo.wind.speed, weatherInfo.wind.deg);

            Console.WriteLine("\nClouds");
            Console.WriteLine(" - Cloudiness : {0}%", weatherInfo.clouds.all);

            Console.WriteLine("\nSystem");
            Console.WriteLine(" - Type : {0}\n - ID : {1}\n - Country : {2}\n - Sunrise : {3}\n - Sunset : {4}",
                weatherInfo.sys.type, weatherInfo.sys.id, weatherInfo.sys.country, ConvertUnixtimeToGMT(weatherInfo.sys.sunrise).ToString("tt hh:mm:ss"), ConvertUnixtimeToGMT(weatherInfo.sys.sunset).ToString("tt hh:mm:ss"));

            Console.WriteLine("\nEtc");
            Console.WriteLine(" - Data Receiving Time : {0}\n - Shift UTC to Sec : {1} sec\n - City : {2}\n - Internal parameter : {3}",
                ConvertUnixtimeToGMT(weatherInfo.dt), weatherInfo.timezone, weatherInfo.name, weatherInfo.cod);
            Console.WriteLine();
        }

        public static DateTime ConvertUnixtimeToGMT(int unixTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();

            return dtDateTime; 
        }
        
        public static double ConvertKelvin(double kelvin, bool convert = false)
        {
            if (convert)
            {
                return (kelvin - 273) * 5/9 + 32;
            }

            return kelvin - 273.15;
        }
    }
}
