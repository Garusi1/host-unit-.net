using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataSource
    {
        public static List<BE.GuestRequest> GuestRequestList = new List<BE.GuestRequest>()
        {new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=1, /// יש לממש בעזרת מספר רץ
        PrivateName="Michael",
        FamilyName="Garusi",
        MailAddress=/*@*/"mgarusi101@gmail.com",
        Status="Active",
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.לא_מעוניין,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.הכרחי,
        Adults=2,
        Children=0,
             }  };



        public static List<BE.HostingUnit> HostingUnitList = new List<BE.HostingUnit>()
        {new BE.HostingUnit()
        {
            HostingUnitKey=2, /// יש לממש בעזרת מספר רץ
            Owner=new Host(),// כמובן שבמימוש בפועל צריך לקשר למארח קיים שכבר מוגדר בנתונים
            HostingUnitName="Gal Banof",
            Diary,// יש לממש

        } };


        public static List<BE.Order> OrderList = new List<BE.Order>()
        {new Order()
        {
            HostingUnitKey=2,/// יש לממש בעזרת לפי הקשר
            GuestRequestKey=1,///יש לממש בהתאם לבקשה
            OrderKey=3, /// יש לממש בעזרת מספר רץ
            Status=StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,
            OrderDate=DateTime.Now.AddDays(5), //תלוי שליחת מיילץ 
        }};


        public List<BE.GuestRequest> getGuestRequestList() { return GuestRequestList; }

    }
}
