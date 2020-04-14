using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlightSimulatorApp
{
    class ErrorDisplayVM : INotifyPropertyChanged
    {
        private string error;
        private Timer timer = null;
        public ErrorDisplayVM(Model m)
        {
            m.propertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName.Equals("ErrorMessage"))
                {
                    ErrorMessage = "Error: " + m.ErrorMessage;
                }
            };
        }
        public string ErrorMessage
        {
            get=>this.error;
            set
            {
                if (!value.Equals(""))
                {
                    if (timer != null)
                    {
                        timer.Stop();
                    }
                    timer = new Timer(3000);
                    timer.Elapsed += delegate (Object source, ElapsedEventArgs e)
                    {
                        ErrorMessage = "";
                    };
                    timer.Enabled = true;
                }
                if (!value.Equals(error))
                {
                    error = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
