using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for ConnectionWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Configuration.Configuration config;
        public MainWindow()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            SimulatorWindow sw = new SimulatorWindow();
            sw.Show();
            this.Close();
        }

        private void ChangePort(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Name == "PortTextBox")
            {
                TextBox textBox = sender as TextBox;
                config.AppSettings.Settings["Port"].Value = textBox.Text;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }
        private void ChangeIP(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Name == "IPTextBox")
            {
                TextBox textBox = sender as TextBox;
                config.AppSettings.Settings["IP"].Value = textBox.Text;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
}
