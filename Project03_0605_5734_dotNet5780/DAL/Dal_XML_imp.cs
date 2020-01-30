using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BE;


namespace DAL
{
    class Dal_XML_imp
    {
       DataSource ds = new DataSource();

        //public void guestListToXML()
        //{
        //    List<BE.GuestRequest> GRL = ds.getGuestRequestList();
        //    string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        //    Console.WriteLine(_filePath);
        //    string s = @"\PLWPF\bin\Debug";
        //    int lenToCut = _filePath.Length - s.Length;
        //    _filePath = _filePath.Substring(0, lenToCut);
        //    Console.WriteLine(_filePath);
        //    Stream xmlPath = File.OpenWrite(_filePath + @"xml_files\guestRequestList.txt");
        //    //Stream st = File.OpenWrite(Environment.CurrentDirectory + "guestRequestList.txt");
        //    XmlSerializer xmlS = new XmlSerializer(typeof(List<BE.GuestRequest>));
        //    xmlS.Serialize(xmlPath, GRL);
        //}
        //public void OrderListToXML()
        //{
        //    List<BE.Order> OL = ds.getOrderList();
        //    Stream st = File.OpenWrite(Environment.CurrentDirectory + "orderList.txt");
        //    XmlSerializer xmlS = new XmlSerializer(typeof(List<BE.GuestRequest>));
        //    xmlS.Serialize(st, OL);
        //}
        //public void HostingUnitListToXML()
        //{
        //    List<BE.HostingUnit> HUL = ds.getHostingUnitList();
        //    Stream st = File.OpenWrite(Environment.CurrentDirectory + "guestRequestList.txt");
        //    XmlSerializer xmlS = new XmlSerializer(typeof(List<BE.GuestRequest>));
        //    xmlS.Serialize(st, HUL);
        //}

        //public void addGuestRequest(BE.GuestRequest guest)
        //{
        //    bool exists = ds.getGuestRequestList().Any(x => x.GuestRequestKey == guest.GuestRequestKey);
        //    if (exists)
        //    {
        //        throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));

        //    }
        //    if (guest.GuestRequestKey == 0)
        //    {
        //        guest.GuestRequestKey = BE.Configuration.geustReqID++;

        //    }

        //    ds.getGuestRequestList().Add(guest.Clone());

        //    //foreach (BE.GuestRequest element in ds.getGuestRequestList()) 
        //    //{
        //    //    if (element.isEqual(guest))
        //    //        throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));
        //    //}




        //}

    }
}
