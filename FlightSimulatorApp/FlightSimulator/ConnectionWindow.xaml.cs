using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ConnectionWindow : Window, INotifyPropertyChanged
    {
        private System.Configuration.Configuration config;
        //private delegate void ClickConnect();
        public EventHandler listeners;
        private string ip;
        private string port;
        private bool inalize = true;
        public event PropertyChangedEventHandler PropertyChanged;

        public ConnectionWindow()
        {
            InitializeComponent();
            DataContext = this;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Inalize();
        }
        public string Port
        {
            get => port;
            set
            {
                if (port != value)
                {
                    port = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Port"));
                }
            }
        }
        public string Ip
        {
            get => ip;
            set
            {
                if (ip != value)
                {
                    ip = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ip"));
                }
            }
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            this.listeners(this, new EventArgs());
            this.Close();
        }

        private void ChangePort(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Name == "PortTextBox")
            {
                TextBox textBox = sender as TextBox;
                config.AppSettings.Settings["Port"].Value = textBox.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

            }
        }
        private void ChangeIP(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Name == "IPTextBox")
            {
                TextBox textBox = sender as TextBox;
                config.AppSettings.Settings["IP"].Value = textBox.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

            }
        }
        private void Inalize()
        {
            var appSettings = ConfigurationManager.AppSettings;
            Ip = appSettings["IP"];
            Port = appSettings["Port"];
            ((TextBox)this.FindName("IPTextBox")).Text = Ip;
            ((TextBox)this.FindName("PortTextBox")).Text = Port;

        }
    }
}