using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Model m = new Model();
            //Connection_VM cvm = new Connection_VM(m);
            //Map_VM map_vm = new Map_VM(m);
            //views.Map map = new views.Map(map_vm);
            //views.Connection connection = new views.Connection(cvm);
            StackPanel sp = (StackPanel)this.FindName("Stack");
            //sp.Children.Add(connection);
            //sp.Children.Add(map);
            sp.Children.Add((Application.Current as App).Connection);
            sp.Children.Add((Application.Current as App).Map);
        }
    }
}