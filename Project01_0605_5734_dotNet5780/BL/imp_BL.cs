using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class imp_BL : IBL
    {

        DAL.IDAL IDAL;

        internal imp_BL()
        {
            IDAL = DAL.Factory.GetInstance();
        }
        
        
        public void addGuestRequest(BE.GuestRequest guest)
        {
            if (guest.PrivateName == "" || guest.FamilyName == "" ||(guest.EntryDate==null)|| (guest.ReleaseDate == null))
                throw new Exception("חובה למלא את כל השדות");
            if (!checkRequestDates(guest))// if the dates are not legal
                throw new System.ArgumentException("Dates are not legal!");


            DateTime theDateToday = new DateTime();
            theDateToday = DateTime.Now;
            theDateToday = new DateTime(theDateToday.Year, theDateToday.Month, theDateToday.Day); //איפוס שעון ל00:00:00
            if (guest.EntryDate < theDateToday) 
                throw new Exception(/*תאריך אינו יכול להיות  מוקדם מעכשיו"*/"EntryDate cannot be earlier from now ");

            if (guest.ReleaseDate < theDateToday.AddDays(1))
                throw new Exception(/*תאריך אינו יכול להיות  מוקדם מעוד יום"*/"ReleaseDate cannot be earlier from tomorrow ");
            




            // after we cheek all the possible problems we can transfer the data to DAL layer



            //throw new NotImplementedException();
        }

        public void addHostingUnit(BE.HostingUnit hostUnit)
        {
            throw new NotImplementedException();
        }

        public void addOrder(BE.Order order)
        {
            
            throw new NotImplementedException();
        }

        public void delHostingUnit(int hostUnitID)
        {
            throw new NotImplementedException();
        }

        public List<BE.BankBranch> GetBankBranchList(List<BE.BankBranch> BankBranchList)
        {
            throw new NotImplementedException();
        }

        public List<BE.GuestRequest> GetGuestRequestList(List<BE.GuestRequest> GuestRequestList)
        {
            throw new NotImplementedException();
        }


        public List<BE.HostingUnit> GetHostingUnit(List<BE.HostingUnit> HostingUnitList)
        {
            throw new NotImplementedException();
        }

        public List<BE.Order> GetOrderList(List<BE.Order> OrderList)
        {
            throw new NotImplementedException();
        }

        public void updateGuestRequest(BE.GuestRequest guest)
        {


            throw new NotImplementedException();
        }

        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(BE.Order order)
        {
            throw new NotImplementedException();
        }
    
        
        public bool checkRequestDates (BE.GuestRequest guest)
        {
            if(guest.EntryDate<= guest.ReleaseDate) // check if the dates are not equal and if the relase date are not bigger then EntryDate
                return false;
            return true;

        }








    }








}
