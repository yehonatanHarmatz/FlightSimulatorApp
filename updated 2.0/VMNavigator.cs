using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    class VMNavigator : INotifyPropertyChanged
    {
        private Model model;
        public VMNavigator(Model model)
        {
            this.model = model;
        }
        public double RUDDER
        {
            get { return model.RUDDER; }
            set
            {
                // updates property
                value = Math.Round(value, 3);
                model.RUDDER = value;
                this.OnPropertyChanged("RUDDER");
                // adds a set message
                model.AddSetMessage("set /controls/flight/rudder " + value.ToString());
            }
        }
        public double ELEVATOR
        {
            get { return model.ELEVATOR; }
            set
            {
                // updates property
                value = Math.Round(value, 3);
                model.ELEVATOR = value;
                this.OnPropertyChanged("ELEVATOR");
                // adds a set message
                model.AddSetMessage("set /controls/flight/elevator " + value.ToString());
            }
        }
        public double AILERON
        {
            get { return model.AILERON; }
            set
            {
                // updates property
                value = Math.Round(value, 3);
                model.AILERON = value;
                this.OnPropertyChanged("AILERON");
                // adds a set message
                model.AddSetMessage("set /controls/flight/aileron " + value.ToString());
            }
        }
        public double THROTTLE
        {
            get { return model.THROTTLE; }
            set
            {
                // updates property
                value = Math.Round(value, 3);
                model.THROTTLE = value;
                this.OnPropertyChanged("THROTTLE");
                // adds a set message
                model.AddSetMessage("set /controls/engines/current-engine/throttle " + value.ToString());
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