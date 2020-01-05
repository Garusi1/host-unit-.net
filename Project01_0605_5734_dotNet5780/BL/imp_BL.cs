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

            //אם לא הושלם מילוי
            if (guest.PrivateName == "" || guest.FamilyName == "" || guest.MailAddress == null || guest.EntryDate == null || guest.ReleaseDate == null)
                throw new Exception("חובה למלא את כל השדות");
            if (!checkRequestDates(guest))// if the dates are not legal
                throw new System.ArgumentException("Dates are not legal!");

            ///throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));


            if (guest.Adults < 0)
                throw new System.ArgumentException(/*מספר מבוגרים אינו יכול להיות שלילי"*/"Number of adults cannot be negative");
            if (guest.Adults == 0)
                throw new System.ArgumentException(/*מספר מבוגרים אינוי יכול להיות 0"*/"Number of adults cannot be 0");
            if (guest.Type == BE.TypeEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור סוג יחידת יחידת אירוח"*/"Select unit type of hosting unit is required");

            //AttractionsEnum // Unknown,הכרחי, אפשרי, לא_מעוניין
            if (guest.Pool == BE.AttractionsEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין בבריכה"*/"Must choose whether you want a pool");
            if (guest.Jacuzzi == BE.AttractionsEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין בג'קוזי"*/"Must choose whether you want a jacuzzi");
            if (guest.Garden == BE.AttractionsEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין בגינה"*/"Must choose whether you want a garden");
            if ((guest.ChildrensAttractions == BE.AttractionsEnum.Unknown) && (guest.Children > 0))
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין באטראקציות לילדים"*/"Must choose whether you want a Childrens Attractions");

            if (checkDateLegallOneYear(guest.EntryDate)) //אם התאריכים חורגים מהטווח של חודש אחורה ו11 חודש קדימה
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", guest.EntryDate));

            }
            if (checkDateLegallOneYear(guest.ReleaseDate))
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", guest.ReleaseDate));
            }
            


            //מילוי ערכים שגויים
            DateTime theDateToday = new DateTime();
            theDateToday = DateTime.Now;
            theDateToday = new DateTime(theDateToday.Year, theDateToday.Month, theDateToday.Day); //איפוס שעון ל00:00:00
            if (guest.EntryDate < theDateToday)
                throw new System.ArgumentException(/*תאריך כניסה אינו יכול להיות  מוקדם מעכשיו"*/"EntryDate cannot be earlier from now ");

            if (guest.ReleaseDate < theDateToday.AddDays(1))
                throw new System.ArgumentException(/*תאריך יציאה אינו יכול להיות  מוקדם מעוד יום"*/"ReleaseDate cannot be earlier from tomorrow ");

            if (guest.Status != BE.StatusGREnum.פתוחה)
                throw new System.ArgumentException(/* "סטטוס דרישת לקוח שגוי.סטטוס דרישה חדשה יהיה תמיד פתוח"*/"Incorrect GuestRequest status. New GuestRequest status will always be open ");


            // after we cheek all the possible problems we can transfer the data to DAL layer

            guest.RegistrationDate = DateTime.Now;
            IDAL.addGuestRequest(guest.Clone());

            //throw new NotImplementedException();
        }


        public void addHostingUnit(BE.HostingUnit hostUnit)
        {

            //אם לא הושלם מילוי
            if (hostUnit.Owner == null || hostUnit.HostingUnitName == "")
                throw new Exception("חובה למלא את כל השדות");
            if (!Enum.IsDefined(typeof(AreaEnum), hostUnit.Area))
                throw new System.ArgumentException("Enum input illegal");
            if (hostUnit.Area == AreaEnum.All)
                throw new System.ArgumentException("Enum input illegal. HostingUnit cannot be in All regions");





            // after we cheek all the possible problems we can transfer the data to DAL layer

            IDAL.addHostingUnit(hostUnit.Clone());

            // throw new NotImplementedException();
        }

        public void addOrder(BE.Order order)
        {
            BE.GuestRequest GR = getGuestRequestByID(order.GuestRequestKey);
            BE.HostingUnit HU = getHostingUnitByID(order.HostingUnitKey); // בהנחה שזה קיים אחרת לא נשלחה בקשה לפונקציה זו

            if (GR == null)
            {
                throw new System.ArgumentNullException(string.Format("worng input {0} not exsits ", order.GuestRequestKey));

            }

            if (!(GR.Status==BE.StatusGREnum.פתוחה))
            {
                throw new System.Diagnostics.Eventing.Reader.EventLogInvalidDataException(string.Format("This Guest request {0} are close ", order.GuestRequestKey));

            }

            if (GR.Type!=HU.Type)
            {
                throw new System.ArgumentNullException(string.Format("the Guest request and the Hosting Unit are not fit in Type parmater  "));
            }
            if ((!(GR.Area == BE.AreaEnum.All)) && (!(GR.Area == HU.Area)) )
            {
                throw new System.ArgumentNullException(string.Format("the Guest request and the Hosting Unit are not fit in Area parmater  "));
            }


            //לבדוק לוגית
            if ((!((HU.Pool) && (GR.Pool == BE.AttractionsEnum.הכרחי)) ||   !(((HU.Pool)) && (GR.Pool == BE.AttractionsEnum.לא_מעוניין))))
            {

            }


            // &&
            //////                            (((HU.Jacuzzi) && (GS.Jacuzzi == BE.AttractionsEnum.הכרחי)) || (GS.Jacuzzi == BE.AttractionsEnum.אפשרי) || ((!(HU.Jacuzzi)) && (GS.Jacuzzi == BE.AttractionsEnum.לא_מעוניין))) &&
            //////                            (((HU.Garden) && (GS.Garden == BE.AttractionsEnum.הכרחי)) || (GS.Garden == BE.AttractionsEnum.אפשרי) || ((!(HU.Garden)) && (GS.Garden == BE.AttractionsEnum.לא_מעוניין))) &&
            //////                            (((HU.ChildrensAttractions) && (GS.ChildrensAttractions == BE.AttractionsEnum.הכרחי)) || (GS.ChildrensAttractions == BE.AttractionsEnum.אפשרי) || ((!(HU.ChildrensAttractions)) && (GS.ChildrensAttractions == BE.AttractionsEnum.לא_מעוניין))) &&



            throw new NotImplementedException();
        }

        public void delHostingUnit(int hostUnitID)
        {
            throw new NotImplementedException();
        }




        public List<BE.BankBranch> GetBankBranchList()
        {
            //throw new NotImplementedException();
            return IDAL.GetBankBranchList().Clone();
        }

        public List<BE.GuestRequest> GetGuestRequestList()
        {
            //throw new NotImplementedException();
            return IDAL.GetGuestRequestList().Clone();

        }


        public List<BE.HostingUnit> GetHostingUnitList()
        {
            //throw new NotImplementedException();
            return IDAL.GetHostingUnitList().Clone();
        }

        public List<BE.Order> GetOrderList()
        {
            //throw new NotImplementedException();
            return IDAL.GetOrderList().Clone();
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


        public bool checkRequestDates(BE.GuestRequest guest)
        {
            if (guest.EntryDate <= guest.ReleaseDate) // check if the dates are not equal and if the relase date are not bigger then EntryDate
                return false;
            return true;

        }










        public bool checkDateLegallOneYear(DateTime generalDate)
        {
            DateTime lastMonth = DateTime.Now.Date.AddMonths(-1);
            if (generalDate < lastMonth)
            {
                throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));

            }
            lastMonth = DateTime.Now.Date.AddMonths(11);

            if (generalDate > lastMonth)
            {
                throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));

            }
            
            return true;
        }


        public BE.HostingUnit getHostingUnitByID(int ID)
        {

            var list = from item in GetHostingUnitList()
                       where item.HostingUnitKey == ID
                       select item;
            foreach (var item in list)
            {
                return item.Clone();
            }

            return null;

        }


        public BE.GuestRequest getGuestRequestByID(int ID)
        {

            var list = from item in GetGuestRequestList()
                       where item.GuestRequestKey == ID
                       select item;
            foreach (var item in list)
            {
                return item.Clone();
            }

            return null;

        }





        public static bool Add<T>(List<T> list, T t) where T : IComparable
        {

            foreach (T item in list)
            {
                if (t.CompareTo(item) == 0)
                {
                    return false;
                }
            }
            list.Add(t);
            return true;

        }




        public static void Remove<T>(List<T> list, T t) where T : IComparable
        {
            T temp = default(T);
            foreach (T item in list)
            {
                if (t.CompareTo(item) == 0)
                {
                    temp = item;
                    break;
                }
            }

            if (temp != null)
                list.Remove(temp);
        }




        public static T Find<T>(List<T> list, T t) where T : class, IComparable
        {

            foreach (T item in list)
            {
                if (t.CompareTo(item) == 0)
                {
                    return item;
                }

            }
            return null;
        }




    }








}



///////*
////// * 
////// * 
////// *            // ייצוג הזמנות רלוונטיות בלבד 
///

//            //BE.HostingUnit unit = DAL.getUnitByKey(order.HostingUnitKey);

// BE.GuestRequest unitK = DAL.getUnitByKey(order.HostingUnitKey);

//ליצור השוואת שדות. אם זה לא מתאים לזרוק אקספשיין


// new Order()/*{GS.GuestRequestKey,HU.HostingUnitKey };*/{ GuestRequestKey = GS.GuestRequestKey, HostingUnitKey = HU.HostingUnitKey, Status = BE.StatusEnum.טרם_טופל, CreateDate = DateTime.Now };


//////            var fit = from GS in GetGuestRequestList()
//////                      from HU in GetHostingUnit()
//////                      where (GS.Status == BE.StatusGREnum.פתוחה) &&
//////                            (GS.Type == HU.Type) &&
//////                            ((GS.Area == BE.AreaEnum.All) || (GS.Area == HU.Area)) &&

//////                            /* ביחידת אירוח או שיש אטרקאציה או שאין. אם יש, אז אם בדירשת אירוח היא הכרחית יש התאמה.
//////                            אם האטראקציה לא הכרחית אז לא משנה אם יש או אין.
//////                            אם האורח לא מעוניין, אז נתאים רק אם אין את הארטאקציה.*/
//////(((HU.Pool) && (GS.Pool == BE.AttractionsEnum.הכרחי)) || (GS.Pool == BE.AttractionsEnum.אפשרי) || ((!(HU.Pool)) && (GS.Pool == BE.AttractionsEnum.לא_מעוניין))) &&
//////                            (((HU.Jacuzzi) && (GS.Jacuzzi == BE.AttractionsEnum.הכרחי)) || (GS.Jacuzzi == BE.AttractionsEnum.אפשרי) || ((!(HU.Jacuzzi)) && (GS.Jacuzzi == BE.AttractionsEnum.לא_מעוניין))) &&
//////                            (((HU.Garden) && (GS.Garden == BE.AttractionsEnum.הכרחי)) || (GS.Garden == BE.AttractionsEnum.אפשרי) || ((!(HU.Garden)) && (GS.Garden == BE.AttractionsEnum.לא_מעוניין))) &&
//////                            (((HU.ChildrensAttractions) && (GS.ChildrensAttractions == BE.AttractionsEnum.הכרחי)) || (GS.ChildrensAttractions == BE.AttractionsEnum.אפשרי) || ((!(HU.ChildrensAttractions)) && (GS.ChildrensAttractions == BE.AttractionsEnum.לא_מעוניין))) &&

//////                            ///יש לממש לפי תאריך - אם פנוי 
//////                            ///יש לממש 
//////                            ///
//////                            ///לבדוק לוגיקה
//////                      select new Order()/*{GS.GuestRequestKey,HU.HostingUnitKey };*/{ GuestRequestKey = GS.GuestRequestKey, HostingUnitKey = HU.HostingUnitKey, Status = BE.StatusEnum.טרם_טופל, CreateDate = DateTime.Now };

////// */