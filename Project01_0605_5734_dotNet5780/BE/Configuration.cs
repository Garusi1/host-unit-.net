using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Configuration
    {
        private static int OrderID = 10000000;
        private static int hostUnitID = 20000000;
        private static int hostID = 30000000;
        private static int geustReqID = 40000000;

        public static int getOrderId()
        {
            OrderID++;
            return OrderID;
        }

        public static int getHostUnitID()
        {
            hostUnitID++;
            return hostUnitID;
        }

        public static int getHostID()
        {
            hostID++;
            return hostID;
        }

        public static int getGeustReqID()
        {
            geustReqID++;
            return geustReqID;
        }

    }
}
