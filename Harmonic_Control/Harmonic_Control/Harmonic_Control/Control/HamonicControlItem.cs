using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Harmonic_Control;
using Xamarin.Forms;

namespace Harmonic_Control
{
    class HamonicControlItem
    {
       
        SocketClientManager socketClientManager;
        public HamonicControlItem()
        {
            socketClientManager = new SocketClientManager();
        }

        public string ItemControlName { get; set; }
        public string ButtonText { get; set; }
        public string ButtonColor { get; set; }
        public string ButtonTextColor { get; set; }
        public string ButtonSetTimeText { get; set; }

        public int GetStatusCheck() {
            return SocketClientManager.GetStatusCheck();
        }
        public int HamonicItemSetting(string itemName, int command)
        {
            int result = 2;
            for (int i = 1; i <= ConstDefine.ITEMCONTROL_LIST.Count; i++) {

                if (i == ConstDefine.ITEMCONTROL_LIST.Count)
                {
                    result= ConstDefine.HARMONIC_NOT_CONNNECT;
                }

                else if (ConstDefine.ITEMCONTROL_LIST[i] == itemName)
                {
                    result= socketClientManager.CheckHamonic_Status(ConstDefine.SOCKET_IP_LIST[i], ConstDefine.SOCKET_PORT_LIST[i], command, itemName);
                    return result;
                }
            }
            return result;
        }
        public int HamonicItemCheckStatus(string itemName, int command) {
            int result = 2;
            for (int i = 1; i <= ConstDefine.ITEMCONTROL_LIST.Count; i++)
            {

                if (i == ConstDefine.ITEMCONTROL_LIST.Count)
                {
                    result = ConstDefine.HARMONIC_NOT_CONNNECT;
                }

                else if (ConstDefine.ITEMCONTROL_LIST[i] == itemName)
                {
                    result = socketClientManager.CheckHamonic_Status(ConstDefine.SOCKET_IP_LIST[i], ConstDefine.SOCKET_PORT_LIST[i], command, itemName);
                    return result;
                }
            }
            return result;
        
        }
    }
}
