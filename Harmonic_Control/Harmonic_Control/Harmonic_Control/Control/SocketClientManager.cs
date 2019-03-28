using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Harmonic_Control
{
    public delegate int CheckStatusResult(string hot, int port, int COMMAND, string itemNameControl);
    public delegate int SendTimeSettingResult(string hot, int port, double hours, string itemNameControl);

    class SocketClientManager
    {
        public static int result = 2;

        public int CheckHamonic_Status(string host, int port, int COMMAND, string itemNameControl)
        {
            var resultVar = 2;
            //CheckStatusResult checkStatusResult = new CheckStatusResult(HamonicCheckStatus);//  this.HamonicCheckStatus;
            //IAsyncResult asyncResult = checkStatusResult.BeginInvoke(host, port, COMMAND, itemNameControl, null, null);
            //resultVar =( checkStatusResult.EndInvoke(asyncResult));
            //SetStatusCheck(resultVar);
            Task.Factory.StartNew(() =>
            {
                resultVar = HamonicCheckStatus(host, port, COMMAND, itemNameControl);
                SetStatusCheck(resultVar);
                return;
            });

            return resultVar;
        }

        public static int GetStatusCheck()
        {
            return result;
        }
        public void SetStatusCheck(int status)
        {
            result = status;
        }
        public int SetTimeCommand(string host, int port, double hours, string itemNameControl)
        {
            SendTimeSettingResult checkStatusResult = this.CheckStatusSetTime;
            IAsyncResult asyncResult = checkStatusResult.BeginInvoke(host, port, hours, itemNameControl, null, null);
            var resultVar = checkStatusResult.EndInvoke(asyncResult);
            return (int)resultVar;
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
                if (status == ConstDefine.HARMONIC_OFF)
                    return ConstDefine.HARMONIC_OFF;
                else if (status == ConstDefine.HARMONIC_ON)
                    return ConstDefine.HARMONIC_ON;
                else
                    return ConstDefine.HARMONIC_NOT_CONNNECT;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connect to socket server:" + e.Message);
                return ConstDefine.HARMONIC_NOT_CONNNECT;
            }
        }
        private int CheckStatusSetTime(string host, int port, double hours, string itemNameControl)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(host, port);
                Socket socket = tcpClient.Client;
                SendTimeData(socket, hours, itemNameControl);

                NetworkStream nwStream = tcpClient.GetStream();
                byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, tcpClient.ReceiveBufferSize);
                String dataString = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));

                Thread.Sleep(500);
                socket.Disconnect(true);
                DisConnect(tcpClient);
                tcpClient.Close();
                int status = GetStatusFromDataReciveForSetTime(dataString, itemNameControl);
                if (status == ConstDefine.HARMONIC_SET_TIME_FALSE)
                    return ConstDefine.HARMONIC_SET_TIME_FALSE;
                else if (status == ConstDefine.HARMONIC_SET_TIME_TRUE)
                    return ConstDefine.HARMONIC_SET_TIME_TRUE;
                else
                    return ConstDefine.HARMONIC_NOT_CONNNECT;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connect to socket server:" + e.Message);
                return ConstDefine.HARMONIC_NOT_CONNNECT;
            }
        }
        private void DisConnect(TcpClient tcpClient)
        {
            if (tcpClient.Connected)
            {
                tcpClient.Close();
                //  tcpClient.Dispose();

            }
        }
        private void SendData(Socket s, int COMMAND, string itemNameControl)
        {
            String dataString = itemNameControl + ":" + COMMAND;

            byte[] bytes = Encoding.ASCII.GetBytes(dataString);
            s.Send(bytes);
        }
        private void SendTimeData(Socket s, double hours, string itemNameControl)
        {
            String dataString = itemNameControl + "," + hours;

            byte[] bytes = Encoding.ASCII.GetBytes(dataString);
            s.Send(bytes);
        }

        private int GetStatusFromDataRecive(string DataString, string itemNameControl)
        {

            bool checkCorrectitem = DataString.Contains(itemNameControl);
            if (!checkCorrectitem)
                return ConstDefine.HARMONIC_NOT_CONNNECT;
            String hamonicStatus = DataString.Split(':')[1];
            Int32.TryParse(hamonicStatus, out int status);
            return status;
        }
        private int GetStatusFromDataReciveForSetTime(string DataString, string itemNameControl)
        {

            bool checkCorrectitem = DataString.Contains(itemNameControl);
            if (!checkCorrectitem)
                return ConstDefine.HARMONIC_NOT_CONNNECT;
            String hamonicStatus = DataString.Split(',')[1];
            Int32.TryParse(hamonicStatus, out int status);
            return status;
        }
    }
}
