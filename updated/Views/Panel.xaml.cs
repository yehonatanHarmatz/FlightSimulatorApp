using System;
using System.Collections.Generic;
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

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Panel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        private double heading;
        private double verticalSpeed;
        private double groundSpeed;
        private double speed;
        private double gpsAltitude;
        private double roll;
        private double pitch;
        private double altimeterAltitude;

        public Panel()
        {
            InitializeComponent();
        }
        public double Heading
        {
            get => this.heading;
            set
            {
                heading = value;
            }
        }

        public double VerticalSpeed
        {
            get => this.verticalSpeed;
            set
            {
                verticalSpeed = value;
            }
        }

        public double GroundSpeed
        {
            get => this.groundSpeed;
            set
            {
                groundSpeed = value;
            }
        }

        public double Speed
        {
            get => this.speed;
            set
            {
                speed = value;
            }
        }

        public double GpsAltitude
        {
            get => this.gpsAltitude;
            set
            {
                gpsAltitude = value;
            }
        }
        public double Roll
        {
            get => this.roll;
            set
            {
                roll = value;
            }
        }

        public double Pitch
        {
            get => this.pitch;
            set
            {
                pitch = value;
            }
        }

        public double AltimeterAltitude
        {
            get => this.altimeterAltitude;
            set
            {
                altimeterAltitude = value;
            }
        }
    }
}
