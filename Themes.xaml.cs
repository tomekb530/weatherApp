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
    /// Logika interakcji dla klasy Themes.xaml
    /// </summary>
    public partial class Themes : Window
    {
        private Config config;
        private Action cb;
        public Themes(Action cb)
        {
            InitializeComponent();
            config = new Config();
            this.cb = cb;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            config.saveConfig();
            this.Close();
            cb();
        }

        private void themesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string theme = "dark";
            if (themesComboBox.SelectedIndex == 0)
            {
                theme = "light";
            }
            else if (themesComboBox.SelectedIndex == 1)
            {
                theme = "clight";
            }
            else if (themesComboBox.SelectedIndex == 2)
            {
                theme = "dark";
            }
            else if (themesComboBox.SelectedIndex == 3)
            {
                theme = "cdark";
            }
            config.setConfig("theme", theme);
        }
    }
}
