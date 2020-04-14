using FlightSimulatorApp.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public class Connection_VM : INotifyPropertyChanged
    {
        private Model m;
        private bool isConnect;
        private string text = "The Server is: Disconnected";

        public Connection_VM(Model m)
        {
            this.m = m;
            this.m.propertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName.Equals("Connection"))
                {
                    IsConnect = m.Connection;
                }
            };
        }
        public string Text
        {
            get => "Status: " + text;
            set
            {
                if (!text.Equals(value))
                {
                    text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsConnect
        { 
            get => isConnect;
            set
            {
                if (value != isConnect)
                {
                    isConnect = value;
                    if (value)
                    {
                        Connect();
                    }
                    else
                    {
                        Disonnect();
                        Text = "The Server is: Disconnected";
                    }
                }
            }
        }

        public void Connect()
        {
            Task task = new Task(m.Start);
            task.ContinueWith(t =>
            {
                foreach (var e in task.Exception.InnerExceptions)
                {
                    // Handle the exceptions of server not connected.
                    if (e is CantConnectException || e is ServerDisconnectedException)
                    {
                        IsConnect = false;
                    }
                    // Rethrow any other exception.
                    else
                    {
                        throw e;
                    }
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t => { Text = "The Server is: Connected"; }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
            isConnect = true;
            //Thread t1 = new Thread(m.Start);
            //t1.Start();
            /*catch (Exception e)
            {

            }*/

        }
        public void Disonnect()
        {
            try
            {
                this.m.Stop();
            }
            catch (Exception e)
            {
                /***TO-DO***/
            }
        }
    }
}
