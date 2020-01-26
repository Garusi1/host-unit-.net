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

        #region אתחול רשימות  
        //   #endregion

        public static List<BE.GuestRequest> GuestRequestList = new List<BE.GuestRequest>()
        {new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="Michael",
        FamilyName="Garusi",
        MailAddress=/*@*/"mgarusi101@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.לא_מעוניין,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.הכרחי,
        Adults=2,
        Children=0,
             },
        new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.לא_מעוניין,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.הכרחי,
        Adults=2,
        Children=1,
             },
                new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.North,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=AreaEnum.All,
        Type=TypeEnum.Zimmer,
        Pool=AttractionsEnum.אפשרי,
        Jacuzzi=AttractionsEnum.אפשרי,
        Garden=AttractionsEnum.אפשרי,
        ChildrensAttractions=AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             },

        };



        public static List<BE.HostingUnit> HostingUnitList = new List<BE.HostingUnit>()

        {
        new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, /// זה מספר רץ. יש לממש נכון
            Owner=new BE.Host(){HostKey="311600605",PrivateName="שלמה",FamilyName="הלוי",
                PhoneNumber="055-555-5355",MailAddress="a@s.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName="צימר יפה",
            Area=BE.AreaEnum.Center,
            Type=BE.TypeEnum.Zimmer
        },
        new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, /// זה מספר רץ. יש לממש נכון
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName="צימר יפה",
            Area=BE.AreaEnum.North,
            Type=BE.TypeEnum.Zimmer,
            
        }

        ,
                new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, /// זה מספר רץ. יש לממש נכון
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName=" צימר יפה מאד",
            Area=BE.AreaEnum.North,
            Type=BE.TypeEnum.Zimmer,

        }
                        ,
                new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, /// זה מספר רץ. יש לממש נכון
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName=" צימר יפה מאד",
            Area=BE.AreaEnum.North,
            Type=BE.TypeEnum.Zimmer,

        }

                        ,
                new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, /// זה מספר רץ. יש לממש נכון
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName=" צימר יפה מאד",
            Area=BE.AreaEnum.North,
            Type=BE.TypeEnum.Zimmer,

        }



        };


        public static List<BE.Order> OrderList = new List<BE.Order>()
        {new Order()
        {
            HostingUnitKey=20000000,/// יש לממש  לפי הקשר
            GuestRequestKey=40000000,///יש לממש בהתאם לבקשה
            OrderKey=BE.Configuration.orderID++, /// יש לממש בעזרת מספר רץ
            Status=StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,
            OrderDate=DateTime.Now.AddDays(5), //תלוי שליחת מיילץ 
        },
        new Order()
        {
            HostingUnitKey=20000001,/// יש לממש  לפי הקשר
            GuestRequestKey=40000000,///יש לממש בהתאם לבקשה
            OrderKey=BE.Configuration.orderID++, /// יש לממש בעזרת מספר רץ
            Status=StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,
            OrderDate=DateTime.Now.AddDays(5), //תלוי שליחת מיילץ 
        }


        };

        public static List<BE.BankBranch> BankBranchList = new List<BE.BankBranch>()
        {new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=69,
            BranchAddress="Beit Hakerem St. 29",
            BranchCity="Jerusalem"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=159,
            BranchAddress="Yaffo St. 97, Jerusalem",
            BranchCity="Jerusalem"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=64,
            BranchAddress="ehezkel St. 11, Jerusalem",
            BranchCity="Jerusalem"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=321,
            BranchAddress="Sderot Rabin 10, Jerusalem",
            BranchCity="Jerusalem"
        },


        };

        #endregion

        //clone to the BL
        public List<BE.GuestRequest> getGuestRequestList() { return GuestRequestList/*.Clone()*/; }

        public List<BE.HostingUnit> getHostingUnitList() { return HostingUnitList/*.Clone()*/; }
        public List<BE.Order> getOrderList() { return OrderList/*.Clone()*/; }

        public List<BE.BankBranch> getBankBranchList() { return BankBranchList/*.Clone()*/; }



    }
}
