using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ipapi_test
{
    class Program
    {
        static void  Main()
        {
            //Target IP Search : ipapi.co/{Target IP}/json
            string url = string.Format("https://ipapi.co/json");

            var t = Task<string>.Run(async () => {

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1");

                string json = await httpClient.GetStringAsync(url);
                
                return json;
            });

            IpInfo ipinfo = JsonConvert.DeserializeObject<IpInfo>(t.Result);

            Console.WriteLine("<IP Address Infomation>\n");
            Console.WriteLine("IP : {0}", ipinfo.ip);
            Console.WriteLine("City : {0}", ipinfo.city);
            Console.WriteLine("Region : {0}", ipinfo.region);
            Console.WriteLine("Region Code : {0}", ipinfo.region_code);
            Console.WriteLine("Country : {0}", ipinfo.country);
            Console.WriteLine("Country Name : {0}", ipinfo.country_name);
            Console.WriteLine("Postal : {0}", ipinfo.postal);
            Console.WriteLine("Location : ({0},{1})", ipinfo.latitude, ipinfo.longitude);
            Console.WriteLine("Timezone : {0}", ipinfo.timezone);
            Console.WriteLine("Asn : {0}", ipinfo.asn);
            Console.WriteLine("Org : {0}", ipinfo.org);
            Console.WriteLine();
        }
    }
}
