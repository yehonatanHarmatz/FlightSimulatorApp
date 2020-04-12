using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Configuration;

namespace FlightSimulatorApp
{
    public class Model : INotifyPropertyChanged
    {
        private Mutex mtx = new Mutex();

        private Client c;
        private String ip;
        private Int32 port;
        private Queue<String> setMessages;
        private bool stop = false;

        private double longitude = 0;
        private double latitude = 0;
        private double heading;
        private double verticalSpeed;
        private double groundSpeed;
        private double speed;
        private double gpsAltitude;
        private double roll;
        private double pitch;
        private double altimeterAltitude;

        public delegate void PropertyChanged(object sender, PropertyChangedEventArgs e);
        public event PropertyChangedEventHandler propertyChanged;

        public Model()
        {
            this.c = new Client();
            this.setMessages = new Queue<String>();
        }
        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (Math.Abs(value) <= 84.99 && Longitude != value)
                {
                    longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
                /*else if (Math.Abs(value) > 84.99)
                {
                    if (Longitude > 0)
                    {
                        Longitude = 84.99;
                    }
                    else
                    {
                        Longitude = -84.99;
                    }
                    /*ERR/
                }*/
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

                if (Math.Abs(value) <= 180 && latitude != value)
                {
                    latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
                /*else if (Math.Abs(value) > 180)
                {
                    if (Latitude > 0)
                    {
                        Latitude = 180;
                    }
                    else
                    {
                        Latitude = -180;
                    }
                    /*ERR
                }*/
            }
        }

        public double Heading
        {
            get => this.heading;
            set
            {
                heading = value;
                NotifyPropertyChanged("Heading");
            }
        }

        public double VerticalSpeed
        {
            get => this.verticalSpeed;
            set
            {
                verticalSpeed = value;
                NotifyPropertyChanged("VerticalSpeed");
            }
        }

        public double GroundSpeed
        {
            get => this.groundSpeed;
            set
            {
                groundSpeed = value;
                NotifyPropertyChanged("GroundSpeed");
            }
        }

        public double Speed
        {
            get => this.speed;
            set
            {
                speed = value;
                NotifyPropertyChanged("Speed");
            }
        }

        public double GpsAltitude
        {
            get => this.gpsAltitude;
            set
            {
                gpsAltitude = value;
                NotifyPropertyChanged("GpsAltitude");
            }
        }
        public double Roll
        {
            get => this.roll;
            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }

        public double Pitch
        {
            get => this.pitch;
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }

        public double AltimeterAltitude
        {
            get => this.altimeterAltitude;
            set
            {
                altimeterAltitude = value;
                NotifyPropertyChanged("AltimeterAltitude");
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
        public void GetDashboardInformation()
        {
            List<string> dashboard = new List<string>()
            {
            "/instrumentation/heading-indicator/indicated-heading-deg",
            "/instrumentation/gps/indicated-vertical-speed",
            "/instrumentation/gps/indicated-ground-speed-kt",
            "/instrumentation/airspeed-indicator/indicated-speed-kt",
            "/instrumentation/gps/indicated-altitude-ft",
            "/instrumentation/attitude-indicator/internal-roll-deg",
            "/instrumentation/attitude-indicator/internal-pitch-deg",
            "/instrumentation/altimeter/indicated-altitude-ft",
            };
            while (!stop)
            {
                string s = String.Empty;
                mtx.WaitOne();
                c.Write("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    Heading = Double.Parse(s.Split('=')[1]);
                }
                mtx.ReleaseMutex();
                mtx.WaitOne();
                c.Write("get /instrumentation/gps/indicated-vertical-speed\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    VerticalSpeed = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                /**3**/
                mtx.WaitOne();
                c.Write("get /instrumentation/gps/indicated-ground-speed-kt\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    GroundSpeed = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                /**4**/
                mtx.WaitOne();
                c.Write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    Speed = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                /**5**/
                mtx.WaitOne();
                c.Write("get /instrumentation/gps/indicated-altitude-ft\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    GpsAltitude = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                /**6**/
                mtx.WaitOne();
                c.Write("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    Roll = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                /**7**/
                mtx.WaitOne();
                c.Write("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    Pitch = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                /**8**/
                mtx.WaitOne();
                c.Write("get /instrumentation/altimeter/indicated-altitude-ft\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    AltimeterAltitude = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                Thread.Sleep(250);
            }
        }
        public void GetMapInformation()
        {
            List<string> map = new List<string>()
            {
            "position/latitude-deg",
            "position/longitude-deg",
            };

            while (!stop)
            {
                string s = String.Empty;
                mtx.WaitOne();
                c.Write("get /position/latitude-deg\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    //Latitude = Double.Parse(s.Split('=')[1]);
                    Latitude = Double.Parse(s);
                }
                mtx.ReleaseMutex();
                mtx.WaitOne();
                c.Write("get /position/longitude-deg\n");
                s = c.Read();
                if (s == "ERR")
                {
                    /****complete****/
                }
                else
                {
                    //Longitude = Double.Parse(s.Split('=')[1]);
                    Longitude = Double.Parse(s);
                }
                mtx.ReleaseMutex();

            }
        }
        public void SendSetMessages()
        {
            while (!stop)
            {
                if (setMessages.Count > 0)
                {
                    string s = setMessages.Dequeue();
                    mtx.WaitOne();
                    c.Write(s + '\n');
                    s = c.Read();
                    if (s == "ERR")
                    {
                        /****complete****/
                    }
                    mtx.ReleaseMutex();
                }
            }
        }
        public void AddSetMessage(String message)
        {
            setMessages.Enqueue(message);
        }
        public void Start()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string ip = appSettings["IP"];
            Int32 port = Int32.Parse(appSettings["Port"]);
            this.stop = false;
            this.c.Connect(ip, port);
            Thread t1 = new Thread(this.SendSetMessages);
            Thread t2 = new Thread(this.GetMapInformation);
            //t2 = new Thread(this.Test);
            Thread t3 = new Thread(this.GetDashboardInformation);
            t1.Start();
            t2.Start();
            t3.Start();
            //Test();
        }
        public void Stop()
        {
            this.stop = true;
            this.c.Disconnecet();
        }
        
    }
}