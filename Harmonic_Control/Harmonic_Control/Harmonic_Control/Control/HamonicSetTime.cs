using System;
using System.Collections.Generic;
using System.Text;

namespace Harmonic_Control
{
    class HamonicSetTime
    {
        public HamonicSetTime() { }

        public int SetTime(string itemName, string hours)
        {
            int result = 2;
            SocketClientManager socketClientManager = new SocketClientManager();
            for(int i = 1; i <= ConstDefine.ITEMCONTROL_LIST.Count; i++)
            {
                if (i == ConstDefine.ITEMCONTROL_LIST.Count)
                    result= 2;
                if (ConstDefine.ITEMCONTROL_LIST[i] == itemName)
                {
                    result= socketClientManager.SetTimeCommand(ConstDefine.SOCKET_IP_LIST[i], ConstDefine.SOCKET_PORT_LIST[i], hours, itemName);
                    return result;
                }
            }
            return result;  
        }


    }
}
