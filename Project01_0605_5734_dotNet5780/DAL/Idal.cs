﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE; 


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

        List<BE.GuestRequest> GetGuestRequestList();

        List<BE.HostingUnit> GetHostingUnitList();
        List<BE.Order> GetOrderList();
        List<BE.BankBranch> GetBankBranchList();


        //תוספות


        BE.HostingUnit getHostingUnitByID(int ID);


        BE.GuestRequest getGuestRequestByID(int ID);


        BE.Order GetOrderById(int id);



        IEnumerable<BE.GuestRequest> getAllGRwithCondition(Func<BE.GuestRequest, bool> predicat = null);




    }
}
