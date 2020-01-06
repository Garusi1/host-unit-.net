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
            HostingUnitKey=BE.Configuration.hostUnitID++, /// זה מספר רץ. יש לממש נכון
            Owner=new Host(),// כמובן שבמימוש בפועל צריך לקשר למארח קיים שכבר מוגדר בנתונים
            HostingUnitName="Gal Banof",
            //Diary,// יש לממש

        } };


        public static List<BE.Order> OrderList = new List<BE.Order>()
        {new Order()
        {
            HostingUnitKey=2,/// יש לממש  לפי הקשר
            GuestRequestKey=1,///יש לממש בהתאם לבקשה
            OrderKey=BE.Configuration.orderID++, /// יש לממש בעזרת מספר רץ
            Status=StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,
            OrderDate=DateTime.Now.AddDays(5), //תלוי שליחת מיילץ 
        }};

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
