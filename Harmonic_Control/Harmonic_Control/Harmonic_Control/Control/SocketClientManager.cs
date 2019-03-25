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
    public delegate int CheckStatusResult(string hot, int port, int COMMAND, string itemNameControl);


    class SocketClientManager
    {
        public bool SendON_OFF_Command(string host, int port, int COMMAND, string itemNameControl)
        {
            bool result = false;
            ConnectSocketResult connectSocketResult = this.Connect;
            IAsyncResult asyncResult = connectSocketResult.BeginInvoke(host, port, COMMAND, itemNameControl, null, null);
            var resultVar = connectSocketResult.EndInvoke(asyncResult);
            return (bool)resultVar;
        }
        public int CheckHamonic_Status(string host, int port, int COMMAND, string itemNameControl) {
            
            CheckStatusResult checkStatusResult = this.HamonicCheckStatus;
            IAsyncResult asyncResult = checkStatusResult.BeginInvoke(host, port, COMMAND, itemNameControl, null, null);
            var resultVar = checkStatusResult.EndInvoke(asyncResult);
            return (int)resultVar;
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
                    Thread.Sleep(500);
                    socket.Disconnect(true);
                    DisConnect(tcpClient);
                    return true;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error connect to socket server:" + e.Message);
                    return false;
                }   

        }
        private int HamonicCheckStatus(string host, int port, int COMMAND, string itemNameControl)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(host, port);
                Socket socket = tcpClient.Client;
                SendData(socket, COMMAND, itemNameControl);

                NetworkStream nwStream = tcpClient.GetStream();
                byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, tcpClient.ReceiveBufferSize);
                String dataString = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));

                Thread.Sleep(500);
                socket.Disconnect(true);
                DisConnect(tcpClient);
                tcpClient.Close();
                int status = GetStatusFromDataRecive(dataString, itemNameControl);
                if (status == HamonicControlItem.HARMONIC_OFF)
                    return HamonicControlItem.HARMONIC_OFF;
                else if (status == HamonicControlItem.HARMONIC_ON)
                    return HamonicControlItem.HARMONIC_ON;
                else
                    return HamonicControlItem.HARMONIC_NOT_CONNNECT;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connect to socket server:" + e.Message);
                return HamonicControlItem.HARMONIC_NOT_CONNNECT;
            }
        }
        private void DisConnect(TcpClient tcpClient) {
            if (tcpClient.Connected)
            {
                tcpClient.Close();
              //  tcpClient.Dispose();

            }
        }
        private void SendData(Socket s, int COMMAND, string itemNameControl )
        {   
            String dataString = itemNameControl+":"+COMMAND;

            byte[] bytes = Encoding.ASCII.GetBytes(dataString);
            s.Send(bytes);
        }
       
        private int GetStatusFromDataRecive(string DataString,string itemNameControl)
        {

            bool checkCorrectitem = DataString.Contains(itemNameControl);
            if (!checkCorrectitem)
                return HamonicControlItem.HARMONIC_NOT_CONNNECT;
            String hamonicStatus = DataString.Split(',')[1];
            Int32.TryParse(hamonicStatus, out int status);
            return status;
        }
    }
}
