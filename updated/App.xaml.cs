using FlightSimulatorApp.Views;
using FlightSimulatorApp.VM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Model model = new Model();
            INotifyPropertyChanged vm_panel = new VM_Panel(model);
            INotifyPropertyChanged vm_navigator = new VM_Navigator(model);
            MainWindow my_window = new MainWindow();
            my_window.panel.DataContext = vm_panel;
            my_window.navigator.DataContext = vm_navigator;
            my_window.Show();
        }
    }
}
