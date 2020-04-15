using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    class VMPanel : INotifyPropertyChanged
    {
        private Model model;
        public VMPanel(Model model)
        {
            this.model = model;
            this.model.propertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                OnPropertyChanged(e.PropertyName);
            };
        }
        public string Heading
        {
            get 
            {
                return model.Heading;
            }
            set
            {
                // updates property
                this.OnPropertyChanged("Heading");
            }
        }
        public string VerticalSpeed
        {
            get { return model.VerticalSpeed; }
            set
            {
                // updates property
                this.OnPropertyChanged("VerticalSpeed");
            }
        }
        public string GroundSpeed
        {
            get { return model.GroundSpeed; }
            set
            {
                // updates property
                this.OnPropertyChanged("GroundSpeed");
            }
        }
        public string Speed
        {
            get { return model.Speed; }
            set
            {
                // updates property
                this.OnPropertyChanged("Speed");
            }
        }
        public string GpsAltitude
        {
            get { return model.GpsAltitude; }
            set
            {
                // updates property
                this.OnPropertyChanged("GpsAltitude");
            }
        }
        public string Roll
        {
            get { return model.Roll; }
            set
            {
                // updates property
                this.OnPropertyChanged("Roll");
            }
        }
        public string Pitch
        {
            get { return model.Pitch; }
            set
            {
                // updates property
                this.OnPropertyChanged("Pitch");
            }
        }
        public string AltimeterAltitude
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