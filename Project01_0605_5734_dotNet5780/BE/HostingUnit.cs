using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class HostingUnit
    {

        private static int stSerialKey = 10000000;
        public int HostingUnitKey { get; private set; } ///  נקבע        בבנאי ע"פ השדה הסטטי.
        public Host Owner { get; private set; }//יש לוודא מתודות
        public string HostingUnitName { get; private set; }

        public bool[,] Diary = new bool[31, 12]; //C# reset automaticly the values .




        //overrides
        //public override string ToString()  //יש לדרוס בהתאם לדרישות הפרוייקט
        ////{
        ////    string str = "Serial number of the hosting unit: " + this.HostingUnitKey + "\n";
        ////    bool flag = false;
        ////    int year = GuestRequest.year;
        ////    DateTime beginDate = new DateTime(year, 01, 01);


        ////    for (DateTime tempDate = beginDate; tempDate.Year == year; tempDate = tempDate.AddDays(1))
        ////    {
        ////        if (this[tempDate])
        ////        {
        ////            if (!flag) { beginDate = tempDate; }
        ////            flag = true;
        ////        }
        ////        else if (flag)
        ////        {
        ////            string begingDate = beginDate.ToString("dd/MM/yyyy");
        ////            string endDate = tempDate.AddDays(1).ToString("dd/MM/yyyy");
        ////            str += begingDate + " , " + endDate + "\n";

        ////            flag = false;
        ////        }
        ////    }
        ////    return str;
        //}


    }
}
