using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Configuration
    {
        private static int OrderID = 10000000;
        private static int hostUnitID = 20000000;
        private static int hostID = 30000000;
        private static int geustReqID = 40000000;

        public int getOrderId()
        {
            OrderID++;
            return OrderID;
        }

        public int getHostUnitID()
        {
            hostUnitID++;
            return hostUnitID;
        }

        public int getHostID()
        {
            hostID++;
            return hostID;
        }

        public int getGeustReqID()
        {
            geustReqID++;
            return geustReqID;
        }

    }
}
