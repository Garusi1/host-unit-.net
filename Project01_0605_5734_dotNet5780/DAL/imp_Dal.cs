﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DS;

namespace DAL
{
    public class imp_Dal : IDAL
    {
        DataSource ds = new DataSource();

        public static List<BE.GuestRequest> GuestRequestList1 = new List<GuestRequest>();

        public static List<BE.HostingUnit> HostingUnitList1 = new List<HostingUnit>();

        public static List<BE.Order> OrderList1 = new List<Order>();


                
        public void addGuestRequest(BE.GuestRequest guest)
        {

            foreach(GuestRequest element in GuestRequestList1) // צריך לבדוק שהלולאות האלה באמת עובדות
            {
                if (element.isEqual(guest)) return; //צריך להקפיץ פה איזה הודעה על זה שהוא כבר קיים
            }

           GuestRequestList1.Add(guest);

        }
        public void updateGuestRequest(BE.GuestRequest guest)

        {
            foreach (GuestRequest element in GuestRequestList1)
            {
                if (element.isEqual(guest))
                    element.updateStatus(guest.Status);
            }
        }

        //HostingUnit
        public void addHostingUnit(BE.HostingUnit hostUnit)
        {
            foreach (HostingUnit element in HostingUnitList1)
            {
                if (element.isEqual(hostUnit)) return; //צריך להקפיץ פה איזה הודעה על זה שהוא כבר קיים
            }

            HostingUnitList1.Add(hostUnit);
        }
        public void delHostingUnit(int hostUnitID)
        {
            foreach (HostingUnit element in HostingUnitList1)
            {
                if (element.isEqualID(hostUnitID))
                {
                    HostingUnitList1.Remove(element);
                    return;
                }
            }

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
        public List<BE.GuestRequest> GetGuestRequestList(List<BE.GuestRequest> GuestRequestList)
        {
            return ds.getGuestRequestList();
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
