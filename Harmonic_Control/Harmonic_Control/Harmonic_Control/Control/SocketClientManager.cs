using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Harmonic_Control
{
    public delegate bool ConnectSocketResult(string hot, int port, int COMMAND, string itemNameControl);

    class SocketClientManager
    {
        //public static event ConnectSocketResult soketresult;
        private static object consoleLock = new object();
        private const int sendChunkSize = 256;
        private const int receiveChunkSize = 256;
        private const bool verbose = true;
        private static readonly TimeSpan delay = TimeSpan.FromMilliseconds(30000);

        public bool SendON_OFF_Command(string host, int port, int COMMAND, string itemNameControl)
        {
            bool result = false;
            ConnectSocketResult connectSocketResult = this.Connect;
            //Thread thread = new Thread(()=>
            //{ result = Connect(host, port, COMMAND, itemNameControl); });
            //thread.Start();
            //return result;
            IAsyncResult asyncResult = connectSocketResult.BeginInvoke(host, port, COMMAND, itemNameControl, null, null);
            var resultVar = connectSocketResult.EndInvoke(asyncResult);
            return (bool)resultVar;
        }
        private bool Connect(string host, int port, int COMMAND, string itemNameControl)
        {
            NetworkInterface.GetAllNetworkInterfaces();
            IPAddress[] IPs = Dns.GetHostAddresses(host);
            try
            {

                 TcpClient tcpClient = new TcpClient(host, port);
                 Socket socket = tcpClient.Client;
                 SendData(socket, COMMAND, itemNameControl);
                 socket.Disconnect(true);
                 DisConnect(tcpClient);
                 return true;
             
            }
            catch (Exception e)
            {
                   Console.WriteLine("Error connect to socket server:"+e.Message);
                return false;
            }
            //Socket s = new Socket(AddressFamily.InterNetwork,
            //    SocketType.Stream,
            //    ProtocolType.Tcp);

            //Console.WriteLine("Establishing Connection to {0}",host);
            //try
            //{
            //    s.Connect(IPs[0], port);
            //    SendData(s);
            //    Console.WriteLine("Connection established");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error connect to socket server:"+e.Message);
            //}
        }
        public void DisConnect(TcpClient tcpClient) {
            if (tcpClient.Connected)
            {
                tcpClient.Close();
              //  tcpClient.Dispose();

            }
        }
        public void SendData(Socket s, int COMMAND, string itemNameControl )
        {   
            String dataString = itemNameControl+":"+COMMAND;

            byte[] bytes = Encoding.ASCII.GetBytes(dataString);
            s.Send(bytes);
        }
    }
}
