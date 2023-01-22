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

        }
    }
}
