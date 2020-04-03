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
    class Model : INotifyPropertyChanged
    {
        private Mutex mtx = new Mutex();

        private Client c;
        private String ip;
        private Int32 port;
        private Queue<String> setMessages;
        private bool stop = false;

        private double longitude = 0;
        private double latitude = 0;
        
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
                else if (Math.Abs(value) > 84.99)
                {
                    if (Longitude > 0)
                    {
                        Longitude = 84.99;
                    }
                    else
                    {
                        Longitude = -84.99;
                    }
                    /*ERR*/
                }
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
                else if (Math.Abs(value) > 180)
                {
                    if (Latitude > 0)
                    {
                        Latitude = 180;
                    }
                    else
                    {
                        Latitude = -180;
                    }
                    /*ERR*/
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
                    //Heading = Double.Parse(s.Split('=')[1]);
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
                    //VerticalSpeed = Double.Parse(s.Split('=')[1]);
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
                    c.Write(s+'\n');
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

        public void Test()
        {
            double i = 0.1;
            Random r = new Random();
            bool a = false;
            
            while (true)
            {
                if (r.Next(3) == 0)
                {
                    if (a)
                        Longitude += i;
                    else
                        Longitude -= i;
                    if (Math.Abs(Longitude) > 85)
                    {
                        Latitude += 180;
                        a = !a;
                    }
                }
                else
                {
                    Latitude += i;
                    
                }
                Thread.Sleep(1);
            }
        }
    }
}
