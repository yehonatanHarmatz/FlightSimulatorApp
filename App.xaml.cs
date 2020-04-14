using FlightSimulatorApp.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private Model model;
        private string port;
        private string ip;


        /*private void Application_Startup(object sender, StartupEventArgs e)
        {
            Model m = new Model();
            Connection_VM cvm = new Connection_VM(m);
            Map_VM map_vm = new Map_VM(m);
            INotifyPropertyChanged vm_panel = new VM_Panel(m);
            INotifyPropertyChanged vm_navigator = new VM_Navigator(m);
            this.Map = new views.Map(map_vm);
            this.Connection = new views.Connection(cvm);
            this.panel = new Panel();
        }*/
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.model = new Model();
            INotifyPropertyChanged vm_panel = new VM_Panel(model);
            INotifyPropertyChanged vm_navigator = new VM_Navigator(model);
            INotifyPropertyChanged map_vm = new Map_VM(model);
            Connection_VM cvm = new Connection_VM(model);
            INotifyPropertyChanged errorsVm = new ErrorDisplayVM(model);

            Connection connection = new views.Connection(cvm);
            MainWindow my_window = new MainWindow();

            my_window.panel.DataContext = vm_panel;
            my_window.navigator.DataContext = vm_navigator;
            my_window.map.DataContext = map_vm;
            my_window.errors.DataContext = errorsVm;

            Grid grid = ((Grid)my_window.FindName("Grid"));
            grid.Children.Add(connection);
            Grid.SetRow(connection, 1);
            Grid.SetColumn(connection, 1);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.port = config.AppSettings.Settings["Port"].Value;
            this.ip = config.AppSettings.Settings["IP"].Value;

            my_window.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Port"].Value = "5402";
            config.AppSettings.Settings["IP"].Value = "127.0.0.1";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            this.model.Stop();

        }

    }
}