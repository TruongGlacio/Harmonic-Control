using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using HamonicControl;
using Xamarin.Forms;

namespace HamonicControl
{
    class HamonicControlItem
    {
        #region define Button info

        public const string Button_On = "ON";
        public const string Button_Off = "Off";
        public const string Button_No_Connect = "NA";
        public const string Button_Text_Color_ON = "#FFFFFF";
        public const string Button_TextColor__Off = "#212121";
        public const string Button_Color_On = "#00E676";
        public const string Button_Color_Off = "#FF3D00";
        public const string Button_Color_Disconnect = "#BDBDBD";
        public const string ItemControlHeadName = " Harmonic control ";
        public const int ON_COMMAND = 1;
        public const int OFF_COMMAND = 0;
        #endregion

        #region define item control name
        // define itemname
        public string ITEMCONTROL1 = ItemControlHeadName + "1";
        public string ITEMCONTROL2 = ItemControlHeadName + "2";
        public string ITEMCONTROL3 = ItemControlHeadName + "3";
        public string ITEMCONTROL4 = ItemControlHeadName + "4";
        public string ITEMCONTROL5 = ItemControlHeadName + "5";
        public string ITEMCONTROL6 = ItemControlHeadName + "6";
        public string ITEMCONTROL7 = ItemControlHeadName + "7";
        public string ITEMCONTROL8 = ItemControlHeadName + "8";
        public string ITEMCONTROL9 = ItemControlHeadName + "9";
        public string ITEMCONTROL10 = ItemControlHeadName + "10";
        public string ITEMCONTROL11 = ItemControlHeadName + "11";
        public string ITEMCONTROL12 = ItemControlHeadName + "12";
        public string ITEMCONTROL13 = ItemControlHeadName + "13";
        public string ITEMCONTROL14 = ItemControlHeadName + "14";
        public string ITEMCONTROL15 = ItemControlHeadName + "15";
        public string ITEMCONTROL16 = ItemControlHeadName + "16";
        #endregion

        #region define socket info
        //Define Socket address

        public string SOCKET_IP1 = "192.168.137.199";
        public int SOCKET_PORT1 = 8880;
        public string SOCKET_IP2 = "192.168.137.199";
        public int SOCKET_PORT2 = 8880;
        public string SOCKET_IP3 = "192.168.137.199";
        public int SOCKET_PORT3 = 8880;
        public string SOCKET_IP4 = "192.168.137.199";
        public int SOCKET_PORT4 = 8880;
        public string SOCKET_IP5 = "192.168.137.199";
        public int SOCKET_PORT5 = 8880;
        public string SOCKET_IP6 = "192.168.137.199";
        public int SOCKET_PORT6 = 8880;
        public string SOCKET_IP7 = "192.168.137.199";
        public int SOCKET_PORT7 = 8880;
        public string SOCKET_IP8 = "192.168.137.199";
        public int SOCKET_PORT8 = 8880;
        public string SOCKET_IP9 = "192.168.137.199";
        public int SOCKET_PORT9 = 8880;
        public string SOCKET_IP10 = "192.168.137.199";
        public int SOCKET_PORT10 = 8880;
        public string SOCKET_IP11 = "192.168.137.199";
        public int SOCKET_PORT11 = 8880;
        public string SOCKET_IP12 = "192.168.137.199";
        public int SOCKET_PORT12 = 8880;
        public string SOCKET_IP13 = "192.168.137.199";
        public int SOCKET_PORT13 = 8880;
        public string SOCKET_IP14 = "192.168.137.199";
        public int SOCKET_PORT14 = 8880;
        public string SOCKET_IP15 = "192.168.137.199";
        public int SOCKET_PORT15 = 8880;
        public string SOCKET_IP16 = "192.168.137.199";
        public int SOCKET_PORT16 = 8880;
        /*..............................*/
        #endregion
        SocketClientManager socketClientManager;

        public HamonicControlItem()
        {
            socketClientManager = new SocketClientManager();
        }
        public string ItemControlName { get; set; }
        public string ButtonText { get; set; }
        public string ButtonColor { get; set; }
        public string ButtonTextColor { get; set; }

        public bool HamonicItemSetting(string itemName, int command)
        {
            if (itemName == ITEMCONTROL1)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT1, command, itemName);
            }
            else if (itemName == ITEMCONTROL2)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT2, command, itemName);
            }
            else if (itemName == ITEMCONTROL3)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT3, command, itemName);

            }
            else if (itemName == ITEMCONTROL4)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT4, command, itemName);
            }
            else if (itemName == ITEMCONTROL5)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT5, command, itemName);
            }
            else if (itemName == ITEMCONTROL6)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT6, command, itemName);

            }
            else if (itemName == ITEMCONTROL7)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT7, command, itemName);
            }
            else if (itemName == ITEMCONTROL8)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT8, command, itemName);
            }
            else if (itemName == ITEMCONTROL9)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT9, command, itemName);
            }
            else if (itemName == ITEMCONTROL10)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT10, command, itemName);
            }
            else if (itemName == ITEMCONTROL11)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT11, command, itemName);
            }
            else if (itemName == ITEMCONTROL12)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT12, command, itemName);
            }
            else if (itemName == ITEMCONTROL13)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT13, command, itemName);
            }
            else if (itemName == ITEMCONTROL14)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT14, command, itemName);
            }
            else if (itemName == ITEMCONTROL15)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT15, command, itemName);
            }
            else if (itemName == ITEMCONTROL16)
            {
                return socketClientManager.Connect(SOCKET_IP1, SOCKET_PORT16, command, itemName);
            }
            else
                return false;
        }

    }
}
