using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Documents;

namespace weatherApp
{
    public class GeoData
    {
        
        
    }
    public class GeoCoding
    {
        private string urlBase = "http://api.openweathermap.org/geo/1.0/direct?q=";
        private string apiKey;
        public GeoCoding(string apiKey) {
            this.apiKey = apiKey;
        }

        public async Task<List<GeoData>> getGeoData(string city)
        {
            string url = urlBase + city + "&limit=1&appid=" + apiKey;
            string json = await HttpHelper.getJson(url);
            List<GeoData> data = JsonSerializer.Deserialize<List<GeoData>>(json);
            return data;
        }


    }
}
