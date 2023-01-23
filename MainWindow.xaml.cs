using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weather.NET;
using Weather.NET.Enums;
using Weather.NET.Models.WeatherModel;
using Weather.NET.Models.PollutionModel;


namespace weatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Config config;
        WeatherClient client;
        public MainWindow()
        {
            InitializeComponent();
            config = new Config();
            client = new WeatherClient(config.getConfig("apiKey"));
            GetWeatherData();
        }

        public async void GetWeatherData()
        {
            List<WeatherModel> forecasts = await client.GetForecastAsync("Biała Podlaska", 8, Measurement.Metric, Weather.NET.Enums.Language.Polish);
            string temp = forecasts[0].Main.Temperature.ToString();
            string tempMin = forecasts[0].Main.TemperatureMin.ToString();
            string tempMax = forecasts[0].Main.TemperatureMax.ToString();
            string humidity = forecasts[0].Main.HumidityPercentage.ToString();
            string windSpeed = forecasts[0].Wind.Speed.ToString();
            string pressure = forecasts[0].Main.AtmosphericPressure.ToString();
            string realFeel = forecasts[0].Main.TemperaturePerception.ToString();
            temperatureTextBlock.Text = temp+ " °C";
            pressureTextbox.Text = pressure + " hPa";
            descriptionTextbox.Text = forecasts[0].Weather[0].Description;
            windSpeedTextBox.Text = windSpeed;
            realFeelTextBox.Text = realFeel + " °C";
        }
    }
}
