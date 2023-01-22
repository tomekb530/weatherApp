﻿using System;
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
        public string apiKey { get; set; }
        //add moar
    }
    public class Config
    {
        private ConfigData data;
        public Config()
        {
            //check if config file exists
            if (System.IO.File.Exists("config.json"))
            {
                //read config file
                string json = System.IO.File.ReadAllText("config.json");
                //deserialize json
                try
                {
                    data = JsonSerializer.Deserialize<ConfigData>(json);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error reading config file: " + e.Message);
                    data = new ConfigData();
                }
            }
            else
            {
                //create new config file
                data = new ConfigData();
                //save config file
                saveConfig();
            }

        }

        public string getConfig(string type)
        {
            switch (type)
            {
                case "apiKey":
                    return data.apiKey;
                default:
                    return "";
            }
        }
        
        public void saveConfig()
        {
            string json = JsonSerializer.Serialize<ConfigData>(data);
            System.IO.File.WriteAllText("config.json", json);
        }
    }
}
