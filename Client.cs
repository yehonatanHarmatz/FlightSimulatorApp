using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    class Client
    {
        private TcpClient socket;
        private String reminder;
        private NetworkStream stream;
        public void Connect(String ip, Int32 port)
        {
            try
            {
                // Create a TcpClient.
                socket = new TcpClient(ip, port);
                this.stream = socket.GetStream();
                reminder = "";

                /*open new thred for coonection with the server*/
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        public void Disconnecet()
        {
            socket.Close();
        }
        
        public void Write(String message)
        {
            try
            {
                //NetworkStream stream = socket.GetStream();
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                //stream.Close();
            } catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }
        public String Read()
        {
            try
            {
                //NetworkStream stream = socket.GetStream();
                String answer = String.Empty;
                while (reminder.IndexOf('\n') == -1)
                {
                    Byte[] data = new Byte[256];
                    // String to store the response ASCII representation.
                    String responseData = String.Empty;
                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    reminder += responseData;
                }
                answer = reminder.Split('\n')[0];
                reminder = reminder.Remove(0, answer.Length+1);
                //stream.Close();
                return answer;
            } catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
                return "ERR";
            }
        }
       
    }
}
