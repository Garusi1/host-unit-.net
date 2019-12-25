using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_0605_5923
{
    class Host : IEnumerable
    {
        public int HostKey;
        public int sumUnit;
        public List<HostingUnit> HostingUnitCollection = new List<HostingUnit>();

        //ctor
        public Host(int idHost, int numOfHostingUnit)
        {
            this.HostKey = idHost;
            this.sumUnit = numOfHostingUnit;
            for (int i = 0; i < numOfHostingUnit; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }


            /// c# innitilze auto the values of bool 
        }

        //override and indexer
        public override string ToString()  //יש לדרוס את מתודת ToString – כך שתציג עבור הבקשה את כל מאפייניה. 
        {
            string str1 = $"Host Key : {this.HostKey} \n";
            foreach (var item in HostingUnitCollection)
            {
                str1 += item.ToString();
            }
            return str1;
        }
        public HostingUnit this[int i]
        {
            get => HostingUnitCollection[i];
            set => HostingUnitCollection[i] = value;
        }
        public IEnumerator GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

        // Methods
        public bool AssignRequests(params GuestRequest [] RArray)
        {
            foreach (var item in RArray)
            {
                long check = SubmitRequest(item); // כל עוד פנוי יקבל מספר סידורי של יחידת אירוח ויתפוס שם מקום. אחרת יחזיר מינוס 1
                if (check==-1)
                {
                    return false; //זה אומר שלא מצא בשום יחידה מקום פנוי לפי תאריך זה. 
                }

            }
            return true;

        }
        private long SubmitRequest(GuestRequest guestReq) // בודק בכל היחידות אם יש יחידה פנויה בהתאם לבקשה
        {
            foreach (var item in HostingUnitCollection)
            {
                if (item.ApproveRequest(guestReq))
                {
                    return item.HostingUnitKey; //the Request has approved 
                }
            }
            return -1;
        }

        public int GetHostAnnualBusyDays() 
        {
            int sum = 0;
            foreach (var item in HostingUnitCollection)
            {
                sum += item.GetAnnualBusyDays();
            }

            return sum;
        }
        public void SortUnits()
        {
            HostingUnitCollection.Sort();  /// לא ברור מדרישות השאלה האם למיין בסדר עולה או יורד. !!!!///!!!!****
        }

    }

}
