﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.VM
{
    class VM_Navigator : INotifyPropertyChanged
    {
        private Model model;
        public VM_Navigator(Model model)
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
                model.AddSetMessage("set /controls/flight/rudder");
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
                model.AddSetMessage("set /controls/flight/elevator");
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
                model.AddSetMessage("set /controls/flight/aileron");
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
                model.AddSetMessage("set /controls/engines/current-engine/throttle");
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
