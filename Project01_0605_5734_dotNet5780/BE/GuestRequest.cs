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
            private set { } // ctor usuing this 
        }
        //ctor 
        public GuestRequest()
        {
            this.GuestRequestKey = serialKey++;
        }


        public string privateName;
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



        //All,North,South,Center,Jerusalem
        //public AreaEnum SubArea { get; private set; }

        public AreaEnum Area { get; private set; }  

        public TypeEnum type { get; private set; } //Zimmer\Hotel\Camping\ Etc;

       // AttractionsEnum= הכרחי/אפשרי/לא מעוניין
        public AttractionsEnum Pool { get; private set; }
        public AttractionsEnum Jacuzzi { get; private set; }
        public AttractionsEnum Garden { get; private set; }
        public AttractionsEnum ChildrensAttractions { get; private set; }


        public int Adults { get; private set; }
        public int Children { get; private set; }

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
