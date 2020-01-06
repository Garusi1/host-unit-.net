﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.Net.Mail;
namespace BE
{

    [Serializable]
    public class GuestRequest
    {
        BE.Configuration r = new BE.Configuration();

        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            set
            {
                if (value < 10000000) //from number with 8 letters 
                    throw new Exception(/*מספר זיהוי אינו תקין"*/"Incorrect key!");
                guestRequestKey = value;
            }
        }


        private string privateName;
        public string PrivateName
        {
            get { return privateName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,20}$");
                if (!r.IsMatch(value))
                    throw new Exception(/*"שם פרטי צריך להכיל 2-20 אותיות בלבד."*/"Private name need to contain 2-20 letters only ");
                privateName = value;
            }
        }


        private string familyName;
        public string FamilyName
        {
            get { return familyName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,20}$");
                if (!r.IsMatch(value))
                    throw new Exception(/*"שם משפחה צריך להכיל 2-20 אותיות בלבד."*/"Family name need to contain 2-20 letters only ");
                familyName = value;
            }
        }



        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                }
                catch (Exception)
                {
                    throw new Exception(/*"כתובת המייל לא תקינה."*/"Email address incorrect");
                }
                mailAddress = value;
            }
        }


        private StatusGREnum status;// for example: "Active"  // פתוחה, נסגרה_עסקה_דרך_האתר, נסגרה_כי_פג_תוקפה
        public StatusGREnum Status
        {
            get { return status; }
            set
            {
                if (!Enum.IsDefined(typeof(StatusGREnum), value))
                    throw new Exception("Enum input illegal");
                status = value;
            }
        }


        private DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set
            {// to define
                if (registrationDate == null)
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





        public AreaEnum area;//All,North,South,Center,Jerusalem

        public AreaEnum Area
        {
            get { return area; }
            set
            {
                if (!Enum.IsDefined(typeof(AreaEnum), value))
                    throw new Exception("Enum input illegal");
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


        // AttractionsEnum= הכרחי/אפשרי/לא מעוניין

        private AttractionsEnum pool;
        public AttractionsEnum Pool
        {
            get { return pool; }
            set
            {
                if (!Enum.IsDefined(typeof(AttractionsEnum), value))
                    throw new Exception("Enum input illegal");
                pool = value;
            }
        }


        private AttractionsEnum jacuzzi;
        public AttractionsEnum Jacuzzi
        {
            get { return jacuzzi; }
            set
            {
                if (!Enum.IsDefined(typeof(AttractionsEnum), value))
                    throw new Exception("Enum input illegal");
                jacuzzi = value;
            }
        }


        private AttractionsEnum garden;
        public AttractionsEnum Garden
        {
            get { return garden; }
            set
            {
                if (!Enum.IsDefined(typeof(AttractionsEnum), value))
                    throw new Exception("Enum input illegal");
                garden = value;
            }
        }


        private AttractionsEnum childrensAttractions;
        public AttractionsEnum ChildrensAttractions
        {
            get { return childrensAttractions; }
            set
            {
                if (!Enum.IsDefined(typeof(AttractionsEnum), value))
                    throw new Exception("Enum input illegal");
                childrensAttractions = value;
            }
        }

        private int adults;
        public int Adults
        {
            get { return adults;  }
            set
            {
                if (value < 0)
                    throw new Exception(/*מספר מבוגרים אינו יכול להיות שלילי"*/"Number of adults cannot be negative");
                if (value == 0)
                    throw new Exception(/*מספר מבוגרים אינוי יכול להיות 0"*/"Number of adults cannot be 0");
                adults = value;
            }
        }



        private int children;
        public int Children
        {
            get { return children; }
            set
            {
                if (value < 0)
                    throw new Exception(/*מספר ילדים אינו יכול להיות שלילי"*/"Number of children cannot be negative");
                children = value;
            }
        }

        public bool isEqual(BE.GuestRequest GR)
        {
            return GR.GuestRequestKey == GuestRequestKey;
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
