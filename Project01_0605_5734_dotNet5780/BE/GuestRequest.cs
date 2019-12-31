using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
        BE.Configuration r = new BE.Configuration();

        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            set { guestRequestKey = value; }
        }


        private string privateName;
        public string PrivateName
        {
            get { return privateName; }
            set
            {
                privateName = value;
            }
        }


        private string familyName;
        public string FamilyName
        {
            get { return familyName; }
            set
            {
                familyName = value;
            }
        }



        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                mailAddress = value;
            }
        }


        private string status;// for example: "Active"
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }


        private DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set
            {
                registrationDate = value;
            }
        }


        private DateTime entryDate;
        public DateTime EntryDate
        {
            get { return entryDate; }
            set
            {
                entryDate = value;
            }
        }


        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set
            {
                releaseDate = value;
            }
        }





        private AreaEnum area;//All,North,South,Center,Jerusalem

        public AreaEnum Area
        {
            get { return area; }
            set
            {
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
                type = value;
            }

        }


        // AttractionsEnum= הכרחי/אפשרי/לא מעוניין

        private AttractionsEnum pool;
        public AttractionsEnum Pool
        {
            get { return pool; }
            set
            {
                pool = value;
            }
        }


        private AttractionsEnum jacuzzi;
        public AttractionsEnum Jacuzzi
        {
            get { return jacuzzi; }
            set
            {
                jacuzzi = value;
            }
        }


        private AttractionsEnum garden;
        public AttractionsEnum Garden
        {
            get { return garden; }
            set
            {
                garden = value;
            }
        }


        private AttractionsEnum childrensAttractions;
        public AttractionsEnum ChildrensAttractions
        {
            get { return childrensAttractions; }
            set
            {
                childrensAttractions = value;
            }
        }

        private int adults;
        public int Adults
        {
            get { return adults;  }
            set
            {
                adults = value;
            }
        }



        private int children;
        public int Children
        {
            get { return children; }
            set
            {
                children = value;
            }
        }

        public bool isEqual(GuestRequest xx)
        {
            return xx.GuestRequestKey == GuestRequestKey;
        }
        public void updateStatus(string status1)
        {
            status = status1;

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
