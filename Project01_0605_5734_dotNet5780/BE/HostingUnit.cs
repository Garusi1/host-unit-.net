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
            //להשלים לפי שדות שהוספנו
            return str;
        }




        private AreaEnum area;//All,North,South,Center,Jerusalem

        public AreaEnum Area
        {
            get { return area; }
            set
            {
                if (!Enum.IsDefined(typeof(AreaEnum), value))
                    throw new Exception("Enum input illegal");
                if (value== AreaEnum.All)
                    throw new Exception("Enum input illegal. HostingUnit cannot be in All regions");

                area = value;
            }

        }



        //public AreaEnum SubArea { get; private set; } .... // להגדיר באופן נכון כמו את האחרים


        private TypeEnum type;  //Zimmer\Hotel\Camping\ Etc;
        public TypeEnum Type
        {
            get { return type; }
            set
            {
                if (!Enum.IsDefined(typeof(TypeEnum), value))
                    throw new Exception("Enum input illegal");
                type = value;
            }

        }



        private bool pool;
        public bool Pool
        {
            get { return pool; }
            set
            {

                pool = value;
            }
        }


        private bool jacuzzi;
        public bool Jacuzzi
        {
            get { return jacuzzi; }
            set
            {

                jacuzzi = value;
            }
        }


        private bool garden;
        public bool Garden
        {
            get { return garden; }
            set
            {
                garden = value;
            }
        }


        private bool childrensAttractions;
        public bool ChildrensAttractions
        {
            get { return childrensAttractions; }
            set
            {

                childrensAttractions = value;
            }
        }




    }
}
