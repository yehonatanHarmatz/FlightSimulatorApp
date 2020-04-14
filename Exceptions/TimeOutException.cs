using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Exceptions
{
    class TimeOutException : IOException
    {
        private static TimeOutException instance = new TimeOutException();
        public static TimeOutException Instance
        {
            get => instance;
        }
        private TimeOutException()
        {
        }
        public override string Message
        {
            get => "The Server is busy";
        }
    }
}
