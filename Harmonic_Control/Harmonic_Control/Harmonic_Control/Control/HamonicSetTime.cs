using System;
using System.Collections.Generic;
using System.Text;

namespace Harmonic_Control
{
    class HamonicSetTime
    {
        public HamonicSetTime() { }

        public int SetTime(string itemName, double hours)
        {
            SocketClientManager socketClientManager = new SocketClientManager();

            if (itemName == HamonicControlItem.ITEMCONTROL1)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP1, HamonicControlItem.SOCKET_PORT1, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL2)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP2, HamonicControlItem.SOCKET_PORT2, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL3)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP3, HamonicControlItem.SOCKET_PORT3, hours, itemName);

            }
            else if (itemName == HamonicControlItem.ITEMCONTROL4)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP4, HamonicControlItem.SOCKET_PORT4, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL5)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP5, HamonicControlItem.SOCKET_PORT5, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL6)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP6, HamonicControlItem.SOCKET_PORT6, hours, itemName);

            }
            else if (itemName == HamonicControlItem.ITEMCONTROL7)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP7, HamonicControlItem.SOCKET_PORT7, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL8)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP8, HamonicControlItem.SOCKET_PORT8, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL9)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP9, HamonicControlItem.SOCKET_PORT9, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL10)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP10, HamonicControlItem.SOCKET_PORT10, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL11)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP11, HamonicControlItem.SOCKET_PORT11, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL12)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP12, HamonicControlItem.SOCKET_PORT12, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL13)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP13, HamonicControlItem.SOCKET_PORT13, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL14)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP14, HamonicControlItem.SOCKET_PORT14, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL15)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP15, HamonicControlItem.SOCKET_PORT15, hours, itemName);
            }
            else if (itemName == HamonicControlItem.ITEMCONTROL16)
            {
                return socketClientManager.SetTimeCommand(HamonicControlItem.SOCKET_IP16, HamonicControlItem.SOCKET_PORT16, hours, itemName);
            }
            else
                return 0;
        }


    }
}
