using BusinessIntelligence.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace BusinessIntelligence.Services
{
    public class WeatherBroadcast
    {
        public ResponseWeather GetweatherbyCityName(string cityName)
        {
            /*Calling API http://openweathermap.org/api */
            string apiKey = "c97b64d1799f30416627a0ea7529a475";
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
            return rootObject;
        }
        public ResponseWeather Getweatherbyzip(string zip,string countrycode)
        {
            /*Calling API http://openweathermap.org/api */
            string apiKey = "c97b64d1799f30416627a0ea7529a475";
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=" + zip + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
            return rootObject;
        }
    }
}