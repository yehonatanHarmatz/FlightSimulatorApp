using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FlightSimulatorApp.views
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : UserControl
    {
        private Connection_VM cvm;
        
        public Connection()
        {
            InitializeComponent();
        }
        
        public Connection(Connection_VM cvm)
        {
            InitializeComponent();
            this.cvm = cvm;
            DataContext = this.cvm;
        }

        public bool IsConnect
        { 
            get => cvm.IsConnect;
            set
            {
                if (value != IsConnect)
                {
                    cvm.IsConnect = value;
                }
            }
        }


        private void ClickConnect(object sender, EventArgs e)
        {
            if (cvm != null)
            {
                IsConnect = true;
            }
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            if (!IsConnect && ConnectionWindow.opens == 0)
            {
                ConnectionWindow cw = new ConnectionWindow();
                cw.listeners += ClickConnect;
                cw.Show();
               
            }
            else
            {
                /*******error message******/
            }

        }
        private void Disonnect(object sender, RoutedEventArgs e)
        {
            if (IsConnect)
            {
                if (cvm != null)
                {
                    IsConnect = false;
                }
            }
        }

    }
}
