using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

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

            //לא הושלם מילוי
            if (guest.PrivateName == "" || guest.FamilyName == "" || guest.MailAddress==null || guest.EntryDate==null|| guest.ReleaseDate == null)
                throw new Exception("חובה למלא את כל השדות");
            if (!checkRequestDates(guest))// if the dates are not legal
                throw new System.ArgumentException("Dates are not legal!");

            if (guest.Adults < 0)
                throw new Exception(/*מספר מבוגרים אינו יכול להיות שלילי"*/"Number of adults cannot be negative");
            if (guest.Adults == 0)
                throw new Exception(/*מספר מבוגרים אינוי יכול להיות 0"*/"Number of adults cannot be 0");
            if(guest.Type==BE.TypeEnum.Unknown)
                throw new Exception(/*חובה לבחור סוג יחידת יחידת אירוח"*/"Select unit type of hosting unit is required");

            //AttractionsEnum // Unknown,הכרחי, אפשרי, לא_מעוניין
            if (guest.Pool == BE.AttractionsEnum.Unknown)
                throw new Exception(/*חובה לבחור האם מעוניין בבריכה"*/"Must choose whether you want a pool");
            if (guest.Jacuzzi == BE.AttractionsEnum.Unknown)
                throw new Exception(/*חובה לבחור האם מעוניין בג'קוזי"*/"Must choose whether you want a jacuzzi");
            if (guest.Garden == BE.AttractionsEnum.Unknown)
                throw new Exception(/*חובה לבחור האם מעוניין בגינה"*/"Must choose whether you want a garden");
            if ((guest.ChildrensAttractions == BE.AttractionsEnum.Unknown)&&(guest.Children>0))
                throw new Exception(/*חובה לבחור האם מעוניין באטראקציות לילדים"*/"Must choose whether you want a Childrens Attractions");




            //מילוי ערכים שגויים
            DateTime theDateToday = new DateTime();
            theDateToday = DateTime.Now;
            theDateToday = new DateTime(theDateToday.Year, theDateToday.Month, theDateToday.Day); //איפוס שעון ל00:00:00
            if (guest.EntryDate < theDateToday) 
                throw new Exception(/*תאריך כניסה אינו יכול להיות  מוקדם מעכשיו"*/"EntryDate cannot be earlier from now ");

            if (guest.ReleaseDate < theDateToday.AddDays(1))
                throw new Exception(/*תאריך יציאה אינו יכול להיות  מוקדם מעוד יום"*/"ReleaseDate cannot be earlier from tomorrow ");

            if (guest.Status!= BE.StatusGREnum.פתוחה)
                throw new Exception(/* "סטטוס דרישת לקוח שגוי.סטטוס דרישה חדשה יהיה תמיד פתוח"*/"Incorrect GuestRequest status. New GuestRequest status will always be open ");


            // after we cheek all the possible problems we can transfer the data to DAL layer

            guest.RegistrationDate = DateTime.Now;
            IDAL.addGuestRequest(guest.Clone());

            //throw new NotImplementedException();
        }


        public void addHostingUnit(BE.HostingUnit hostUnit)
        {

            //לא הושלם מילוי
            if (hostUnit.Owner == null || hostUnit.HostingUnitName == "" )
                throw new Exception("חובה למלא את כל השדות");

            // after we cheek all the possible problems we can transfer the data to DAL layer

            IDAL.addHostingUnit(hostUnit.Clone());

            // throw new NotImplementedException();
        }

        public void addOrder(BE.Order order)
        {
            // 
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
