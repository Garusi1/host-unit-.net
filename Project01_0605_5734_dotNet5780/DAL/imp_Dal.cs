
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

        public static List<BE.GuestRequest> GuestRequestList1 = new List<BE.GuestRequest>();

        public static List<BE.HostingUnit> HostingUnitList1 = new List<BE.HostingUnit>();

        public static List<BE.Order> OrderList1 = new List<BE.Order>();


                
        public void addGuestRequest(BE.GuestRequest guest)
        {
            guest.GuestRequestKey = BE.Configuration.geustReqID++;// לוודא שאכן מקדם אותו
            foreach (BE.GuestRequest element in ds.getGuestRequestList()) // צריך לבדוק שהלולאות האלה באמת עובדות
            {
                if (element.isEqual(guest))
                    throw new Exception(/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data ");
            }

            GuestRequestList1.Add(guest.Clone());
        }
        public void updateGuestRequest(BE.GuestRequest guest)

        {
            if (guest.GuestRequestKey==0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                BE.Configuration.geustReqID++; //הענק לו קוד ייחודי
            foreach (BE.GuestRequest element in GuestRequestList1)
            {
                if (element.isEqual(guest))
                    element.updateStatus(guest);
            }
        }

        //HostingUnit
        public void addHostingUnit(BE.HostingUnit hostUnit)
        {
            hostUnit.HostingUnitKey = BE.Configuration.hostUnitID++;// לוודא שאכן מקדם אותו

            foreach (BE.HostingUnit element in HostingUnitList1)
            {
                if (element.isEqual(hostUnit))
                    throw new Exception(/* "ישנו מספר זהה של יחידת אירוח"*/"Cannot add.duplicate HostingUnit key on data ");

            }

            HostingUnitList1.Add(hostUnit.Clone());
        }
        public void delHostingUnit(int hostUnitID)
        {
            foreach (BE.HostingUnit element in HostingUnitList1)
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
            if (hostUnit.HostingUnitKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                hostUnit.HostingUnitKey = BE.Configuration.geustReqID++; //הענק לו קוד ייחודי
            foreach (BE.HostingUnit element in HostingUnitList1)
            {
                ///
            }
        }

        //Order
        public void addOrder(BE.Order order)
        {

        }
        public void UpdateOrder(BE.Order order)
        {

        }

        //lists
        public List<BE.GuestRequest> GetGuestRequestList()
        {
            var li = from item in ds.getGuestRequestList()
                     select item; 
            
            return (List<BE.GuestRequest>)li.Clone() ;

        }
        public List<BE.HostingUnit> GetHostingUnit()
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
