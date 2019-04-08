using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Harmonic_Control
{
    struct StructDefine
    {
        static public List<int> StatusCheck_ON_OFF_List;
        static public List<int> StatusSetTimeList;
    }
    class ConstDefine
    {
        #region define Button info
        public const string Button_On = "ON";
        public const string Button_Off = "Off";
        public const string Button_No_Connect = "NA";
        public const string Button_Set_Time_Text = "Time";
        public const string Button_Text_Color_ON = "#FFFFFF";
        public const string Button_Text_Color_OFF = "#212121";
        public const string Button_Color_On = "#00E676";
        public const string Button_Color_Off = "#FF3D00";
        public const string Button_Color_Disconnect = "#BDBDBD";
        public const string ItemControlHeadName = " Harmonic control ";


        public const int OFF_COMMAND = 0;
        public const int ON_COMMAND = 1;
        public const int CHECKSTATUS_COMMAND = 2;

        public const int HARMONIC_OFF = 0;
        public const int HARMONIC_ON = 1;
        public const int HARMONIC_NOT_CONNNECT = 2;

        public const int HARMONIC_SET_TIME_FALSE = 0;
        public const int HARMONIC_SET_TIME_TRUE = 1;

        #endregion

        #region define item control name
        // define itemname
        public const string ITEMCONTROL1 = ItemControlHeadName + "1";
        public const string ITEMCONTROL2 = ItemControlHeadName + "2";
        public const string ITEMCONTROL3 = ItemControlHeadName + "3";
        public const string ITEMCONTROL4 = ItemControlHeadName + "4";
        public const string ITEMCONTROL5 = ItemControlHeadName + "5";
        public const string ITEMCONTROL6 = ItemControlHeadName + "6";
        public const string ITEMCONTROL7 = ItemControlHeadName + "7";
        public const string ITEMCONTROL8 = ItemControlHeadName + "8";
        public const string ITEMCONTROL9 = ItemControlHeadName + "9";
        public const string ITEMCONTROL10 = ItemControlHeadName + "10";
        public const string ITEMCONTROL11 = ItemControlHeadName + "11";
        public const string ITEMCONTROL12 = ItemControlHeadName + "12";
        public const string ITEMCONTROL13 = ItemControlHeadName + "13";
        public const string ITEMCONTROL14 = ItemControlHeadName + "14";
        public const string ITEMCONTROL15 = ItemControlHeadName + "15";
        public const string ITEMCONTROL16 = ItemControlHeadName + "16";
        #endregion

        #region define socket info
        //Define Socket address

        public const string SOCKET_IP1 = "192.168.137.214";
        public const int SOCKET_PORT1 = 8880;
        public const string SOCKET_IP2 = "192.168.137.199";
        public const int SOCKET_PORT2 = 8880;
        public const string SOCKET_IP3 = "192.168.137.199";
        public const int SOCKET_PORT3 = 8880;
        public const string SOCKET_IP4 = "192.168.137.199";
        public const int SOCKET_PORT4 = 8880;
        public const string SOCKET_IP5 = "192.168.137.199";
        public const int SOCKET_PORT5 = 8880;
        public const string SOCKET_IP6 = "192.168.137.199";
        public const int SOCKET_PORT6 = 8880;
        public const string SOCKET_IP7 = "192.168.137.199";
        public const int SOCKET_PORT7 = 8880;
        public const string SOCKET_IP8 = "192.168.137.199";
        public const int SOCKET_PORT8 = 8880;
        public const string SOCKET_IP9 = "192.168.137.199";
        public const int SOCKET_PORT9 = 8880;
        public const string SOCKET_IP10 = "192.168.137.199";
        public const int SOCKET_PORT10 = 8880;
        public const string SOCKET_IP11 = "192.168.137.199";
        public const int SOCKET_PORT11 = 8880;
        public const string SOCKET_IP12 = "192.168.137.199";
        public const int SOCKET_PORT12 = 8880;
        public const string SOCKET_IP13 = "192.168.137.199";
        public const int SOCKET_PORT13 = 8880;
        public const string SOCKET_IP14 = "192.168.137.199";
        public const int SOCKET_PORT14 = 8880;
        public const string SOCKET_IP15 = "192.168.137.199";
        public const int SOCKET_PORT15 = 8880;
        public const string SOCKET_IP16 = "192.168.137.199";
        public const int SOCKET_PORT16 = 8880;
        /*..............................*/
        public static readonly IList<String> SOCKET_IP_LIST = new ReadOnlyCollection<string>
            (new List<String>
            {
                "None",SOCKET_IP1, SOCKET_IP2,SOCKET_IP3, SOCKET_IP4, SOCKET_IP5, SOCKET_IP5, SOCKET_IP6, SOCKET_IP7,
                SOCKET_IP8, SOCKET_IP9, SOCKET_IP10, SOCKET_IP11, SOCKET_IP12, SOCKET_IP13, SOCKET_IP14, SOCKET_IP15,
                SOCKET_IP16
            });
        public static readonly IList<int> SOCKET_PORT_LIST = new ReadOnlyCollection<int>
           (new List<int>
           {
                8880,SOCKET_PORT1,SOCKET_PORT2,SOCKET_PORT3,SOCKET_PORT4,SOCKET_PORT5,SOCKET_PORT6,
                SOCKET_PORT7,SOCKET_PORT8,SOCKET_PORT9,SOCKET_PORT10,SOCKET_PORT11,
                SOCKET_PORT12,SOCKET_PORT13,SOCKET_PORT14,SOCKET_PORT15,SOCKET_PORT16
           });
        public static readonly IList<String> ITEMCONTROL_LIST = new ReadOnlyCollection<string>
           (new List<String>
           {
               "None",ITEMCONTROL1,ITEMCONTROL2,ITEMCONTROL3,ITEMCONTROL4,ITEMCONTROL5,ITEMCONTROL6,
               ITEMCONTROL7,ITEMCONTROL8,ITEMCONTROL9,ITEMCONTROL10,ITEMCONTROL11,
               ITEMCONTROL12,ITEMCONTROL13,ITEMCONTROL14,ITEMCONTROL15,ITEMCONTROL16
            });


        #endregion
        public static int GetItemId(String ItemName) {
            String IdString = ItemName[ItemName.Length].ToString();
            bool resutGetID = int.TryParse(IdString, out int id);
            if (resutGetID)
                return id;
            else
                return 0;
        }

    }
}
