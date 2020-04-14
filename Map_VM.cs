using FlightSimulatorApp.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public class Map_VM : INotifyPropertyChanged
    {
        private double vm_longitude = 0;
        private double vm_longitudePrev = 0;
        private double vm_latitude = 0;
        private double vm_latitudePrev = 0;
        private string location = "0,0";
        private Model m;
        private double rotate;
        private bool first = true;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double Longitude
        {
            get
            {
                return this.vm_longitude;
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
                return this.vm_latitude;
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
        public Map_VM(Model m)
        {
            this.m = m;
            this.m.propertyChanged += M_propertyChangedEvent;
        }
        private static double HeadingCalculator(double lat1, double lon1, double lat2, double lon2)
        {
            double phi1 = (Math.PI / 180) * lon1;
            double phi2 = (Math.PI / 180) * lon2;
            double lambda1 = (Math.PI / 180) * lat1;
            double lambda2 = (Math.PI / 180) * lat2;
            double x = Math.Cos(phi1) * Math.Sin(phi2) - Math.Cos(phi2) * Math.Sin(phi1) * Math.Cos(lambda2 - lambda1);
            double y = Math.Cos(phi2) * Math.Sin(lambda2 - lambda1);
            return (180 / Math.PI) * (Math.Atan2(y, x));
        }
        private void M_propertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Longitude"))
            {
                this.vm_longitudePrev = this.vm_longitude;
                this.vm_longitude = m.Longitude;
                if (!first && !m.ErrorMessage.Equals(TimeOutException.Instance.Message))
                {
                    if (m.Heading.Equals("ERR"))
                    {
                        Rotate = HeadingCalculator(vm_latitudePrev, vm_longitudePrev, vm_latitude, vm_longitude);
                    }
                    else
                    {
                        Rotate = Double.Parse(m.Heading);
                    }
                }
                else
                {
                    first = false;
                }

            }
            else if (e.PropertyName.Equals("Latitude"))
            {
                this.vm_latitudePrev = this.vm_latitude;
                this.vm_latitude = m.Latitude;
            }
            Location = Longitude.ToString() + "," + Latitude.ToString();
        }
    }
}