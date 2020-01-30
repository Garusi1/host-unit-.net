using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;


namespace DAL
{
    class Dal_XML_imp :IDAL
    {

        //////XElement OrderRoot;
        XElement bankAccuntsRoot;



        public static List<BE.GuestRequest> GuestRequestList1;

        public static List<BE.HostingUnit> HostingUnitList1;

        public static List<BE.BankBranch> bankAccuntsList;
        public static List<BE.Order> OrderList;

        internal Dal_XML_imp()
        {
            //DownloadBankXml();




            /// config file
            if (!File.Exists(BE.Tools.configPath))
            {
                BE.Tools.SaveConfigToXml();
            }
            else
            { 


                BE.Tools.ConfigRoot = XElement.Load(BE.Tools.configPath);
                BE.Configuration.geustReqID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("geustReqID").Value);
                BE.Configuration.hostUnitID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("hostUnitID").Value);
                BE.Configuration.orderID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("orderID").Value);
                Configuration.Commission = Convert.ToInt32(BE.Tools.ConfigRoot.Element("Commission").Value);
                //BE.Configuration.commissionAll = Convert.ToInt32(BE.Tools.ConfigRoot.Element("commissionAll").Value);
                //BE.Configuration.LastApdateMonthly = Convert.ToDateTime(BE.Tools.ConfigRoot.Element("LastApdateMonthly").Value);
                //BE.Configuration.LastApdateDaily = Convert.ToDateTime(BE.Tools.ConfigRoot.Element("LastApdateDaily").Value);

            }

            if (!File.Exists(BE.Tools.OrderPath))
            {
                BE.Tools.SaveToXML(new List<BE.Order>(), BE.Tools.OrderPath);

            }
            if (!File.Exists(BE.Tools.GuestPath))
            {
                BE.Tools.SaveToXML(new List<BE.GuestRequest>(), BE.Tools.GuestPath);
            }
            if (!File.Exists(BE.Tools.HostingUnitPath))
            {
                BE.Tools.SaveToXML(new List<BE.HostingUnit>(), BE.Tools.HostingUnitPath);
            }

            HostingUnitList1 = BE.Tools.LoadFromXML<List<HostingUnit>>(BE.Tools.HostingUnitPath);

            OrderList = BE.Tools.LoadFromXML<List<Order>>(BE.Tools.OrderPath);
            GuestRequestList1 = BE.Tools.LoadFromXML<List<GuestRequest>>(BE.Tools.GuestPath);


        }








        #region GuestRequest
        //#endregion

        public void addGuestRequest(BE.GuestRequest guest)
        {
            bool exists = GuestRequestList1.Any(x => x.GuestRequestKey == guest.GuestRequestKey);
            if (exists)
            {
                throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));

            }
            if (guest.GuestRequestKey == 0)
            {
                guest.GuestRequestKey = BE.Configuration.GetGuestRequestKey();

            }

            GuestRequestList1.Add(guest.Clone());
            BE.Tools.SaveToXML<List<BE.GuestRequest>>(GuestRequestList1, BE.Tools.GuestPath);


        }

        public void updateGuestRequest(BE.GuestRequest guest)

        {

            if (guest.GuestRequestKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל- דרישות דף פרוייקט.
                guest.GuestRequestKey = BE.Configuration.GetGuestRequestKey(); //הענק לו קוד ייחודי

            //אם זה קיים הוא מוחק ישן ושם חדש. אם לא קיים, פשוט יוסיף אותו. 
            GuestRequestList1.RemoveAll(x => x.GuestRequestKey == guest.GuestRequestKey);
            addGuestRequest(guest);

            //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה


        }


        public BE.GuestRequest getGuestRequestByID(int ID)
        {

            var list = from item in GetGuestRequestList()
                       where item.GuestRequestKey == ID
                       select item.Clone();

            return list.FirstOrDefault();

        }


        #endregion




        #region HostingUnit


        //HostingUnit







        public int addHostingUnit(BE.HostingUnit hostUnit)
        {
            if (hostUnit.HostingUnitKey == 0)
            {
                hostUnit.HostingUnitKey = BE.Configuration.GetHostingUnitKey();
            }


            if (HostingUnitList1.Any(x => x.HostingUnitKey == hostUnit.HostingUnitKey))
            {
                throw new DuplicateWaitObjectException(/* "ישנו מספר זהה של יחידת אירוח"*/"Cannot add.duplicate HostingUnit key on data ");
            }

            HostingUnitList1.Add(hostUnit.Clone());
            BE.Tools.SaveToXML<List<BE.HostingUnit>>(HostingUnitList1, BE.Tools.HostingUnitPath);
            
            return hostUnit.HostingUnitKey;




        }




        public void delHostingUnit(int hostUnitID)
        {

            int count = HostingUnitList1.RemoveAll(x => x.HostingUnitKey == hostUnitID);
            if (count == 0)
                throw new KeyNotFoundException(string.Format("מחיקה נכשלה! לא נמצאה יחידת אירוח {0}", hostUnitID));
            BE.Tools.SaveToXML<List<HostingUnit>>(HostingUnitList1, BE.Tools.HostingUnitPath);

        }



        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {

            if (hostUnit.HostingUnitKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                hostUnit.HostingUnitKey =BE.Configuration.GetHostingUnitKey(); //הענק לו קוד ייחודי


            HostingUnitList1.RemoveAll(x => x.HostingUnitKey == hostUnit.HostingUnitKey);
            addHostingUnit(hostUnit.Clone());

            //BE.Tools.SaveToXML<List<HostingUnit>>(HostingUnitList1, BE.Tools.HostingUnitPath);


        }


        public BE.HostingUnit getHostingUnitByID(int ID)
        {

            var list = from item in HostingUnitList1
                       where item.HostingUnitKey == ID
                       select item.Clone();
            return list.FirstOrDefault();


        }


        #endregion


        #region Order









        public void addOrder(BE.Order order)
        {

            if (order.OrderKey == 0)
            { order.OrderKey = BE.Configuration.GetOrderKey(); }


            bool exists = OrderList.Any(x => x.OrderKey == order.OrderKey);
            if (exists)
            {
                throw new DuplicateWaitObjectException(("שגיאה. לא ניתן להוסיף הזמנה. ישנו מספר הזמנה זהה בבבסיס הנתונים."));

            }


            if (order.CreateDate == default)
            {
                order.CreateDate = DateTime.Now;
            }


            OrderList.Add(order.Clone());
            BE.Tools.SaveToXML<List<BE.Order>>(OrderList, BE.Tools.OrderPath);

        }


        public void UpdateOrder(BE.Order order)//עדכון סטטוס הזמנה 
        {


            if (order.OrderKey == 0)
            { order.OrderKey = BE.Configuration.GetOrderKey(); }


            //אם זה קיים הוא מוחק ישן ושם חדש. אם לא קיים, פשוט יוסיף אותו. 
            OrderList.RemoveAll(x => x.OrderKey == order.OrderKey);


            if ((order.OrderDate == default) && (order.Status == BE.StatusEnum.נשלח_מייל))
            {
                order.OrderDate = DateTime.Now; //עדכון זמן שליחת מייל
            }

            addOrder(order);


        }





        public BE.Order GetOrderById(int id)
        {

            var list = from item in OrderList
                       where item.OrderKey == id
                       select item.Clone();
            return list.FirstOrDefault();

        }


        #endregion


        //lists


        #region Lists



        public IEnumerable<BE.GuestRequest> GetGuestRequestList(Func<BE.GuestRequest, bool> predicat = null)
        {

            var li = from item in GuestRequestList1
                     where predicat == null ? true : predicat(item)
                     select item.Clone();

            return li;

        }
        public IEnumerable<BE.HostingUnit> GetHostingUnitList(Func<BE.HostingUnit, bool> predicat = null)
        {

            var li = from item in HostingUnitList1
                     where predicat == null ? true : predicat(item)
                     select item.Clone();

            return li;

        }
        public IEnumerable<BE.Order> GetOrderList(Func<BE.Order, bool> predicat = null)
        {

            var li = from order in OrderList
                     where predicat == null ? true : predicat(order)
                     select order.Clone();
            return li;

        }







        public IEnumerable<BE.BankBranch> GetBankBranchList()
        {


            

            string BankAccuntPath_temp = BE.Tools.BankAccuntPath;
            if (!File.Exists(BE.Tools.BankAccuntPath) || BE.Configuration.BanksXmlFinish == false)
            {
                BankAccuntPath_temp = "atm1.xml";
            }
            else
            {
                long length = new FileInfo(BE.Tools.BankAccuntPath).Length;
                if (length < 10000)
                    BankAccuntPath_temp = "atm1.xml";
            }
            try
            {
                bankAccuntsRoot = XElement.Load(BankAccuntPath_temp);

            }
            catch { }

            bankAccuntsList = BE.Tools.XmlToBankAccunt(bankAccuntsRoot);


            var IenumBank = from BankAccunt in bankAccuntsList
                            select BankAccunt.Clone();
            return IenumBank;





        }







        #endregion



    }
}



