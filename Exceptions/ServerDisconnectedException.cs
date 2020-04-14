using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Exceptions
{
    class ServerDisconnectedException : IOException
    {
        private static ServerDisconnectedException instance = new ServerDisconnectedException();
        public static ServerDisconnectedException Instance
        {
            get => instance;
        }
        private ServerDisconnectedException()
        {
        }
        public override string Message
        {
            get => "the server is disconnected";
        }
    }
}
