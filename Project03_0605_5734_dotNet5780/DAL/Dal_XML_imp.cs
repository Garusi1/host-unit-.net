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

        //public static List<BE.BankBranch> bankAccunts;
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
                BE.Configuration.geustReqID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("GuestRequestKey").Value);
                BE.Configuration.hostUnitID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("HostingUnitKey").Value);
                BE.Configuration.orderID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("OrderKey").Value);
                BE.Configuration.Commission = Convert.ToInt32(BE.Tools.ConfigRoot.Element("commission").Value);
                //BE.Configuration.commissionAll = Convert.ToInt32(BE.Tools.ConfigRoot.Element("commissionAll").Value);
                //BE.Configuration.LastApdateMonthly = Convert.ToDateTime(BE.Tools.ConfigRoot.Element("LastApdateMonthly").Value);
                //BE.Configuration.LastApdateDaily = Convert.ToDateTime(BE.Tools.ConfigRoot.Element("LastApdateDaily").Value);
            }

            if (!File.Exists(BE.Tools.OrderPath))
            {
                OrderRoot = new XElement("Orders");
                OrderRoot.Save(BE.Tools.OrderPath);
            }
            if (!File.Exists(BE.Tools.GuestPath))
            {
                BE.Tools.SaveToXML(new List<BE.GuestRequest>(), BE.Tools.GuestPath);
            }
            if (!File.Exists(BE.Tools.HostingUnitPath))
            {
                BE.Tools.SaveToXML(new List<HostingUnit>(), BE.Tools.HostingUnitPath);
            }

            HostingUnitList1 = BE.Tools.LoadFromXML<List<HostingUnit>>(BE.Tools.HostingUnitPath);
            OrderRoot = XElement.Load(BE.Tools.OrderPath);
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




        public IEnumerable<BE.BankBranch> GetBankBranchList(Func<BE.BankBranch, bool> predicat = null)
        {


            var li = from item in ds.getBankBranchList()
                     where predicat == null ? true : predicat(item)
                     select item.Clone();
            //קורא רק ב foreach 



            return /*(List<BE.BankBranch>)*/li;


        }





        public void updateBankDetails()
        {
            Console.WriteLine("\n\n\n\n\n in the func1 \n\n\n\n\n\n");


            //  try
            {
                string sw = "";
                string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                Console.WriteLine(_filePath);
                string s = @"\PLWPF\bin\Debug";
                int lenToCut = _filePath.Length - s.Length;
                _filePath = _filePath.Substring(0, lenToCut);
                Console.WriteLine(_filePath);
                string Datepath = _filePath + @"\BL\bank\f.txt";

                sw = System.IO.File.ReadAllText(Datepath);
                DateTime dff = DateTime.Parse(sw);




                Console.WriteLine(sw);
                if ((DateTime.Now.Subtract(dff)).TotalDays > 1)
                {
                    Console.WriteLine("\n\n\n\n\n in the if \n\n\n\n\n\n");
                    getBankDetails();
                    Console.WriteLine("fdsfhkdsjfhdskjfhkdsjfs");
                }


                string now = DateTime.Now.ToString();
                Console.WriteLine(now);
                System.IO.File.WriteAllText(Datepath, now);
                System.IO.File.WriteAllText(Datepath, now);
            }
            // catch (Exception e)
            {

                // throw new Exception();
            }




        }

        public static void getBankDetails()
        {

            Console.WriteLine("\n\n\n\n\n in the func2 \n\n\n\n\n\n");
            //StreamWriter sw = new StreamWriter(@"‏‏C:\Users\mgaru\source\repos\Project_CSH\32\f.txt");
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(_filePath);
            string s = @"\PLWPF\bin\Debug";
            int lenToCut = _filePath.Length - s.Length;
            _filePath = _filePath.Substring(0, lenToCut);
            Console.WriteLine(_filePath);
            string xmlPath = _filePath + @"\BL\bank\atmData.xml";
            // const string xmlLocalPath = @"atmData.xml";
            WebClient wc = new WebClient();
            try
            {
                string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlPath);


            }
            catch (Exception)
            {
                string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlPath);

            }
            finally
            {
                wc.Dispose();
            }
            char[] gg = xmlPath.ToCharArray();

            Console.WriteLine(gg);


        }

        public void bankThread()
        {
            Thread th = new Thread(updateBankDetails);
            th.Start();
        }


        #endregion



    }
}



//DataSource ds = new DataSource();

// //public void guestListToXML()
// //{
// //    List<BE.GuestRequest> GRL = ds.getGuestRequestList();
// //    string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
// //    Console.WriteLine(_filePath);
// //    string s = @"\PLWPF\bin\Debug";
// //    int lenToCut = _filePath.Length - s.Length;
// //    _filePath = _filePath.Substring(0, lenToCut);
// //    Console.WriteLine(_filePath);
// //    Stream xmlPath = File.OpenWrite(_filePath + @"xml_files\guestRequestList.txt");
// //    //Stream st = File.OpenWrite(Environment.CurrentDirectory + "guestRequestList.txt");
// //    XmlSerializer xmlS = new XmlSerializer(typeof(List<BE.GuestRequest>));
// //    xmlS.Serialize(xmlPath, GRL);
// //}
// //public void OrderListToXML()
// //{
// //    List<BE.Order> OL = ds.getOrderList();
// //    Stream st = File.OpenWrite(Environment.CurrentDirectory + "orderList.txt");
// //    XmlSerializer xmlS = new XmlSerializer(typeof(List<BE.GuestRequest>));
// //    xmlS.Serialize(st, OL);
// //}
// //public void HostingUnitListToXML()
// //{
// //    List<BE.HostingUnit> HUL = ds.getHostingUnitList();
// //    Stream st = File.OpenWrite(Environment.CurrentDirectory + "guestRequestList.txt");
// //    XmlSerializer xmlS = new XmlSerializer(typeof(List<BE.GuestRequest>));
// //    xmlS.Serialize(st, HUL);
// //}

// //public void addGuestRequest(BE.GuestRequest guest)
// //{
// //    bool exists = ds.getGuestRequestList().Any(x => x.GuestRequestKey == guest.GuestRequestKey);
// //    if (exists)
// //    {
// //        throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));

// //    }
// //    if (guest.GuestRequestKey == 0)
// //    {
// //        guest.GuestRequestKey = BE.Configuration.geustReqID++;

// //    }

// //    ds.getGuestRequestList().Add(guest.Clone());

// //    //foreach (BE.GuestRequest element in ds.getGuestRequestList()) 
// //    //{
// //    //    if (element.isEqual(guest))
// //    //        throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));
// //    //}




// //}
