using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Exceptions
{
    class InvalidValueException : IOException
    {
        private static InvalidValueException instance = new InvalidValueException();
        public static InvalidValueException Instance
        {
            get => instance;
        }
        private InvalidValueException()
        {
        }
        public override string Message
        {
            get => "recived invalid value";
        }
    }
}
