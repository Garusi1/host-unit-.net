using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {


        private int hostingUnitKey;
        public int HostingUnitKey
        {
            get { return hostingUnitKey; }
            set
            {
                hostingUnitKey = value;
            }
        }

        private Host owner;

        public Host Owner
        {
            get { return owner; }
            set
            {
                owner = value; //דורש בדיקה!
            }

        }

        private string hostingUnitName;

        public string HostingUnitName
        {
            get { return hostingUnitName; }
            set
            {
                hostingUnitName = value;
            }

        }


        private bool[,] diary = new bool[31, 12];

        public bool[,] Diary
        {
            get { return diary; }
            set
            {
                diary = value;
            }


        }

        public bool isEqual(HostingUnit host1)
        {
            return host1.HostingUnitKey == HostingUnitKey;
        }

        public bool isEqualID(int ID)
        {
            return ID == HostingUnitKey;
        }


        //overrides
        public override string ToString()  //יש לדרוס בהתאם לדרישות הפרוייקט
        {
            string str = "";
            str += "Hosting Unit Key: " + HostingUnitKey + "\n" +
                  "Hosting Unit Name: " + HostingUnitName + "\n"+
            "Owner details: \n" + Owner + "\n";

            return str;
        }

        


    }
}
