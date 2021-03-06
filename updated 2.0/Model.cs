﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Configuration;
using FlightSimulatorApp.Exceptions;

namespace FlightSimulatorApp
{
    public class Model : INotifyPropertyChanged
    {
        private Mutex mtx = new Mutex();

        private Client c;
        private Queue<String> setMessages;
        private bool stop = false;

        private double longitude = 0;
        private double latitude = 0;
        private string heading;
        private string verticalSpeed;
        private string groundSpeed;
        private string speed;
        private string gpsAltitude;
        private string roll;
        private string pitch;
        private string altimeterAltitude;

        private double rudder = 0;
        private double elevator = 0;
        private double throttle = 0;
        private double aileron = 0;
        private string errorMessage = "";
        private bool connection;

        public delegate void PropertyChanged(object sender, PropertyChangedEventArgs e);
        public event PropertyChangedEventHandler propertyChanged;

        public Model()
        {
            this.c = new Client();
            this.setMessages = new Queue<String>();
        }
        public double RUDDER
        {
            get { return this.rudder; }
            set
            {
                this.rudder = value;
            }
        }
        public double ELEVATOR
        {
            get { return this.elevator; }
            set
            {
                this.elevator = value;
            }
        }
        public double AILERON
        {
            get { return this.aileron; }
            set
            {
                this.aileron = value;
            }
        }
        public double THROTTLE
        {
            get { return this.throttle; }
            set
            {
                this.throttle = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (Math.Abs(value) <= 180 && Longitude != value)
                {
                    longitude = value;
                }
                else if (Longitude != value)
                {
                    ErrorMessage = "the location is outside of map ranges";
                }
                NotifyPropertyChanged("Longitude");

         
            }
        }
        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {

                if (Math.Abs(value) <= 90 && latitude != value)
                {
                    latitude = value;
                }
                else if (latitude != value)
                {
                    ErrorMessage = "the location is outside of map ranges";
                }
                NotifyPropertyChanged("Latitude");

                
            }
        }

        public string Heading
        {
            get => this.heading;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    heading = value;
                    NotifyPropertyChanged("Heading");
                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        heading = value;
                        NotifyPropertyChanged("Heading");

                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
            }
        }

        public string VerticalSpeed
        {
            get => this.verticalSpeed;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    verticalSpeed = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        verticalSpeed = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("VerticalSpeed");
            }
        }

        public string GroundSpeed
        {
            get => this.groundSpeed;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    groundSpeed = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        groundSpeed = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("GroundSpeed");
            }
        }

        public string Speed
        {
            get => this.speed;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    speed = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        speed = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("Speed");
            }
        }

        public string GpsAltitude
        {
            get => this.gpsAltitude;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    gpsAltitude = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        gpsAltitude = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("GpsAltitude");
            }
        }
        public string Roll
        {
            get => this.roll;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    roll = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        roll = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("Roll");
            }
        }

        public string Pitch
        {
            get => this.pitch;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    pitch = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        pitch = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("Pitch");
            }
        }

        public string AltimeterAltitude
        {
            get => this.altimeterAltitude;
            set
            {
                double d;
                if (Double.TryParse(value, out d))
                {
                    value = Math.Round(d, 3).ToString();
                    altimeterAltitude = value;

                }
                else
                {
                    if (value.Equals("ERR"))
                    {
                        altimeterAltitude = value;
                    }
                    else
                    {
                        ErrorMessage = InvalidValueException.Instance.Message;
                    }
                }
                NotifyPropertyChanged("AltimeterAltitude");
            }
        }

        public string ErrorMessage
        {
            get => this.errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public bool Connection {
            get => this.connection;
            set
            {
                if (value != Connection)
                {
                    connection = value;
                    NotifyPropertyChanged("Connection");
                }
            } 
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (this.propertyChanged != null)
            {
                this.propertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        /****************
         * getting all the deshboard information
         ****************/
        public void GetDashboardInformation()
        {
            while (!stop)
            {
                try {
                    string s = String.Empty;
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                        s = c.Read();
                        Heading = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/gps/indicated-vertical-speed\n");
                        s = c.Read();
                        VerticalSpeed = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    /**3**/
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/gps/indicated-ground-speed-kt\n");
                        s = c.Read();
                        GroundSpeed = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    /**4**/
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                        s = c.Read();
                        Speed = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    /**5**/
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/gps/indicated-altitude-ft\n");
                        s = c.Read();
                        GpsAltitude = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    /**6**/
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                        s = c.Read();
                        Roll = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    /**7**/
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                        s = c.Read();
                        Pitch = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    /**8**/
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /instrumentation/altimeter/indicated-altitude-ft\n");
                        s = c.Read();
                        AltimeterAltitude = s;
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    Thread.Sleep(250);
                }
                finally
                {
                    try
                    {
                        mtx.ReleaseMutex();
                    }
                    catch (Exception e) { }
                }
            }
        }
        /****************
         * getting all the map information
         ****************/
        public void GetMapInformation()
        {
            List<string> map = new List<string>()
            {
            "position/latitude-deg",
            "position/longitude-deg",
            };

            while (!stop)
            {
                try
                {
                    double d;
                    string s = String.Empty;
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /position/latitude-deg\n");
                        s = c.Read();
                        if (!Double.TryParse(s, out d))
                        {
                            ErrorMessage = "recived invalid value";
                        }
                        else
                        {
                            //Latitude = Double.Parse(s.Split('=')[1]);
                            Latitude = Double.Parse(s);
                        }
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    mtx.WaitOne();
                    if (stop)
                    {
                        break;
                    }
                    try
                    {
                        c.Write("get /position/longitude-deg\n");
                        s = c.Read();
                        if (!Double.TryParse(s, out d))
                        {
                            ErrorMessage = "recived invalid value";
                        }
                        else
                        {
                            //Longitude = Double.Parse(s.Split('=')[1]);
                            Longitude = Double.Parse(s);
                        }
                    }
                    catch (TimeOutException e) { ErrorMessage = e.Message; }
                    mtx.ReleaseMutex();
                    Thread.Sleep(250);
                }
                finally
                {
                    try
                    {
                        mtx.ReleaseMutex();
                    }
                    catch (Exception e) { }
                }
            }
        }
        /****************
         * send messages
         ****************/
        public void SendSetMessages()
        {
            while (!stop)
            {
                if (setMessages.Count > 0)
                {
                    try
                    {
                        mtx.WaitOne();
                        if (stop)
                        {
                            break;
                        }
                        string s = setMessages.Dequeue();
                        c.Write(s + '\n');
                        s = c.Read();
                        if (s == "ERR")
                        {
                            ErrorMessage = "recived invalid value";
                        }
                        mtx.ReleaseMutex();
                    }
                    finally
                    {
                        try
                        {
                            mtx.ReleaseMutex();
                        }
                        catch (Exception e) { }
                    }
                }
            }
        }
        /*********
         * add set message
         *********/
        public void AddSetMessage(String message)
        {
            Task task = new Task(() =>
            {
                try
                {
                    mtx.WaitOne();
                    setMessages.Enqueue(message);
                    mtx.ReleaseMutex();
                }
                finally
                {
                    try
                    {
                        mtx.ReleaseMutex();
                    }
                    catch (Exception e) { }
                }
            });
            task.Start();
            
        }
        /********
         * start the connection with the server
         ********/
        public void Start()
        {
            this.setMessages = new Queue<string>();
            mtx = new Mutex();
            var appSettings = ConfigurationManager.AppSettings;
            string ip = appSettings["IP"];
            Int32 port = Int32.Parse(appSettings["Port"]);
            this.stop = false;
            if (!this.c.Connect(ip, port))
            {
                ErrorMessage = CantConnectException.Instance.Message;
                Connection = false;
                throw CantConnectException.Instance;
            }
            Connection = true;
            //Thread t1 = new Thread(this.SendSetMessages);
            //Thread t2 = new Thread(this.GetMapInformation);
            //Thread t3 = new Thread(this.GetDashboardInformation);
            Task t1 = new Task(this.SendSetMessages);
            t1.ContinueWith(HandleExceptions1, TaskContinuationOptions.OnlyOnFaulted);
            Task t2 = new Task(this.GetMapInformation);
            t2.ContinueWith(HandleExceptions2, TaskContinuationOptions.OnlyOnFaulted);
            Task t3 = new Task(this.GetDashboardInformation);
            t3.ContinueWith(HandleExceptions3, TaskContinuationOptions.OnlyOnFaulted);
            t1.Start();
            t2.Start();
            t3.Start();
        }
        /********
         * stop the connection with the server
         ********/
        public void Stop()
        {
            Connection = false;
            this.stop = true;
            this.c.Disconnecet();
        }
        private void HandleExceptions1(Task task)
        {
            foreach (var e in task.Exception.InnerExceptions)
            {
                ErrorMessage = e.Message;
                // Handle the exception when server disconnected.
                if (e is ServerDisconnectedException)
                {
                    Connection = false;
                }
                else
                {
                    Task t1 = new Task(this.SendSetMessages);
                    t1.ContinueWith(HandleExceptions1, TaskContinuationOptions.OnlyOnFaulted);
                    t1.Start();
                }
            }
        }
        private void HandleExceptions2(Task task)
        {
            foreach (var e in task.Exception.InnerExceptions)
            {
                ErrorMessage = e.Message;
                // Handle the exception when server disconnected.
                if (e is ServerDisconnectedException)
                {
                    Connection = false;
                }
                else
                {
                    Task t2 = new Task(this.GetMapInformation);
                    t2.ContinueWith(HandleExceptions2, TaskContinuationOptions.OnlyOnFaulted);
                    t2.Start();
                }
            }
        }
        private void HandleExceptions3(Task task)
        {
            foreach (var e in task.Exception.InnerExceptions)
            {
                ErrorMessage = e.Message;
                // Handle the exception when server disconnected.
                if (e is ServerDisconnectedException)
                {
                    Connection = false;
                }
                else
                {
                    Task t3 = new Task(this.GetDashboardInformation);
                    t3.ContinueWith(HandleExceptions3, TaskContinuationOptions.OnlyOnFaulted);
                    t3.Start();
                }
            }
        }
    }
}
