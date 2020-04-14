using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Exceptions
{
    class CantConnectException : IOException
    {
        private static CantConnectException instance = new CantConnectException();
        public static CantConnectException Instance
        {
            get => instance;
        }
        private CantConnectException()
        {
        }
        public override string Message
        {
            get => "Can't Connect to the server";
        }
    }
}
