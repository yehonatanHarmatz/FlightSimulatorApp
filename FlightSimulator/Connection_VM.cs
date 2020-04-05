using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    class Connection_VM
    {
        private Model m;


        public void Connect()
        {
            try
            {
                this.m.Start();
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
