using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    class Map_VM : INotifyPropertyChanged
    {
        private double vm_longitude = 0;
        private double vm_latitude = 0;
        private string location = "0,0";
        private Model m;

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

        private void M_propertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Longitude"))
            {
                this.vm_longitude = m.Longitude;
            } else if (e.PropertyName.Equals("Latitude"))
            {
                this.vm_latitude = m.Latitude;
            }
            Location = Longitude.ToString() + "," + Latitude.ToString();
        }
    }
}
