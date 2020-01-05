﻿using System;
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

        List<BE.GuestRequest> GetGuestRequestList(List<BE.GuestRequest> GuestRequestList);

        List<BE.HostingUnit> GetHostingUnit(List<BE.HostingUnit> HostingUnitList);
        List<BE.Order> GetOrderList(List<BE.Order> OrderList);
        List<BE.BankBranch> GetBankBranchList(List<BE.BankBranch> BankBranchList);





    }
}