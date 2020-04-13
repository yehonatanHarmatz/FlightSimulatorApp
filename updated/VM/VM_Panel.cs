using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.VM
{
    class VM_Panel : INotifyPropertyChanged
    {
        private Model model;
        public VM_Panel(Model model)
        {
            this.model = model;
        }
        public double Heading
        {
            get { return model.Heading; }
            set
            {
                // updates property
                this.OnPropertyChanged("Heading");
            }
        }
        public double VerticalSpeed
        {
            get { return model.VerticalSpeed; }
            set
            {
                // updates property
                this.OnPropertyChanged("VerticalSpeed");
            }
        }
        public double GroundSpeed
        {
            get { return model.GroundSpeed; }
            set
            {
                // updates property
                this.OnPropertyChanged("GroundSpeed");
            }
        }
        public double Speed
        {
            get { return model.Speed; }
            set
            {
                // updates property
                this.OnPropertyChanged("Speed");
            }
        }
        public double GpsAltitude
        {
            get { return model.GpsAltitude; }
            set
            {
                // updates property
                this.OnPropertyChanged("GpsAltitude");
            }
        }
        public double Roll
        {
            get { return model.Roll; }
            set
            {
                // updates property
                this.OnPropertyChanged("Roll");
            }
        }
        public double Pitch
        {
            get { return model.Pitch; }
            set
            {
                // updates property
                this.OnPropertyChanged("Pitch");
            }
        }
        public double AltimeterAltitude
        {
            get { return model.AltimeterAltitude; }
            set
            {
                // updates property
                this.OnPropertyChanged("AltimeterAltitude");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
