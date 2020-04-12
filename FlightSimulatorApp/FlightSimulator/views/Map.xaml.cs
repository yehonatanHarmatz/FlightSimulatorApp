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

namespace FlightSimulatorApp.views
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        Map_VM map;
        public Map()
        {
            InitializeComponent();
        }
        public Map(Map_VM map)
        {
            InitializeComponent();
            this.map = map;
            DataContext = map;
            //Model m = new Model();
            //Map_VM map = new Map_VM(m);
            //DataContext = map;
            //Thread t1 = new Thread(m.Start);
            //t1.Start();
        }
    }
}
