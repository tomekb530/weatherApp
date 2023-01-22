using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace weatherApp
{
    internal class ConfigData
    {
        [JsonPropertyName("apiKey")]
        public string apiKey;
        //add moar
    }
    public class Config
    {
        private ConfigData data;
        public Config()
        {
            // Read the config file
            string configJson = System.IO.File.ReadAllText("config.json");
            if (configJson == null)
            {
                data = new ConfigData();
            }
            else
            {
                // Deserialize the config file
                try
                {
                    data = JsonSerializer.Deserialize<ConfigData>(configJson);
                }catch(Exception e)
                {
                    Console.WriteLine("Error reading config file: " + e.Message);
                    data = new ConfigData();
                }
            }

        }
        
        public void saveConfig()
        {
            string json = JsonSerializer.Serialize(data);
            System.IO.File.WriteAllText("config.json", json);
        }
    }
}
