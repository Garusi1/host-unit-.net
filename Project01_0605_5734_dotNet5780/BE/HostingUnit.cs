using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {

        private static int stSerialKey = 10000000;

        private int hostingUnitKey;
        public int HostingUnitKey
        {
            get { return hostingUnitKey; }
            set
            {
                //to define
            }
        }

        private Host owner;

        public Host Owner
        {
            get { return owner; }
            set
            {
                //to define
            }

        }

        private string hostingUnitName;

        public string HostingUnitName
        {
            get { return hostingUnitName; }
            set
            {
                //to define
            }

        }


        private bool[,] diary = new bool[31, 12];

        public bool[,] Diary
        {
            get { return diary; }
            set
            {
                //to define
            }


        }




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
