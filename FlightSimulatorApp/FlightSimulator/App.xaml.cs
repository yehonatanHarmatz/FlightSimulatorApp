using FlightSimulatorApp.views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private Map map;
        private Connection connection;
        public Map Map { get => map; set => map = value; }
        public Connection Connection { get => connection; set => connection = value; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Model m = new Model();
            Connection_VM cvm = new Connection_VM(m);
            Map_VM map_vm = new Map_VM(m);
            this.Map = new views.Map(map_vm);
            this.Connection = new views.Connection(cvm);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Port"].Value = "5402";
            config.AppSettings.Settings["IP"].Value = "127.0.0.1";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

        }
    }
}