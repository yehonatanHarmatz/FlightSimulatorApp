using FlightSimulatorApp.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public class MapVM : INotifyPropertyChanged
    {
        private double vmLongitude = 34.8854;
        private double vmLongitudePrev = 0;
        private double vmLatitude = 32.0055;
        private double vmLatitudePrev = 0;
        private string location = "32.0055,34.8854";
        private Model m;
        private double rotate;
        private bool first = true;
        private double zoom = 1;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double Longitude
        {
            get
            {
                return this.vmLongitude;
            }
        }
        public double Rotate
        {
            get
            {
                return this.rotate;
            }
            set
            {
                if (value != rotate)
                {
                    rotate = value;
                    OnPropertyChanged("Rotate");
                }
            }
        }

        public double Latitude
        {
            get
            {
                return this.vmLatitude;
            }
        }
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (value != location)
                {
                    location = value;
                    OnPropertyChanged("Location");
                }
            }
        }

        public double Zoom
        {
            get
            {
                return this.zoom;
            }
            set
            {
                if (value != zoom && Math.Abs(zoom - value) > 0.5)
                {
                    zoom = value;
                    OnPropertyChanged("Zoom");
                }
            }
        }

        public MapVM(Model m)
        {
            this.m = m;
            this.m.propertyChanged += M_propertyChangedEvent;
        }
        /****
         * calculate auot zoom
         ****/
        private static double CalculateZoom(double v)
        {
            double zoom = 16 - 1.1 * Math.Log(v);
            return Math.Max(1, Math.Min(zoom, 16));
        }
        /****
         * calculate distance via cordination
         ****/
         
        private static double DistanceOnGeoid(double lat1, double lon1, double lat2, double lon2)
        {

            // Convert degrees to radians
            lat1 = lat1 * Math.PI / 180.0;
            lon1 = lon1 * Math.PI / 180.0;

            lat2 = lat2 * Math.PI / 180.0;
            lon2 = lon2 * Math.PI / 180.0;

            // radius of earth in metres
            double r = 6378100;

            // P
            double rho1 = r * Math.Cos(lat1);
            double z1 = r * Math.Sin(lat1);
            double x1 = rho1 * Math.Cos(lon1);
            double y1 = rho1 * Math.Sin(lon1);

            // Q
            double rho2 = r * Math.Cos(lat2);
            double z2 = r * Math.Sin(lat2);
            double x2 = rho2 * Math.Cos(lon2);
            double y2 = rho2 * Math.Sin(lon2);

            // Dot product
            double dot = (x1 * x2 + y1 * y2 + z1 * z2);
            double cos_theta = dot / (r * r);

            double theta = Math.Acos(cos_theta);

            // Distance in Metres
            return r * theta;
        }
        /****
         * calculate heading via cordination
         ****/
        private static double HeadingCalculator(double lat1, double lon1, double lat2, double lon2)
        {
            double phi1 = (Math.PI / 180) * lat1;
            double phi2 = (Math.PI / 180) * lat2;
            double lambda1 = (Math.PI / 180) * lon1;
            double lambda2 = (Math.PI / 180) * lon2;
            double x = Math.Cos(phi1) * Math.Sin(phi2) - Math.Cos(phi2) * Math.Sin(phi1) * Math.Cos(lambda2 - lambda1);
            double y = Math.Cos(phi2) * Math.Sin(lambda2 - lambda1);
            return (180 / Math.PI) * (Math.Atan2(y, x));
        }
        /***
         * when location update 
         ***/
        private void M_propertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Longitude"))
            {
                this.vmLongitudePrev = this.vmLongitude;
                this.vmLongitude = m.Longitude;
                if (!first)
                {
                    Zoom = CalculateZoom(DistanceOnGeoid(vmLatitudePrev, vmLongitudePrev, vmLatitude, vmLongitude));
                }
                if (!first && !m.ErrorMessage.Equals(TimeOutException.Instance.Message))
                {
                    //if (m.Heading != null && m.Heading.Equals("ERR"))
                    {
                        Rotate = HeadingCalculator(vmLatitudePrev, vmLongitudePrev, vmLatitude, vmLongitude);
                    }
                    /*else if (m.Heading != null)
                    {
                        double d;
                        if (Double.TryParse(m.Heading, out d))
                        {
                            Rotate = d;
                        }
                    }*/
                }
                else
                {
                    first = false;
                }

            }
            else if (e.PropertyName.Equals("Latitude"))
            {
                this.vmLatitudePrev = this.vmLatitude;
                this.vmLatitude = m.Latitude;
            }
            Location = Latitude.ToString() + "," + Longitude.ToString();
        }
    }
}