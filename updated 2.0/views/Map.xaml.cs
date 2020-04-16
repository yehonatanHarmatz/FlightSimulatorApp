using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.views
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        MapVM map;
        public Map()
        {
            InitializeComponent();
        }
        public Map(MapVM map)
        {
            InitializeComponent();
        }
        public void SetVM(MapVM map)
        {
            this.map = map;
            this.map.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName.Equals("Zoom"))
                {
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            myMap.ZoomLevel = map.Zoom;
                            double x = Double.Parse(map.Location.Split(',')[0]);
                            double y = Double.Parse(map.Location.Split(',')[1]);
                            myMap.Center = new Location(x, y);
                        });
                    } catch(Exception ex) { }
                }
                else if (e.PropertyName.Equals("Location"))
                {
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            double x = Double.Parse(map.Location.Split(',')[0]);
                            double y = Double.Parse(map.Location.Split(',')[1]);
                            myMap.Center = new Location(x, y);
                        });
                    } catch (Exception ex) { }
                }
            };
            DataContext = map;
        }
    }
}
