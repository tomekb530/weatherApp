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
using System.Windows.Shapes;

namespace weatherApp
{
    /// <summary>
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    /// 

    public partial class Settings : Window
    {
        private Config config;
        private Action cb;
        public Settings(Action Callback)
        {
            InitializeComponent();
            config = new Config();
            apiKey.Text = config.getConfig("apiKey");
            cityName.Text = config.getConfig("city");
            //comboBox
            if (config.getConfig("units") == "metric")
            {
                unitComboBox.SelectedIndex = 0;
            }
            else
            {
                unitComboBox.SelectedIndex = 1;
            }
            cb = Callback;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            config.setConfig("apiKey", apiKey.Text);
            config.setConfig("city", cityName.Text);
            if (unitComboBox.SelectedIndex == 0)
            {
                config.setConfig("units", "metric");
            }
            else
            {
                config.setConfig("units", "imperial");
            }
            config.saveConfig();
            this.Close();
            cb();
        }
    }
}
