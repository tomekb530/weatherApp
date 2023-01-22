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

namespace weatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GeoCoding geoCoding;
        private Config config;
        private WeatherDownloader weatherDownloader;
        public MainWindow()
        {
            InitializeComponent();
            config = new Config();
            geoCoding = new GeoCoding(config.getConfig("apiKey"));
            weatherDownloader = new WeatherDownloader(config.getConfig("apiKey"));

        }

        public async void GetWeatherData()
        {
            List<GeoData> geoData = geoCoding.getGeoData("Budapest").Result;
            
        }
    }
}
