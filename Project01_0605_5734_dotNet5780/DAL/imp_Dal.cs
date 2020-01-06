
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



        public void addGuestRequest(BE.GuestRequest guest)
        {
            guest.GuestRequestKey = BE.Configuration.geustReqID++;// לוודא שאכן מקדם אותו
            foreach (BE.GuestRequest element in ds.getGuestRequestList()) // צריך לבדוק שהלולאות האלה באמת עובדות
            {
                if (element.isEqual(guest))
                    throw new Exception(/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data ");
            }

            ds.getGuestRequestList().Add(guest.Clone());

        }
        public void updateGuestRequest(BE.GuestRequest guest)

        {

            if (guest.GuestRequestKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                BE.Configuration.geustReqID++; //הענק לו קוד ייחודי

            ////עדכון כללי כאן. 
            //var ls = from item in ds.getGuestRequestList()
            //         where guest.GuestRequestKey == item.GuestRequestKey
            //         select new { item = guest };

            var obj = ds.getGuestRequestList().FirstOrDefault(x => x.GuestRequestKey == guest.GuestRequestKey);
            if (obj != null) obj.Status = guest.Status;



            //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה

            addGuestRequest(guest);



        }

        //HostingUnit
        public void addHostingUnit(BE.HostingUnit hostUnit)
        {
            hostUnit.HostingUnitKey = BE.Configuration.hostUnitID++;// לוודא שאכן מקדם אותו

            foreach (BE.HostingUnit element in GetHostingUnitList())
            {
                if (element.isEqual(hostUnit))
                    throw new Exception(/* "ישנו מספר זהה של יחידת אירוח"*/"Cannot add.duplicate HostingUnit key on data ");

            }

            ds.getHostingUnitList().Add(hostUnit.Clone());
        }

        public void delHostingUnit(int hostUnitID)
        {
            foreach (BE.HostingUnit element in ds.getHostingUnitList())
            {
                if (element.isEqualID(hostUnitID))
                {
                    ds.getHostingUnitList().Remove(element);
                    return;
                }
            }

        }
        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {
            if (hostUnit.HostingUnitKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                hostUnit.HostingUnitKey = BE.Configuration.geustReqID++; //הענק לו קוד ייחודי



            //עדכון כללי כאן. 

            var obj = ds.getHostingUnitList().FirstOrDefault(x => x.HostingUnitKey == hostUnit.HostingUnitKey);
            if (obj != null) obj = hostUnit;
            if (obj == null)            //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה
            {
                throw new ArgumentNullException(string.Format("Hosting Unit  {0} not exsits in getHostingUnitList data ", hostUnit));
            }


        }

        //Order
        public void addOrder(BE.Order order)
        {
            order.HostingUnitKey = BE.Configuration.orderID++;


            foreach (var item in ds.getOrderList())
            {
                if (item.OrderKey == order.OrderKey)
                {
                    throw new ArgumentException(string.Format("the order key {0} is already exists", order.OrderKey));
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
                throw new ArgumentNullException(string.Format("Order  {0} not exsits in getOrderList data ", order));
            }



        }

        //lists
        public List<BE.GuestRequest> GetGuestRequestList()
        {
            var li = from item in ds.getGuestRequestList()
                     select item;

            return (List<BE.GuestRequest>)li.Clone();

        }
        public List<BE.HostingUnit> GetHostingUnitList()
        {

            var li = from item in ds.getHostingUnitList()
                     select item.Clone();

            return (List<BE.HostingUnit>)li;

        }
        public List<BE.Order> GetOrderList()
        {
            var li = from item in ds.getOrderList()
                     select item.Clone();

            return (List<BE.Order>)li;
        }



        public List<BE.BankBranch> GetBankBranchList()
        {


            var li = from item in ds.getBankBranchList()
                     select item.Clone();

            return (List<BE.BankBranch>)li;


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



        public BE.Order GetOrderById(int id)
        {

            var list = from item in GetOrderList()
                       where item.GuestRequestKey == id
                       select item;
            foreach (var item in list)
            {
                return item.Clone();
            }

            return null;

        }



       

    }



}
