using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class GuestRequest
    {

        private static int serialKey = 10000000;
        public int GuestRequestKey { get; private set; }
        //ctor 
        public GuestRequest()
        {
            this.GuestRequestKey = serialKey++;
        }
        public string PrivateName { get; private set; }
        public string FamilyName { get; private set; }
        public string MailAddress { get; private set; }
        public string Status { get; private set; }// for example: "Active"

        public DateTime RegistrationDate { get; private set; }
        public DateTime EntryDate;
        public DateTime ReleaseDate;

        //  נעשה enum לכל אחד מהבאים
        Area // All\North\South\Center\Jerusalem 

        SubArea // Tel Aviv
        type //Zimmer\Hotel\Camping\ Etc;
        
        Pool //הכרחי/אפשרי/לא מעוניין
        Jacuzzi//הכרחי/אפשרי/לא מעוניין
        Garden//הכרחי/אפשרי/לא מעוניין
        ChildrensAttractions;//הכרחי/אפשרי/לא מעוניין

        public int Adults { get; private set; }
        public int Children { get; private set; }



        ////public DateTime LastNight; //this is the ReleaseDate - 2 days- for work with the matrix

        ////public bool IsApproved; // if the req approved
        ////public static int year = DateTime.Today.Year; // to refuse the functions to work with this year.

        //override
        public override string ToString()  // יש לממש בהתאם לדרישות הפרוייקט.
        {
            string str = "Entry date: " + EntryDate.Date.ToString() + "\n";
            str += "Release date: " + ReleaseDate.Date.ToString();
            if (IsApproved)
            {
                str += "\n The request has approved";
            }
            else
            {
                str += "\n The request has rejected";
            }

            return str;
        }
    }
}
