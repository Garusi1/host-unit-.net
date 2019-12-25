using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_0605_5923
{
    class GuestRequest
    {
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public DateTime LastNight; //this is the ReleaseDate - 2 days- for work with the matrix

        public bool IsApproved; // if the req approved
        public static int year = DateTime.Today.Year; // to refuse the functions to work with this year.

        //override
        public override string ToString()  //יש לדרוס את מתודת ToString – כך שתציג עבור הבקשה את כל מאפייניה. 
        {
            string str = "Entry date: " + EntryDate.Date.ToString() + "\n";
            str+= "Release date: " + ReleaseDate.Date.ToString();
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
