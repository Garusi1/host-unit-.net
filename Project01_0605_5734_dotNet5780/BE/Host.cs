using System;
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


        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                //to define
                // יש להוסיף בדיקה שאין תוים  לא חוקיים
                /// הם בטעות רשמו FhoneNumber
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

        private BankBranch bankBranchDetails;
        public BankBranch BankBranchDetails
        {
            get { return bankBranchDetails; }
            set
            {
                //to define
                // יש לבדוק איך מתודות אלו פועלות
            }
        }



        private int bankAccountNumber;
        public int BankAccountNumber
        {
            get { return bankAccountNumber; }
            set
            {
                //to define
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
                //to define
            }

        }




        ////public override string ToString()  //יש לממש בהתאם לדרישות הפרוייקט
        ////{
        ////    string str1 = $"Host Key : {this.HostKey} \n";
        ////    foreach (var item in HostingUnitCollection)
        ////    {
        ////        str1 += item.ToString();
        ////    }
        ////    return str1;
        ////}

    }
        
}

