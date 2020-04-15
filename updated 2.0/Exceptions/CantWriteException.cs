using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Exceptions
{
    class CantWriteException : IOException
    {
        private static CantWriteException instance = new CantWriteException();
        public static CantWriteException Instance
        {
            get => instance;
        }
        private CantWriteException()
        {
        }
        public override string Message
        {
            get => "Can't sending message to the server";
        }
    }
}
