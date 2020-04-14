using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Exceptions
{
    class CantReadException : IOException
    {
        private static CantReadException instance = new CantReadException();
        public static CantReadException Instance
        {
            get => instance;
        }
        private CantReadException()
        {
        }
        public override string Message
        {
            get => "Can't reading message from the server";
        }
    }
}
