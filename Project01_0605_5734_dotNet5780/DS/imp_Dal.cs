using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class imp_Dal : IDAL
    {

        
        public void addGuestRequest(BE.GuestRequest guest)
        {
            if (guest.GuestRequestKey)
            {

            }

        }
        public void updateGuestRequest(BE.GuestRequest guest)
        {

        }

        //HostingUnit
        public void addHostingUnit(BE.HostingUnit hostUnit)
        {

        }
        public void delHostingUnit(int hostUnitID)
        {

        }
        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {

        }

        //Order
        public void addOrder(BE.Order order)
        {

        }
        public void UpdateOrder(BE.Order order)
        {

        }

        //lists
        public void GetGuestRequestList(List<BE.GuestRequest> GuestRequestList)
        {

        }
        public void GetHostingUnit(List<BE.HostingUnit> HostingUnitList)
        {

        }
        public void GetOrderList(List<BE.Order> OrderList)
        {

        }
        public void GetBankBranchList(List<BE.BankBranch> BankBranchList)
        {

        }






    }
}
