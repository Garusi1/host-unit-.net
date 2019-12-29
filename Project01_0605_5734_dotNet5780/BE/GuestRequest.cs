using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {

        private static int serialKey = 10000000;
        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            set 
            {
                //to define
            } 
        }


        private string privateName;
        public string PrivateName
        {
            get { return privateName; }
            set
            {
                //to define
            }
        }


        private string familyName;
        public string FamilyName
        {
            get { return familyName; }
            set
            {
                //to define
            }
        }



        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                //to define
            }
        }


        private string status;// for example: "Active"
        public string Status
        {
            get { return status; }
            set
            {
                //to define
            }
        }


        private DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set
            {
                //to define
            }
        }


        private DateTime entryDate;
        public DateTime EntryDate
        {
            get { return entryDate; }
            set
            {
                //to define
            }
        }


        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set
            {
                //to define
            }
        }





        private AreaEnum area;//All,North,South,Center,Jerusalem

        public AreaEnum Area
        {
            get { return area; }
            set
            {
                //to define
            }

        }

        //public AreaEnum SubArea { get; private set; } .... // להגדיר באופן נכון כמו את האחרים


        private TypeEnum type;  //Zimmer\Hotel\Camping\ Etc;
        public TypeEnum Type
        {
            get { return type; }
            set
            {
                //to define
            }

        }


        // AttractionsEnum= הכרחי/אפשרי/לא מעוניין

        private AttractionsEnum pool;
        public AttractionsEnum Pool
        {
            get { return pool; }
            set
            {
                //to define
            }
        }


        private AttractionsEnum jacuzzi;
        public AttractionsEnum Jacuzzi
        {
            get { return jacuzzi; }
            set
            {
                //to define
            }
        }


        private AttractionsEnum garden;
        public AttractionsEnum Garden
        {
            get { return garden; }
            set
            {
                //to define
            }
        }


        private AttractionsEnum childrensAttractions;
        public AttractionsEnum ChildrensAttractions
        {
            get { return childrensAttractions; }
            set
            {
                //to define
            }
        }

        private int adults;
        public int Adults
        {
            get { return adults;  }
            set
            {
                //to define
            }
        }



        private int children;
        public int Children
        {
            get { return children; }
            set
            {
                //to define
            }
        }


        public override string ToString()  // יש לממש בהתאם לדרישות הפרוייקט.
        {
            string str = "";
            str += "Geust name: " + PrivateName + " " + FamilyName + "\n" +
                "MailAddress: " + MailAddress + "\n" +
                "Status: " + Status + "\n" +
                "Registration Date: " + RegistrationDate.ToString() + "\n" +
                "Entry date: " + EntryDate.Date.ToString() + "\n" +
                "Release date: " + ReleaseDate.Date.ToString() + "\n"
                + "Area: " + Area + "\n" +
                "type: " + type + "\n" +
                "Adults: " + Adults + "\n" +
                "Children" + Children + "\n" +
                "Pool: " + Pool + "\n" +
                "Jacuzzi: " + Jacuzzi + "\n" +
                "Garden: " + Garden + "\n" +
                "Childrens Attractions: " + ChildrensAttractions + "\n";
            return str;
        }
    }
}
