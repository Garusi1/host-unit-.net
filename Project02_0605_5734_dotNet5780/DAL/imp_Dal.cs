
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DS;
using BE;

namespace DAL
{
    public class imp_Dal : IDAL
    {
        DataSource ds = new DataSource();

        //public static List<BE.GuestRequest> GuestRequestList1 = new List<BE.GuestRequest>();

        //public static List<BE.HostingUnit> HostingUnitList1 = new List<BE.HostingUnit>();

        //public static List<BE.Order> OrderList1 = new List<BE.Order>();

        #region GuestRequest
        //#endregion

        public void addGuestRequest(BE.GuestRequest guest)
        {
            guest.GuestRequestKey = BE.Configuration.geustReqID++;
            foreach (BE.GuestRequest element in ds.getGuestRequestList()) // צריך לבדוק שהלולאות האלה באמת עובדות
            {
                if (element.isEqual(guest))
                    throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));
            }

            ds.getGuestRequestList().Add(guest.Clone());

        }
        public void updateGuestRequest(BE.GuestRequest guest)

        {
            //לשאול מרצה מה הכוונה כאן בתנאי ההוספה הזה. 
            if (guest.GuestRequestKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                BE.Configuration.geustReqID++; //הענק לו קוד ייחודי

            ////עדכון כללי כאן. 
            //var ls = from item in ds.getGuestRequestList()
            //         where guest.GuestRequestKey == item.GuestRequestKey
            //         select new { item = guest };

            var obj = ds.getGuestRequestList().FirstOrDefault(x => x.GuestRequestKey == guest.GuestRequestKey);
            if (obj != null) obj.Status = guest.Status;
            else if (obj == null)
            {
                throw new KeyNotFoundException(string.Format("מספר דרישת לקוח:  {0} לא נמצא בבסיס הנתונים ", guest.GuestRequestKey));
            }


            //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה
            // addGuestRequest(guest);

        }




        public BE.GuestRequest getGuestRequestByID(int ID)
        {

            var list = from item in GetGuestRequestList()
                       where item.GuestRequestKey == ID
                       select item.Clone();

            return list.FirstOrDefault();

            //foreach (var item in list)
            //{
            //    return item.Clone();
            //}

            //return null;

        }


        #endregion


        #region HostingUnit


        //HostingUnit
        public int addHostingUnit(BE.HostingUnit hostUnit)
        {
            hostUnit.HostingUnitKey = BE.Configuration.hostUnitID++;

            foreach (BE.HostingUnit element in GetHostingUnitList())
            {
                if (element.isEqual(hostUnit))
                    throw new DuplicateWaitObjectException(/* "ישנו מספר זהה של יחידת אירוח"*/"Cannot add.duplicate HostingUnit key on data ");

            }

            ds.getHostingUnitList().Add(hostUnit.Clone());

            return hostUnit.HostingUnitKey;
        }

        public void delHostingUnit(int hostUnitID)
        {
            bool found = false;

            foreach (BE.HostingUnit element in ds.getHostingUnitList())
            {
                if (element.isEqualID(hostUnitID))
                {
                    ds.getHostingUnitList().Remove(element);
                    found = true;
                    return;
                }
            }


            if (!found)
            {

                throw new KeyNotFoundException(string.Format("מחיקה נכשלה! לא נמצאה יחידת אירוח {0}", hostUnitID));
            }




        }
        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {
            if (hostUnit.HostingUnitKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                hostUnit.HostingUnitKey = BE.Configuration.geustReqID++; //הענק לו קוד ייחודי



            //עדכון כללי כאן. 

            var obj = ds.getHostingUnitList().FirstOrDefault(x => x.HostingUnitKey == hostUnit.HostingUnitKey);
            if (obj != null) obj = hostUnit;
            else if (obj == null)            //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה
            {
                throw new KeyNotFoundException(string.Format("Hosting Unit  {0} not exsits in getHostingUnitList data ", hostUnit));
            }

            //מחיקת קודם ונעדכן חדש... 
            var itemToRemove = ds.getHostingUnitList().SingleOrDefault(r => r.HostingUnitKey == hostUnit.HostingUnitKey);
            if (itemToRemove != null)
            {
                ds.getHostingUnitList().Remove(itemToRemove); //מחיקת הערך
                ds.getHostingUnitList().Add(hostUnit.Clone()); // עדכון חדש

            }
        }



        public BE.HostingUnit getHostingUnitByID(int ID)
        {

            var list = from item in GetHostingUnitList()
                       where item.HostingUnitKey == ID
                       select item.Clone();
            return list.FirstOrDefault();

            //foreach (var item in list)
            //{
            //    return item.Clone();
            //}

            //return null;

        }


        #endregion


        #region Order


        //Order
        public void addOrder(BE.Order order)
        {
            if (order.OrderKey == 0)
            { order.OrderKey = BE.Configuration.orderID++; }


            foreach (var item in ds.getOrderList())
            {
                if (item.OrderKey == order.OrderKey)
                {
                    throw new DuplicateWaitObjectException(string.Format("the order key {0} is already exists", order.OrderKey));
                }

            }
            ds.getOrderList().Add(order.Clone());


        }


        public void UpdateOrder(BE.Order order)//עדכון סטטוס הזמנה 
        {

            if (order.OrderKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                order.OrderKey = BE.Configuration.orderID++; //הענק לו קוד ייחודי

            //עדכון כללי כאן. 

            var obj = ds.getOrderList().FirstOrDefault(x => x.OrderKey == order.OrderKey);
            if (obj != null) obj.Status = order.Status;
            if (obj == null)            //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה
            {
                throw new KeyNotFoundException(string.Format("Order  {0} not exsits in getOrderList data ", order));

            }

        }





        public BE.Order GetOrderById(int id)
        {

            var list = from item in GetOrderList()
                       where item.GuestRequestKey == id
                       select item.Clone();
            return list.FirstOrDefault();
            //foreach (var item in list)
            //{
            //    return item.Clone();
            //}

            //return null;

        }


        #endregion


        //lists


        #region Lists



        public IEnumerable<BE.GuestRequest> GetGuestRequestList()
        {
            var li = from item in ds.getGuestRequestList()
                     select item.Clone();


            List<BE.GuestRequest> list = new List<BE.GuestRequest>();

            foreach (var item in li)
            {
                list.Add(item);
            }


            return list;

        }
        public IEnumerable<BE.HostingUnit> GetHostingUnitList()
        {

            var li = from item in ds.getHostingUnitList()
                     select item.Clone();

            List<BE.HostingUnit> list = new List<BE.HostingUnit>();

            foreach (var item in li)
            {
                list.Add(item);
            }

            return list;

        }
        public IEnumerable<BE.Order> GetOrderList()
        {
            var li = from item in ds.getOrderList()
                     select item.Clone();

            // IEnumerable<BE.Order> list = new IEnumerable<BE.Order>();
            List<BE.Order> list = new List<BE.Order>();
            foreach (var item in li)
            {
                list.Add(item);
            }
            return list;

        }


        /// <summary>
        /// list l 
        /// </summary>
        /// <returns></returns>
        /// 
        //IEnumerable<BE.BankBranch>



        public IEnumerable<BE.BankBranch> GetBankBranchList()
        {


            var li = from item in ds.getBankBranchList()
                     select item.Clone();
            //קורא רק ב foreach 



            return (List<BE.BankBranch>)li;


        }


        #endregion




        // מתשאל דרישת לקוח לפי תנאי 

        public IEnumerable<BE.GuestRequest> getAllGRwithCondition(Func<BE.GuestRequest, bool> predicat = null)
        {
            return from gst in GetGuestRequestList()
                   where predicat == null ? true : predicat(gst)
                   select gst.Clone();


        }







    }







}
