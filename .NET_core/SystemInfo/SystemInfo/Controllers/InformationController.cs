using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static System.Math;

namespace SystemInfo.Controllers
{
    public class InformationController : Controller
    {
        public string PublicIP { get; set; } = "IP lookup Failed";
        public double Long { get; set; }
        public double Latt { get; set; }
        public string City { get; set; }
        public string CurrentWeatherIcon { get; set; }
        public string WeatherAttribution { get; set; }
        public string CurrentTemp { get; set; } = "undetermined";
        public string CurrentMinTemp { get; set; } = "undetermined";
        public string CurrentMaxTemp { get; set; } = "undetermined";
        public string CurrentPressure { get; set; }
        public string CurrentHumidity { get; set; }
        public string CurrentWindSpeed { get; set; }
        public string CurrentWindDir { get; set; }
        public string CurrentCloudiness { get; set; }
        public string CurrentSunrise { get; set; }
        public string CurrentSunset { get; set; }
        public string DayWeatherSummary { get; set; }
        public string TempUnitOfMeasure { get; set; }
        private readonly IHostingEnvironment _hostEnv;

        public InformationController(IHostingEnvironment hostingEnvironment)
        {
            _hostEnv = hostingEnvironment;
        }

        public IActionResult GetInfo()
        {
            Models.InformationModel model = new Models.InformationModel();
            model.OperatingSystem = RuntimeInformation.OSDescription;
            model.FrameworkDescription = RuntimeInformation.FrameworkDescription;
            model.OSArchitecture = RuntimeInformation.OSArchitecture.ToString();
            model.ProcessArchitecture = RuntimeInformation.ProcessArchitecture.ToString();

            string title = string.Empty;
            string OSArchitecture = string.Empty;

            if (model.OSArchitecture.ToUpper().Equals("X64")) { OSArchitecture = "64-bit"; } else { OSArchitecture = "32-bit"; }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { title = $"Windows {OSArchitecture}"; }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) { title = $"OSX {OSArchitecture}"; }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { title = $"Linux {OSArchitecture}"; }

            GetLocationInfo().Wait();
            model.IPAddressString = PublicIP;

            GetWeatherInfo().Wait();
            model.CurrentIcon = CurrentWeatherIcon;
            model.CurrentCity = City;
            model.CurrentTemperature = CurrentTemp;
            model.CurrentMaxTemperature = CurrentMinTemp;
            model.CurrentMinTemperature = CurrentMaxTemp;
            model.DailySummary = DayWeatherSummary;
            model.CurrentPressure = CurrentPressure;
            model.CurrentHumidity = CurrentHumidity;
            model.CurrentWindSpeed = CurrentWindSpeed;
            model.CurrentWindDir = CurrentWindDir;
            model.CurrentCloudiness = CurrentCloudiness;
            model.CurrentSunrise = CurrentSunrise;
            model.CurrentSunset = CurrentSunset;
            model.WeatherBy = WeatherAttribution;
            model.UnitOfMeasure = TempUnitOfMeasure;

            model.InfoTitle = title;
            return View(model);
        }

        private async Task GetLocationInfo()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1");
            
            string json = await httpClient.GetStringAsync("https://ipapi.co/json");
            LocationInfo info = JsonConvert.DeserializeObject<LocationInfo>(json);

            PublicIP = info.ip;
            Long = info.longitude;
            Latt = info.latitude;
            City = info.city;
        }

        private async Task GetWeatherInfo()
        {
            //You apiKey
            string apiKey = "";
            string city = "Daejeon";

            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", city, apiKey);

            var httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(url);

            OpenWeatherMap info = JsonConvert.DeserializeObject<OpenWeatherMap>(json);

            string iconFilename = GetCurrentWeatherIcon(info.weather[0].icon);
            string svgFile = Path.Combine(_hostEnv.ContentRootPath, "climacons", iconFilename);
            CurrentWeatherIcon = System.IO.File.ReadAllText($"{svgFile}");

            DayWeatherSummary = UppercaseFirst(info.weather[0].description);
            WeatherAttribution = "Powered by Open Weather";
            CurrentTemp = Round(info.main.temp - 273.15).ToString() + "℃";
            CurrentMinTemp = Round(info.main.temp_min - 273.15).ToString() + "℃";
            CurrentMaxTemp = Round(info.main.temp_max - 273.15).ToString() + "℃";
            CurrentPressure = info.main.pressure.ToString() + " aPh";
            CurrentHumidity = info.main.humidity.ToString() + "%";
            CurrentWindSpeed = info.wind.speed.ToString() + "m/s";
            CurrentWindDir = info.wind.deg.ToString() + " degree";
            CurrentCloudiness = info.clouds.all.ToString() + "%";
            CurrentSunrise = ConvertUnixtimeToGMT(info.sys.sunrise).ToString("tt hh:mm:ss");
            CurrentSunset = ConvertUnixtimeToGMT(info.sys.sunset).ToString("tt hh:mm:ss");

            DateTime ConvertUnixtimeToGMT(int unixTime)
            {
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();

                return dtDateTime;
            }

            string UppercaseFirst(string s)
            {
                char[] a = s.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                return new string(a);
            }
        }

        private string GetCurrentWeatherIcon(string ic)
        {
            string iconFilename = string.Empty;

            switch (ic)
            {
                case "01d":
                    iconFilename = "Sun.svg";
                    break;

                case "01n":
                    iconFilename = "Moon.svg";
                    break;

                case "02d":
                    iconFilename = "Cloud-Sun.svg";
                    break;

                case "02n":
                    iconFilename = "Cloud-Moon.svg";
                    break;

                case "03d":
                case "03n":
                case "04d":
                case "04n":
                    iconFilename = "Cloud.svg";
                    break;

                case "09d":
                case "09n":
                    iconFilename = "Cloud-Drizzle.svg";
                    break;

                case "10d":
                    iconFilename = "Cloud-Rain-Sun.svg";
                    break;

                case "10n":
                    iconFilename = "Cloud-Rain-Moon.svg";
                    break;

                case "11d":
                case "11n":
                    iconFilename = "Cloud-Lightning.svg";
                    break;

                case "13d":
                case "13n":
                    iconFilename = "Snowflake.svg";
                    break;

                default:
                    iconFilename = "Thermometer.svg";
                    break;
            }
            return iconFilename;
        }

        //IP infomation(ipapi.co)
        public class LocationInfo{
            public string ip { get; set; }
            public string city { get; set; }
            public string region { get; set; }
            public string region_code { get; set; }
            public string country { get; set; }
            public string country_name { get; set; }
            public string postal { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string timezone { get; set; }
            public string asn { get; set; }
            public string org { get; set; }
        }

        //Weather Infomation(openweathermap.org)
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
}
