﻿using System;
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

        public AreaEnum Area { get; private set; }  //All,North,South,Center,Jerusalem
        //public AreaEnum SubArea { get; private set; }
        public TypeEnum type { get; private set; } //Zimmer\Hotel\Camping\ Etc;

       // AttractionsEnum= הכרחי/אפשרי/לא מעוניין
        public AttractionsEnum Pool { get; private set; }
        public AttractionsEnum Jacuzzi { get; private set; }
        public AttractionsEnum Garden { get; private set; }
        public AttractionsEnum ChildrensAttractions { get; private set; }


        public int Adults { get; private set; }
        public int Children { get; private set; }

    }
}
