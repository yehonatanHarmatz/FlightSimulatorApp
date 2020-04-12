using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public class Connection_VM
    {
        private Model m;

        public Connection_VM(Model m)
        {
            this.m = m;
        }

        public void Connect()
        {
            try
            {
                Thread t1 = new Thread(m.Start);
                t1.Start();
            } catch (Exception e)
            {
                /***TO-DO***/
            }
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
