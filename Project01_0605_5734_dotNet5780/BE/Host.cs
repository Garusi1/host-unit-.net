﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        private int hostKey;
        public int HostKey
        {
            get { return hostKey; }
            set
            {
                hostKey = value;
            }
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


        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
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

        private BankBranch bankBranchDetails;
        public BankBranch BankBranchDetails
        {
            get { return bankBranchDetails; }
            set
            {
                bankBranchDetails = value;
            }
        }



        private int bankAccountNumber;
        public int BankAccountNumber
        {
            get { return bankAccountNumber; }
            set
            {
                bankAccountNumber = value;
            }
        }

        private bool collectionClearance;
        public string CollectionClearance //Yes/No //אישור גביה מחשבון הבנק
        {
            get
            {
                if (collectionClearance) return "Yes"; 
                else return "No";
            }
            set
            {
                if (value.Equals("yes")|| value.Equals("Yes")) collectionClearance = true;
                else collectionClearance = false;
            }

        }




        public override string ToString()  //יש לממש בהתאם לדרישות הפרוייקט
        {


            string str1 = "";
            str1 += "Host Key: " + HostKey + "\n" +
                "Name: " + PrivateName + " " + FamilyName + "\n" +
                "Phone Number: " + PhoneNumber + "\n" +
                "Mail Address: " + MailAddress + "\n" +
                "Bank Branch Details: " + BankBranchDetails + "\n" +
                "Bank Account Number: " + BankAccountNumber + "\n" +
                "Collection Clearance: " + CollectionClearance + "\n";         

            return str1;
        }

    }

}

