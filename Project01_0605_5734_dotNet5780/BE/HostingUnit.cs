using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE
{

    [Serializable]
    public class HostingUnit
    {


        private int hostingUnitKey;
        public int HostingUnitKey
        {
            get { return hostingUnitKey; }
            set
            {
                if (value < 10000000) //from number with 8 letters 
                    throw new Exception(/*מספר זיהוי אינו תקין"*/"Incorrect key!");
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
                Regex r = new Regex("^([^20]|[0-9a-zA-Zא-ת]){2,30}$");
                if (!r.IsMatch(value))
                    throw new Exception(/*"שם יחידה צריך להכיל 2-30 אותיות."*/"HostingUnitName name need to contain 2-30 letters ");
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
