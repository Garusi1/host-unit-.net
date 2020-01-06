﻿using System;
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


        #region GuestRequest methods
        //   #endregion
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
        public BE.GuestRequest getGuestRequestByID(int ID)
        {

            return IDAL.getGuestRequestByID(ID).Clone();

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


        public void updateGuestRequest(BE.GuestRequest guest) //בהנחה שמעדכנים אך ורק סטטוס הזמנה
        {
            BE.GuestRequest oldGuest = getGuestRequestByID(guest.GuestRequestKey);
            if (oldGuest == null)
            {
                throw new System.ArgumentException(string.Format("The GuestRequest with {0} key now exists", guest.GuestRequestKey));
            }



            // כל זה במידה ונרצה לעדכן הכל... אבל לא ממש רלוונטי לתוכנה
            /// בהנחה שבממשק משתמש קיבלנו את מספר ההזמנה והראנו שקיים ולאחר מכן בוצע עדכון שדות 
            /// 
            ////            //אם לא הושלם מילוי
            ////if (guest.PrivateName == "" || guest.FamilyName == "" || guest.MailAddress == null || guest.EntryDate == null || guest.ReleaseDate == null)
            ////    throw new Exception("חובה למלא את כל השדות");
            ////if (!checkRequestDates(guest))// if the dates are not legal
            ////    throw new System.ArgumentException("Dates are not legal!");

            ///////throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));


            ////if (guest.Adults < 0)
            ////    throw new System.ArgumentException(/*מספר מבוגרים אינו יכול להיות שלילי"*/"Number of adults cannot be negative");
            ////if (guest.Adults == 0)
            ////    throw new System.ArgumentException(/*מספר מבוגרים אינוי יכול להיות 0"*/"Number of adults cannot be 0");
            ////if (guest.Type == BE.TypeEnum.Unknown)
            ////    throw new System.ArgumentException(/*חובה לבחור סוג יחידת יחידת אירוח"*/"Select unit type of hosting unit is required");

            //////AttractionsEnum // Unknown,הכרחי, אפשרי, לא_מעוניין
            ////if (guest.Pool == BE.AttractionsEnum.Unknown)
            ////    throw new System.ArgumentException(/*חובה לבחור האם מעוניין בבריכה"*/"Must choose whether you want a pool");
            ////if (guest.Jacuzzi == BE.AttractionsEnum.Unknown)
            ////    throw new System.ArgumentException(/*חובה לבחור האם מעוניין בג'קוזי"*/"Must choose whether you want a jacuzzi");
            ////if (guest.Garden == BE.AttractionsEnum.Unknown)
            ////    throw new System.ArgumentException(/*חובה לבחור האם מעוניין בגינה"*/"Must choose whether you want a garden");
            ////if ((guest.ChildrensAttractions == BE.AttractionsEnum.Unknown) && (guest.Children > 0))
            ////    throw new System.ArgumentException(/*חובה לבחור האם מעוניין באטראקציות לילדים"*/"Must choose whether you want a Childrens Attractions");

            ////if (checkDateLegallOneYear(guest.EntryDate)) //אם התאריכים חורגים מהטווח של חודש אחורה ו11 חודש קדימה
            ////{
            ////    throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", guest.EntryDate));

            ////}
            ////if (checkDateLegallOneYear(guest.ReleaseDate))
            ////{
            ////    throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", guest.ReleaseDate));
            ////}



            //////מילוי ערכים שגויים
            ////DateTime theDateToday = new DateTime();
            ////theDateToday = DateTime.Now;
            ////theDateToday = new DateTime(theDateToday.Year, theDateToday.Month, theDateToday.Day); //איפוס שעון ל00:00:00
            ////if (guest.EntryDate < theDateToday)
            ////    throw new System.ArgumentException(/*תאריך כניסה אינו יכול להיות  מוקדם מעכשיו"*/"EntryDate cannot be earlier from now ");

            ////if (guest.ReleaseDate < theDateToday.AddDays(1))
            ////    throw new System.ArgumentException(/*תאריך יציאה אינו יכול להיות  מוקדם מעוד יום"*/"ReleaseDate cannot be earlier from tomorrow ");

            if (!(oldGuest.Status == BE.StatusGREnum.פתוחה))
            {
                throw new Exception(string.Format("לא ניתן לשנות דרישת לקוח שאינה פתוחה"));
            }


            IDAL.updateGuestRequest(guest.Clone());

        }


        #endregion




        #region HostingUnit methods
        //   #endregion
        public void addHostingUnit(BE.HostingUnit hostUnit)
        {

            //אם לא הושלם מילוי
            if (/*hostUnit.Owner == null ||*/ hostUnit.HostingUnitName == "" ||
                hostUnit.Owner.PrivateName == "" || hostUnit.Owner.FamilyName == "" ||
                hostUnit.Owner.PhoneNumber == "" || hostUnit.Owner.MailAddress == null ||
                hostUnit.Owner.BankBranchDetails == null || hostUnit.Owner.BankAccountNumber == 0)

                throw new Exception("חובה למלא את כל השדות");
            if (!BE.Tools.ValidateID(hostUnit.Owner.HostKey))
                throw new Exception("תעודת זהות של מארח לא תקינה.");
            if (!Enum.IsDefined(typeof(BE.AreaEnum), hostUnit.Area))
                throw new System.ArgumentException("Enum input illegal");
            if (hostUnit.Area == BE.AreaEnum.All)
                throw new System.ArgumentException("Enum input illegal. HostingUnit cannot be in All regions");


            // after we cheek all the possible problems we can transfer the data to DAL layer

            IDAL.addHostingUnit(hostUnit.Clone());

            // throw new NotImplementedException();
        }



        public void delHostingUnit(int hostUnitID)
        {
            if (getHostingUnitByID(hostUnitID) == null)
            {
                throw new Exception(string.Format("Hosting Unit with {0} key is not exists ", hostUnitID));
            }

            // check if there is "open" order connect to this Hosting Unit
            //תנאים למחיקה
            var ls = from item in GetOrderList()
                     where ((item.HostingUnitKey == hostUnitID) && ((item.Status == BE.StatusEnum.טרם_טופל) || (item.Status == BE.StatusEnum.נשלח_מייל)))
                     select hostUnitID;
            foreach (var item in ls)
            {
                throw new Exception(string.Format("this Hosting {0} has open order (order key : {1}) ", hostUnitID, item));

            }


            IDAL.delHostingUnit(hostUnitID);

            throw new NotImplementedException();
        }

        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {
            BE.HostingUnit beforeChangeHostUnit = getHostingUnitByID(hostUnit.HostingUnitKey);
            //אם לא הושלם מילוי
            if (/*hostUnit.Owner == null ||*/ hostUnit.HostingUnitName == "" ||
                hostUnit.Owner.PrivateName == "" || hostUnit.Owner.FamilyName == "" ||
                hostUnit.Owner.PhoneNumber == "" || hostUnit.Owner.MailAddress == null ||
                hostUnit.Owner.BankBranchDetails == null || hostUnit.Owner.BankAccountNumber == 0)

                throw new Exception("חובה למלא את כל השדות");
            if (!BE.Tools.ValidateID(hostUnit.Owner.HostKey))
                throw new Exception("תעודת זהות של מארח לא תקינה.");
            if (!Enum.IsDefined(typeof(BE.AreaEnum), hostUnit.Area))
                throw new System.ArgumentException("Enum input illegal");
            if (hostUnit.Area == BE.AreaEnum.All)
                throw new System.ArgumentException("Enum input illegal. HostingUnit cannot be in All regions");

            if (beforeChangeHostUnit.Owner.CollectionClearance.Equals("Yes") && (hostUnit.Owner.CollectionClearance.Equals("No")))//אם רוצה לשנות הרשאת חשבון בנק
            {
                var checkOrder = from item in GetOrderList()
                                 where (item.HostingUnitKey == hostUnit.HostingUnitKey) &&
                                 ((item.Status == BE.StatusEnum.טרם_טופל) ||
                                 (item.Status == BE.StatusEnum.נשלח_מייל))
                                 select item;
                foreach (var item in checkOrder)
                {
                    throw new System.ArgumentException("לא ניתן ל");


                }


            }

            // after we cheek all the possible problems we can transfer the data to DAL layer

            IDAL.updateHostingUnit(hostUnit.Clone());

            //throw new NotImplementedException();
        }



        public BE.HostingUnit getHostingUnitByID(int ID)
        {
            return IDAL.getHostingUnitByID(ID).Clone();
        }

        public BE.Order getOrderByID(int ID)
        {
            return IDAL.GetOrderById(ID).Clone();
        }





        public bool this[DateTime generalDate, BE.HostingUnit HU] // define indexer 
        {
            private set => HU.Diary[generalDate.Day - 1, generalDate.Month - 1] = value;
            get => HU.Diary[generalDate.Day - 1, generalDate.Month - 1];
        }

        public bool ApproveRequest(BE.GuestRequest guestReq, BE.HostingUnit HU) //check if the dates are available on matrix.   // if not, return false.
        {
            DateTime LastNight = guestReq.RegistrationDate.AddDays(-2);

            for (DateTime tempDate = guestReq.EntryDate; tempDate <= LastNight; tempDate = tempDate.AddDays(1))
                if (this[tempDate, HU]) { return false; }// check if the days are avaiable

            return true;
        }


        #endregion


        public void addOrder(BE.Order order)
        {
            BE.GuestRequest GR = getGuestRequestByID(order.GuestRequestKey);
            BE.HostingUnit HU = getHostingUnitByID(order.HostingUnitKey); // בהנחה שזה קיים אחרת לא נשלחה בקשה לפונקציה זו

            if (GR == null)
            {
                throw new System.ArgumentNullException(string.Format("worng input {0} not exsits ", order.GuestRequestKey));

            }

            if (!(GR.Status == BE.StatusGREnum.פתוחה))
            {
                throw new System.Diagnostics.Eventing.Reader.EventLogInvalidDataException(string.Format("This Guest request {0} are close ", order.GuestRequestKey));

            }

            if (GR.Type != HU.Type)
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in Type parmater  "));
            }
            if ((!(GR.Area == BE.AreaEnum.All)) && (!(GR.Area == HU.Area)))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in Area parmater  "));
            }


            if ((!(HU.Pool) && (GR.Pool == BE.AttractionsEnum.הכרחי)) || (((HU.Pool) && (GR.Pool == BE.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the Pool parmater  "));
            }

            if ((!(HU.Jacuzzi) && (GR.Jacuzzi == BE.AttractionsEnum.הכרחי)) || (((HU.Jacuzzi) && (GR.Jacuzzi == BE.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the Jacuzzi parmater  "));
            }
            if ((!(HU.Garden) && (GR.Garden == BE.AttractionsEnum.הכרחי)) || (((HU.Garden) && (GR.Garden == BE.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the Garden parmater  "));
            }
            if ((!(HU.ChildrensAttractions) && (GR.ChildrensAttractions == BE.AttractionsEnum.הכרחי)) || (((HU.ChildrensAttractions) && (GR.ChildrensAttractions == BE.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the ChildrensAttractions parmater  "));
            }

            //ליתר חרום
            if (checkDateLegallOneYear(GR.EntryDate)) //אם התאריכים חורגים מהטווח של חודש אחורה ו11 חודש קדימה
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", GR.EntryDate));

            }
            if (checkDateLegallOneYear(GR.ReleaseDate))
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", GR.ReleaseDate));
            }



            if (!ApproveRequest(GR, HU))  //check if the dates are available on matrix.   // if not, return false.
            {
                throw new Exception(string.Format("The dates on Hosting unit are not available"));
            }

            // if the dates are available on matrix update the Hosint Unit



            IDAL.addOrder(order.Clone());


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




        public void UpdateOrder(BE.Order order)
        {

            BE.GuestRequest GR = getGuestRequestByID(order.GuestRequestKey);
            BE.HostingUnit HU = getHostingUnitByID(order.HostingUnitKey); // בהנחה שזה קיים אחרת לא נשלחה בקשה לפונקציה זו
            BE.Order orderBeforeChange = getOrderByID(order.OrderKey);

            if (!(ApproveRequest(GR, HU))) //check if the dates are available on matrix.   // if not, return false.)
            {
                throw new Exception(string.Format("The dates on Hosting unit are not available"));
            }


            if ((HU.Owner.CollectionClearance == "No") && (order.Status == BE.StatusEnum.נשלח_מייל))
                throw new Exception(string.Format("בעל יחידת דיור אינו מורשה לשלוח מייל כל עוד לא חתם על הרשאה לחיוב חשבון בנק"));


            if (orderBeforeChange.Status == BE.StatusEnum.נסגר_בהיענות_הלקוח || orderBeforeChange.Status == BE.StatusEnum.נסגר_מחוסר_הענות_הלקוח)
            {
                throw new Exception(string.Format("לא ניתן לשנות סטטוס הזמנה שנסגרה"));

            }

            if ((HU.Owner.CollectionClearance == "No") && (order.Status == BE.StatusEnum.נסגר_בהיענות_הלקוח))
                throw new Exception(string.Format("בעל יחידת דיור אינו מורשה לסגור עסקה כל עוד לא חתם על הרשאה לחיוב חשבון בנק"));


            if (GR.Status == BE.StatusGREnum.נסגרה_כי_פג_תוקפה || GR.Status == BE.StatusGREnum.נסגרה_עסקה_דרך_האתר)
            {
                throw new Exception(string.Format("דרישת הלקוח נסגרה"));

            }

            if ((HU.Owner.CollectionClearance == "Yes") && (order.Status == BE.StatusEnum.נשלח_מייל))
            {
                sendMail(order); //שליחת מייל עם פרטי הזמנה
                order.OrderDate = DateTime.Now;

            }

            if ((HU.Owner.CollectionClearance == "Yes") && (order.Status == BE.StatusEnum.נסגר_בהיענות_הלקוח))
            {
                int Chargeamount = 0;
                //תפיסת היחידה
                DateTime LastNight = GR.RegistrationDate.AddDays(-2);
                for (DateTime tempDate = GR.EntryDate; tempDate <= LastNight; tempDate = tempDate.AddDays(1))
                {
                    this[tempDate, HU] = true;//put the nights on matrix
                    Chargeamount += BE.Configuration.Commission; //חישוב עמלה על כיום שנתפס
                }

                bankAccountDebit(HU, Chargeamount);
                GR.Status = StatusGREnum.נסגרה_עסקה_דרך_האתר;
                updateGuestRequest(GR);




                var fit = from orderShow in GetOrderList()
                          where (GR.GuestRequestKey == orderShow.GuestRequestKey) && (order.OrderKey != orderShow.OrderKey)//לוקח את כל הרשימה מלבד אותו מופע של הזמנה
                          select /*{GS.GuestRequestKey,HU.HostingUnitKey };*/orderShow.Status == BE.StatusEnum.נסגר_מחוסר_הענות_הלקוח;

                foreach (var item in GetOrderList())
                {
                    IDAL.UpdateOrder(item.Clone());
                }
            }
            IDAL.UpdateOrder(order.Clone());





            throw new NotImplementedException();
        }







        public void bankAccountDebit(BE.HostingUnit HU, int Chargeamount)
        {

            //לוקח חשבון ומחייב אותו איכשהו...
        }



        public void sendMail(BE.Order order) //לממש שליחת מייל עם פרטי הזמנה בשלב הבא
        {
            Console.WriteLine("the mail as been sent");
        }






        //תופסות בBL

        public List<BE.HostingUnit> availableUnits(DateTime enteryDate,int numOfDayes)//פונקציה שמקבלת תאריך ומספר ימי נופש ומחזירה את רשימת היחידות הפנויות בתאריך זה
        {


            var list = from item in GetHostingUnitList()
                       where (checkAvailability(enteryDate, numOfDayes,item))
                     select item;

            List<BE.HostingUnit> newList=new List<HostingUnit>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            
            return newList;
        }


        bool checkAvailability(DateTime enteryDate, int numOfDayes,BE.HostingUnit HU) //check if the dates are available on matrix.   // if not, return false.
        {
            DateTime LastNight = enteryDate.AddDays(numOfDayes - 2);
            for (DateTime tempDate = enteryDate; tempDate <= LastNight; tempDate = tempDate.AddDays(1))
                if (this[tempDate, HU]) { return false; }// check if the days are avaiable

            return true;
        }


        public int numberOfDayes(params DateTime [] arr) //מספר הימים שעברו שטווח תאריכים מסוים או מתאריך מסוים ועד היום.
        {
            int number = 0;
            int indexer = 0;

            DateTime start=new DateTime();
            DateTime end =  DateTime.Now;

            var List = from item in arr
                       where ((indexer == 0) || (indexer == 1))
                       select (indexer == 0 ? start = item)

            foreach (var item in arr)
            {
                if (indexer==0)
                {

                }
            }



            return number;
        }

        public List<BE.Order> ordersDayesPast(int numOfDays)
        {
            //פונקציה שמקבלת מספר ימים ומחזירה רשימה של הזמנות שמשך הזמן שעבר מאז שנוצרו ועד היום גדול או שווה למספר שהתקבל

            List<BE.Order> ls = new List<BE.Order>();
                
            DateTime date = DateTime.Now.Date;//היום - באפוס שניות
            TimeSpan timeSpan;

            var list = from item in GetOrderList()
                       where (((int.Parse((timeSpan = date - item.CreateDate.Date).ToString())) >= numOfDays))||
                             (((int.Parse((timeSpan = date - item.OrderDate.Date).ToString())) >= numOfDays))
                       select item;
            foreach (var item in list)
            {
                ls.Add(item);
            }

            return ls;
        }




        //public static bool Add<T>(List<T> list, T t) where T : IComparable
        //{

        //    foreach (T item in list)
        //    {
        //        if (t.CompareTo(item) == 0)
        //        {
        //            return false;
        //        }
        //    }
        //    list.Add(t);
        //    return true;

        //}




        //public static void Remove<T>(List<T> list, T t) where T : IComparable
        //{
        //    T temp = default(T);
        //    foreach (T item in list)
        //    {
        //        if (t.CompareTo(item) == 0)
        //        {
        //            temp = item;
        //            break;
        //        }
        //    }

        //    if (temp != null)
        //        list.Remove(temp);
        //}




        //public static T Find<T>(List<T> list, T t) where T : class, IComparable
        //{

        //    foreach (T item in list)
        //    {
        //        if (t.CompareTo(item) == 0)
        //        {
        //            return item;
        //        }

        //    }
        //    return null;
        //}




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