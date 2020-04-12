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
    public partial class Connection : UserControl, INotifyPropertyChanged
    {
        private bool isConnect = false;
        private Connection_VM cvm;
        private string text = "The Server is: Disconnect";
        
        public Connection()
        {
            InitializeComponent();
        }
        
        public Connection(Connection_VM cvm)
        {
            InitializeComponent();
            this.cvm = cvm;
            DataContext = this;
        }

        public string Text
        {
            get => text; 
            set
            {
                if (!text.Equals(value))
                {
                    text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void ClickConnect(object sender, EventArgs e)
        {
            if (cvm != null)
            {
                cvm.Connect();
                isConnect = true;
                Text = "The Server is: Connect";
            }
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            if (!isConnect)
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
            if (isConnect)
            {
                if (cvm != null)
                {
                    cvm.Disonnect();
                    isConnect = false;
                    Text = "The Server is: Disconnect";
                }
            }
        }
    }
}
