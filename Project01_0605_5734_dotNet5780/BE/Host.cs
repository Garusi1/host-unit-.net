using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Host
    {
        public int HostKey;

        public string PrivateName { get; private set; }
        public string FamilyName { get; private set; }
        public string FhoneNumber { get; private set; }  // יש להוסיף בדיקה שאין תוים  לא חוקיים
        public string MailAddress { get; private set; }

        public BankBranch BankBranchDetails { get; private set; } // יש לבדוק איך מתודות אלו פועלות
        public int BankAccountNumber { get; private set; }
        public string CollectionClearance { get; private set; } //Yes/No //אישור גביה מחשבון הבנק
        public bool aproveCollection { get; private set; } //  תוספת



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

