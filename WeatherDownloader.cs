using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace weatherApp
{
    public class WeatherInfo
    {
        
    }
    public class WeatherDownloader
    {
        private string urlbase = "https://api.openweathermap.org/data/3.0/onecall";
        private string apiKey;
        public WeatherDownloader(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<WeatherInfo> getWeatherData(double lat, double lon)
        {
            string url = urlbase + "?lat=" + lat + "&lon=" + lon + "&exclude=minutely,hourly,alerts&appid=" + apiKey;
            string json = await HttpHelper.getJson(url);
            WeatherInfo data = JsonSerializer.Deserialize<WeatherInfo>(json);
            return data;
        }
    }
}
