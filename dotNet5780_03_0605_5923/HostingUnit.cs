using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_03_0605_5923
{
    public class HostingUnit
    {
        public string UnitName { get; set; }
        public int Rooms { get; set; }
        public bool IsSwimmimgPool { get; set; }

        public List<DateTime> AllOrders
        {
            get; set;
        }

    public List<string> Uris { get; set; }




    }
}
