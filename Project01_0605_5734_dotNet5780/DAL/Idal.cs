using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE; //check if its ligel


namespace DAL
{
     public interface IDAL
    {
        //GuestRequest
        void addGuestRequest(BE.GuestRequest guest);
        void updateGuestRequest(BE.GuestRequest guest);

        //HostingUnit
        void addHostingUnit(BE.HostingUnit hostUnit);
        void delHostingUnit(int hostUnitID);
        void updateHostingUnit(BE.HostingUnit hostUnit);

        //Order
        void addOrder(BE.Order order);
        void UpdateOrder(BE.Order order);


        //lists

        void SetGuestRequestList(List<BE.GuestRequest> GuestRequestList);
        void SetHostingUnit(List<BE.HostingUnit> HostingUnitList);
        void SetOrderList(List<BE.Order> OrderList);
        void SetBankBranchList(List<BE.BankBranch> BankBranchList);





    }
}
