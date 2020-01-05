using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// add GuestRequest to DataBase
        /// </summary>
        /// <param name="guest"></param>
        void addGuestRequest(BE.GuestRequest guest);
        /// <summary>
        /// update GuestRequest on DataBase
        /// </summary>
        /// <param name="guest"></param>
        void updateGuestRequest(BE.GuestRequest guest);

        //HostingUnit

        /// add HostingUnit to DataBase
        void addHostingUnit(BE.HostingUnit hostUnit);
        /// del HostingUnit to DataBase
        void delHostingUnit(int hostUnitID);
        /// update HostingUnit on DataBase
        void updateHostingUnit(BE.HostingUnit hostUnit);

        //Order
        ///add Order to DataBase

        void addOrder(BE.Order order);
        ///update Order on DataBase
        void UpdateOrder(BE.Order order);


        //lists

        //get lists from DataBase
        List<BE.GuestRequest> GetGuestRequestList();
        List<BE.HostingUnit> GetHostingUnitList();
        List<BE.Order> GetOrderList();
        List<BE.BankBranch> GetBankBranchList();



        //תוספות

         BE.HostingUnit getHostingUnitByID(int ID);
    }
}
