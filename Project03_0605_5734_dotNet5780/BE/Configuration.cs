using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        public static int orderID = 10000000;
        public static int hostUnitID = 20000000;
        public static int geustReqID = 40000000;
        public static int Commission = 10;
        public static int GetGuestRequestKey()
        {
            geustReqID++;
            Tools.SaveConfigToXml();
            return geustReqID;

        }


        
        public static int GetHostingUnitKey()
        {
            hostUnitID++;
            Tools.SaveConfigToXml();
            return hostUnitID;
        }

        public static int GetOrderKey()
        {
            orderID++;
            Tools.SaveConfigToXml();
            return orderID;

        }

    }
}
