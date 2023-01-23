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
using System.Globalization;

namespace weatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Config config;
        WeatherClient client;
        private CultureInfo lang;
        public MainWindow()
        {
            InitializeComponent();
            config = new Config();
            client = new WeatherClient(config.getConfig("apiKey"));
            lang = new CultureInfo("pl-PL");
            GetWeatherData();
            GetFutureWeatherData();
        }

        public string getTempUnit()
        {
            if (config.getConfig("units") == "metric")
            {
                return " °C";
            }
            else
            {
                return " °F";
            }
        }

        public void Refresh() {
            config = new Config();
            client = new WeatherClient(config.getConfig("apiKey"));
            GetWeatherData();
            GetFutureWeatherData();
        }

        public async void GetWeatherData()
        {
            Measurement meas = Measurement.Metric;
            if (config.getConfig("units") == "imperial")
            {
                meas = Measurement.Imperial;
            }
            WeatherModel weather = null;
            try
            {
                weather = await client.GetCurrentWeatherAsync(config.getConfig("city"), meas, Weather.NET.Enums.Language.Polish);
            }
            catch(Exception e){
                MessageBox.Show("Error: " + e.Message);
            }
            if (weather != null)
            {
                cityTextBlock.Text = config.getConfig("city");
                string temp = weather.Main.Temperature.ToString();
                string wind = weather.Wind.Speed.ToString() + " kph";
                string pressure = weather.Main.AtmosphericPressure.ToString();
                string realFeel = weather.Main.TemperaturePerception.ToString();
                string desc = weather.Weather[0].Description.ToString();
                temperatureLabel.Content = temp + getTempUnit();
                pressureTextbox.Text = pressure + " hPa";
                descriptionTextbox.Text = desc;
                windSpeedTextBox.Text = wind;
                realFeelTextBox.Text = realFeel + getTempUnit();
            }
        }

        public async void GetFutureWeatherData() {
            List<WeatherModel> forecasts = null;
            try
            {
                forecasts = await client.GetForecastAsync(config.getConfig("city"), 50, Measurement.Metric, Weather.NET.Enums.Language.Polish);
            }catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            if (forecasts != null)
            {
                WeatherModel day1 = null;
                WeatherModel day2 = null;
                WeatherModel day3 = null;
                WeatherModel day4 = null;
                WeatherModel day5 = null;
                foreach (WeatherModel forecast in forecasts)
                {
                    DateTime date = forecast.AnalysisDate;
                    if (date.Day == DateTime.Now.Day + 1)
                    {
                        day1 = forecast;
                    }
                    else if (date.Day == DateTime.Now.Day + 2)
                    {
                        day2 = forecast;
                    }
                    else if (date.Day == DateTime.Now.Day + 3)
                    {
                        day3 = forecast;
                    }
                    else if (date.Day == DateTime.Now.Day + 4)
                    {
                        day4 = forecast;
                    }
                    else if (date.Day == DateTime.Now.Day + 5)
                    {
                        day5 = forecast;
                    }
                }
                if (day1 != null)
                {
                    string temp = day1.Main.Temperature.ToString() + getTempUnit();
                    string wind = day1.Wind.Speed.ToString();
                    string pressure = day1.Main.AtmosphericPressure.ToString() + " hPa";
                    string realFeel = day1.Main.TemperaturePerception.ToString();
                    string desc = day1.Weather[0].Description.ToString();
                    string dayOfWeek = lang.DateTimeFormat.GetDayName(day1.AnalysisDate.DayOfWeek);
                    dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
                    string date = day1.AnalysisDate.ToString("dd/MM/yyyy");
                    SetDayData(1, dayOfWeek, date, temp, pressure, desc);
                }
                if (day2 != null)
                {
                    string temp = day2.Main.Temperature.ToString() + getTempUnit();
                    string wind = day2.Wind.Speed.ToString();
                    string pressure = day2.Main.AtmosphericPressure.ToString() + " hPa";
                    string realFeel = day2.Main.TemperaturePerception.ToString();
                    string desc = day2.Weather[0].Description.ToString();
                    string dayOfWeek = lang.DateTimeFormat.GetDayName(day2.AnalysisDate.DayOfWeek);
                    dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
                    string date = day2.AnalysisDate.ToString("dd/MM/yyyy");
                    SetDayData(2, dayOfWeek, date, temp, pressure, desc);
                }
                if (day3 != null)
                {
                    string temp = day3.Main.Temperature.ToString() + getTempUnit();
                    string wind = day3.Wind.Speed.ToString();
                    string pressure = day3.Main.AtmosphericPressure.ToString() + " hPa";
                    string realFeel = day3.Main.TemperaturePerception.ToString();
                    string desc = day3.Weather[0].Description.ToString();
                    string dayOfWeek = lang.DateTimeFormat.GetDayName(day3.AnalysisDate.DayOfWeek);
                    dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
                    string date = day3.AnalysisDate.ToString("dd/MM/yyyy");
                    SetDayData(3, dayOfWeek, date, temp, pressure, desc);
                }
                if (day4 != null)
                {
                    string temp = day4.Main.Temperature.ToString() + getTempUnit();
                    string wind = day4.Wind.Speed.ToString();
                    string pressure = day4.Main.AtmosphericPressure.ToString() + " hPa";
                    string realFeel = day4.Main.TemperaturePerception.ToString();
                    string desc = day4.Weather[0].Description.ToString();
                    string dayOfWeek = lang.DateTimeFormat.GetDayName(day4.AnalysisDate.DayOfWeek);
                    dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
                    string date = day4.AnalysisDate.ToString("dd/MM/yyyy");
                    SetDayData(4, dayOfWeek, date, temp, pressure, desc);
                }
                if (day5 != null)
                {
                    string temp = day5.Main.Temperature.ToString() + getTempUnit();
                    string wind = day5.Wind.Speed.ToString();
                    string pressure = day5.Main.AtmosphericPressure.ToString() + " hPa";
                    string realFeel = day5.Main.TemperaturePerception.ToString();
                    string desc = day5.Weather[0].Description.ToString();
                    string dayOfWeek = lang.DateTimeFormat.GetDayName(day5.AnalysisDate.DayOfWeek);
                    dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
                    string date = day5.AnalysisDate.ToString("dd/MM/yyyy");
                    SetDayData(5, dayOfWeek, date, temp, pressure, desc);
                }
            }
        }

        public void SetDayData(int id,string dayOfWeek, string date,string temp, string pressure, string desc)
        {
            switch (id)
            {
                case 1:
                    firstDayWeek.Text = dayOfWeek;
                    firstDayTemp.Text = temp;
                    firstDayDate.Text = date;
                    firstDayPress.Text = pressure;
                    firstDayDesc.Text = desc;
                    break;
                case 2:
                    secondDayWeek.Text = dayOfWeek;
                    secondDayTemp.Text = temp;
                    secondDayDate.Text = date;
                    secondDayPress.Text = pressure;
                    secondDayDesc.Text = desc;
                    break;
                case 3:
                    thirdDayWeek.Text = dayOfWeek;
                    thirdDayTemp.Text = temp;
                    thirdDayDate.Text = date;
                    thirdDayPress.Text = pressure;
                    thirdDayDesc.Text = desc;
                    break;
                case 4:
                    fourthDayWeek.Text = dayOfWeek;
                    fourthDayTemp.Text = temp;
                    fourthDayDate.Text = date;
                    fourthDayPress.Text = pressure;
                    fourthDayDesc.Text = desc;
                    break;
                case 5:
                    fifthDayWeek.Text = dayOfWeek;
                    fifthDayTemp.Text = temp;
                    fifthDayDate.Text = date;
                    fifthDayPress.Text = pressure;
                    fifthDayDesc.Text = desc;
                    break;
            }
        }
        

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings(Refresh);
            settings.Show();
        }

        private void themeButton_Click(object sender, RoutedEventArgs e)
        {
            Themes themes = new Themes();
            themes.Show();
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
