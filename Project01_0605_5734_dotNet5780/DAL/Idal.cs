using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE; //check if its ligel


namespace DAL
{
     public interface Idal
    {
        //GuestRequest
        bool addGuestRequest();
        bool updateGuestRequest();

        //HostingUnit
        bool addHostingUnit();
        bool delHostingUnit();
        bool updateHostingUnit();

        //Order
        bool addOrder();
        bool UpdateOrder();

        //lists
        bool sss(List<GuestRequest> ggg);
        bool sss(List<HostingUnit> ggg);
        bool sss(List<Order> ggg);

    }
}
